using Data.Entities.PayCheck;

namespace General.Services
{
    public interface IReportingService
    {
        Task<IEnumerable<BatchPaycheck>> GetAllBatchPayChecks();




    }
}
