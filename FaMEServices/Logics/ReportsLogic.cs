using FaMEServices.Interfaces;
using FaMEServices.Repositories.Interfaces;
using FaMEServices.Security.Interfaces;

namespace FaMEServices.Logics
{
    public class ReportsLogic : IReportsLogic
    {
        private readonly IReportsRepository _reportsRepo;
        private readonly IFaMELogger _logger;

        public ReportsLogic(IReportsRepository reportsRepo, IFaMELogger logger)
        {
            _reportsRepo = reportsRepo;
            _logger = logger;
        }
    }
}
