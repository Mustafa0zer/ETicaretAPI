using ETicarretAPI.Application.Features.Company.Commands.CreateCompany;
using ETicarretAPI.Application.Features.Company.Commands.UpdateCompany;
using ETicarretAPI.Application.Features.Company.Queries.GetAllCompanies;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CompanyController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateCompanyCammandRequest createCompanyCammandRequest)
        {
            CreateCompanyCammandResponse company = await _mediator.Send(createCompanyCammandRequest);
            return Ok(company);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            GetAllCompanyQueryResponse companies = await _mediator.Send(new GetAllCompanyQueryRequest());
           return  Ok(companies);
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateCompanyCommandRequest updateCompanyCommandRequest)
        {
            UpdateCompanyCommandResponse company = await _mediator.Send(updateCompanyCommandRequest);
            return Ok(company);
        }
    }
}
