using Data.Entities.PayCheck;
using General.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public class ReportingController : BaseApiController
    {

        private readonly IReportingService _reportingService;

        public ReportingController(IReportingService reportingService)
        {
            _reportingService = reportingService;
        }


        //[Authorize]
        [HttpGet("GetAllBatchPayChecks")]
        public async Task<IEnumerable<BatchPaycheck>> GetAllBatchPayChecks()
        {
            return await _reportingService.GetAllBatchPayChecks();
        }




    }
}