using Data;
using Data.Entities.PayCheck;
using Microsoft.EntityFrameworkCore;

namespace General.Services
{
    public class ReportingService : IReportingService
    {
        private readonly AppDbContext _appDbContext;

        public ReportingService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<IEnumerable<BatchPaycheck>> GetAllBatchPayChecks()
        {
            return await _appDbContext.BatchPaycheck.ToListAsync();
        }

        //public async Task<BatchPaycheck> GetBatchPaycheckById(Guid id)
        //{
        //    return await _appDbContext.BatchPaycheck
        //        .Include(bp => bp.Company) // Include related Company entity if needed
        //        .Include(bp => bp.PayCheckRecord) // Include related PayCheckRecord entities if needed
        //        .FirstOrDefaultAsync(bp => bp.BatchPaycheckId == id);
        //}



    }

}
