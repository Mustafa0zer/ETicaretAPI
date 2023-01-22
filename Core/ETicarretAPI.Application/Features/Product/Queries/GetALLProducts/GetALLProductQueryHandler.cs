using ETicarretAPI.Application.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicarretAPI.Application.Features.Product.Queries.GetALLProducts
{
    public class GetALLProductQueryHandler : IRequestHandler<GetALLProductQueryRequest, GetALLProductQueryResponse>
    {
        readonly IProductReadRepository _productReadRepository;
  

        public GetALLProductQueryHandler(IProductReadRepository productReadRepository)
        {
            _productReadRepository = productReadRepository;
            
        }

        public async Task<GetALLProductQueryResponse> Handle(GetALLProductQueryRequest request, CancellationToken cancellationToken)
        {
            
            var products = await _productReadRepository.GetAllAsync();

            return new() { Products = products };
        }
    }
}
