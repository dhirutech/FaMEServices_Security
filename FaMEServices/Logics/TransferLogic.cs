using FaMEServices.Interfaces;
using FaMEServices.Repositories.Interfaces;
using FaMEServices.Security.Interfaces;

namespace FaMEServices.Logics
{
    public class TransferLogic : ITransferLogic
    {
        private readonly ITransferRepository _transferRepo;
        private readonly IFaMELogger _logger;

        public TransferLogic(ITransferRepository transferRepo, IFaMELogger logger)
        {
            _transferRepo = transferRepo;
            _logger = logger;
        }
    }
}
