using ETicarretAPI.Application.Features.Company.Commands.CreateCompany;
using ETicarretAPI.Application.Features.Company.Commands.UpdateCompany;
using ETicarretAPI.Application.Features.Company.Queries.GetAllCompanies;
using ETicarretAPI.Application.Features.Orders.CreateOrder;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace ETicaretAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly HttpContext context;
        public OrdersController(IMediator mediator, IHttpContextAccessor contextAccessor)
        {
            _mediator = mediator;
            context = contextAccessor.HttpContext;
        }
       
        [HttpPost]
        public async Task<IActionResult> Create(CreateOrderCommandRequest createOrderCommandRequest)
        {
            CreateOrderCommandResponse order = await _mediator.Send(createOrderCommandRequest);
            
            return Ok(order.Message);
        }

    }
}
