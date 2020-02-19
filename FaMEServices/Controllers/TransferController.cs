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
        private readonly IFaMEHelper _helper;

        public TransferController(ITransferLogic transferLogic, IFaMEHelper helper)
        {
            _transferLogic = transferLogic;
            _helper = helper;
        }
    }
}