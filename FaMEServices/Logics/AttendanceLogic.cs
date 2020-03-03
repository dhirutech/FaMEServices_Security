using System;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using FaMEServices.Interfaces;
using FaMEServices.Models;
using DataModels = FaMEServices.Repositories.Models;
using FaMEServices.Repositories.Interfaces;
using FaMEServices.Security.Interfaces;
using FaMEServices.Security.Models;
using FaMEServices.Utilities;
using GeoCoordinatePortable;

namespace FaMEServices.Logics
{
    public class AttendanceLogic : IAttendanceLogic
    {
        private readonly IAttendanceRepository _attendanceRepo;
        private readonly IFaMEHelper _helper;
        private readonly IMapper _mapper;

        public AttendanceLogic(IMapper mapper, IAttendanceRepository attendanceRepo, IFaMEHelper helper)
        {
            _mapper = mapper;
            _attendanceRepo = attendanceRepo;
            _helper = helper;
        }

        private async Task<double> GetGeoDistance(Guid clientId, decimal lat, decimal lng)
        {
            double distnace = 100;
            var clientResult = await _attendanceRepo.GetClientById(clientId);
            if (clientResult != null)
            {
                var sCoord = new GeoCoordinate(Convert.ToDouble(clientResult.Latitude), Convert.ToDouble(clientResult.Longitude));
                var eCoord = new GeoCoordinate(Convert.ToDouble(lat), Convert.ToDouble(lng));
                distnace = sCoord.GetDistanceTo(eCoord);
            }
            return distnace;
        }

        public async Task<ResponseObject> SubmitAttendance(string type, Attendance attendance)
        {
            double geoDistance = 0;
            if (attendance.ClientId == Guid.Empty)
                return _helper.BuildResponse("BadRequest", null, "Provided ClientId is Invalli!", (int)HttpStatusCode.BadRequest);
            else
            {
                var attenType = ModelValidation.ParseEnum<string>(type, typeof(AttendanceType));
                var atten = _mapper.Map<DataModels.Attendance>(attendance);
                if (string.Equals(attenType, AttendanceType.CheckIn.ToString(), StringComparison.CurrentCultureIgnoreCase))
                {
                    geoDistance = await GetGeoDistance(atten.ClientId, atten.CheckInLatitude, atten.CheckInLongitude);
                }
                else
                {
                    geoDistance = await GetGeoDistance(atten.ClientId, atten.CheckOutLatitude.Value, atten.CheckOutLongitude.Value);
                    TimeSpan diff = atten.CheckInDateTime.Value - atten.CheckOutDateTime.Value;
                    atten.OverTime = diff.TotalHours - 8 > 0 ? diff.TotalHours - 8 : 0;
                }
                if (geoDistance > 100)
                    return _helper.BuildResponse("BadRequest", null, "Unable Submited Attendance! GeoLocation Mismatch", (int)HttpStatusCode.BadRequest);

                if (await _attendanceRepo.SubmitAttendance(atten))
                {
                    var result = await _attendanceRepo.GetAttendanceById(atten.Id);
                    return _helper.BuildResponse("Success", result, "Attendance Submited successfully!", (int)HttpStatusCode.OK);
                }
                else
                    return _helper.BuildResponse("Failure", null, "Unable Submited Attendance", (int)HttpStatusCode.InternalServerError);
            }
        }
    }
}
