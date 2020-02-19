using FaMEServices.Interfaces;
using FaMEServices.Security.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FaMEServices.Controllers
{
    [Route("api/reports")]
    [ApiController]
    [ApiVersion("1.0")]
    public class ReportsController : ControllerBase
    {
        private readonly IReportsLogic _reportsLogic;
        private readonly IFaMEHelper _helper;

        public ReportsController(IReportsLogic reportsLogic, IFaMEHelper helper)
        {
            _reportsLogic = reportsLogic;
            _helper = helper;
        }
    }
}