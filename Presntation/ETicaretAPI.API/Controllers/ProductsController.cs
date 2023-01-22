using ETicaretAPI.Domain.Entities;
using ETicarretAPI.Application.Features.Product.Commands.CreateProduct;
using ETicarretAPI.Application.Features.Product.Queries.GetALLProducts;
using ETicarretAPI.Application.Repositories;
using ETicarretAPI.Application.ViewModels.Products;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Net;

namespace ETicaretAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        readonly IMediator _mediator;
        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
           GetALLProductQueryResponse response = await _mediator.Send(new GetALLProductQueryRequest());
            return Ok(response);
        }
        [HttpPost]
        public async Task<IActionResult> Add(CreateProductCommandRequest createProductCommandRequest)
        {
           CreateProductCommandResponse response =await _mediator.Send(createProductCommandRequest);
            return StatusCode((int)HttpStatusCode.Created);
        }
       
    }
}
