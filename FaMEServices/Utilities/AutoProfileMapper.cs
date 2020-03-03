using AutoMapper;
using FaMEServices.Models;
using System;
using DataModels = FaMEServices.Repositories.Models;

namespace FaMEServices.Utilities
{
    public class AutoProfileMapper : Profile
    {
        public AutoProfileMapper()
        {
            CreateMap<DataModels.UserAccount, LoginUser>()
                    .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.Id))
                    .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName))
                    .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password))
                    .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
                    .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
                    .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role.Type))
                    .ForMember(dest => dest.EmailId, opt => opt.MapFrom(src => src.EmailId))
                    .ForMember(dest => dest.Dob, opt => opt.MapFrom(src => src.Dob))
                    .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.Phone))
                    .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address))
                    .ForMember(dest => dest.Company, opt => opt.MapFrom(src => src.Company));

            CreateMap<Attendance, DataModels.Attendance>()
                    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                    .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
                    .ForMember(dest => dest.ClientId, opt => opt.MapFrom(src => src.ClientId))
                    .ForMember(dest => dest.CheckInDateTime, opt => opt.MapFrom(src => src.CheckInDateTime))
                    .ForMember(dest => dest.CheckOutDateTime, opt => opt.MapFrom(src => src.CheckOutDateTime))
                    .ForMember(dest => dest.OverTime, opt => opt.MapFrom(src => 0))
                    .ForMember(dest => dest.CheckInLatitude, opt => opt.MapFrom(src => src.CheckInLatitude))
                    .ForMember(dest => dest.CheckInLongitude, opt => opt.MapFrom(src => src.CheckInLongitude))
                    .ForMember(dest => dest.CheckOutLatitude, opt => opt.MapFrom(src => src.CheckOutLatitude))
                    .ForMember(dest => dest.CheckOutLongitude, opt => opt.MapFrom(src => src.CheckOutLongitude))
                    .ForMember(dest => dest.CreatedDateTime, opt => opt.MapFrom(src => DateTimeOffset.Now))
                    .ForMember(dest => dest.UpdatedDateTime, opt => opt.MapFrom(src => DateTimeOffset.Now));
        }
    }
}
