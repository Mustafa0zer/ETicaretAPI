using ETicarretAPI.Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicarretAPI.Application.Features.Product.Commands.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequest, CreateProductCommandResponse>
    {
        readonly IProductWriteRepository _writeRepository;

        public CreateProductCommandHandler(IProductWriteRepository writeRepository)
        {
            _writeRepository = writeRepository;
        }

        public async Task<CreateProductCommandResponse> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
        {
            await _writeRepository.AddAsync(new()
            {
                Name = request.Name,
                Stock = request.Stock,
                Price = request.Price,
            });
            return new();
        }
    }
}
