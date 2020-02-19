using FaMEServices.Interfaces;
using FaMEServices.Repositories.Interfaces;
using FaMEServices.Security.Interfaces;

namespace FaMEServices.Logics
{
    public class ReportsLogic : IReportsLogic
    {
        private readonly IReportsRepository _reportsRepo;
        private readonly IFaMEHelper _helper;

        public ReportsLogic(IReportsRepository reportsRepo, IFaMEHelper helper)
        {
            _reportsRepo = reportsRepo;
            _helper = helper;
        }
    }
}
