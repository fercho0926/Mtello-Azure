using Data.Entities.PayCheck;

namespace General.Services
{
    public interface IPayCheckService
    {

        Task InsertPayCheckRecordsAsync(List<PayCheckRecord> records, string fileName, Guid companyId);

    }
}
