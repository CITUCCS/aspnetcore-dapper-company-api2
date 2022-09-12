using CompanyApp.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CompanyApp.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class CompaniesController : ControllerBase
    {
        private readonly ICompanyRepository _companyRepo;

        public CompaniesController(ICompanyRepository companyRepo)
        {
            _companyRepo = companyRepo;
        }

        // GET /api/companies/{id}
        [HttpGet("{id}")]
        public IActionResult GetCompany(int id)
        {
            try
            {
                var company = _companyRepo.GetCompany(id);
                if (company == null)
                    return NotFound();

                return Ok(company);
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }
    }
}
