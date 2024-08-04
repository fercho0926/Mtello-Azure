using Data.Entities.Company;
using General.Models.Company;
using General.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public class CompanyController : BaseApiController
    {

        private readonly ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }


        //[Authorize]
        [HttpGet]
        public async Task<IEnumerable<Company>> GetAll()
        {
            return await _companyService.GetAll();
        }


        //[Authorize]
        [HttpPost("Create")]
        public async Task<ActionResult<CreateCompanyResponse>> Create(CreateCompanyRequest request)
        {

            var isCompanyCreated = await _companyService.IsCompanyCreated(request);

            if (isCompanyCreated)
            {
                return BadRequest("Company already exist : " + request.CompanyName);
            }


            return await _companyService.Create(request);

        }



    }
}