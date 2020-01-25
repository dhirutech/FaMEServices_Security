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
        private readonly IFaMELogger _logger;

        public ReportsController(IReportsLogic reportsLogic, IFaMELogger logger)
        {
            _reportsLogic = reportsLogic;
            _logger = logger;
        }
    }
}