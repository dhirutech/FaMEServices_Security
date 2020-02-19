using FaMEServices.Interfaces;
using FaMEServices.Repositories.Interfaces;
using FaMEServices.Security.Interfaces;

namespace FaMEServices.Logics
{
    public class TransferLogic : ITransferLogic
    {
        private readonly ITransferRepository _transferRepo;
        private readonly IFaMEHelper _helper;

        public TransferLogic(ITransferRepository transferRepo, IFaMEHelper helper)
        {
            _transferRepo = transferRepo;
            _helper = helper;
        }
    }
}
