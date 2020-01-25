using FaMEServices.Interfaces;
using FaMEServices.Security.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FaMEServices.Controllers
{
    [Route("api/transfer")]
    [ApiController]
    [ApiVersion("1.0")]
    public class TransferController : ControllerBase
    {
        private readonly ITransferLogic _transferLogic;
        private readonly IFaMELogger _logger;

        public TransferController(ITransferLogic transferLogic, IFaMELogger logger)
        {
            _transferLogic = transferLogic;
            _logger = logger;
        }
    }
}