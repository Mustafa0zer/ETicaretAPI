using ETicarretAPI.Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicarretAPI.Application.Features.Company.Commands.CreateCompany
{
    public class CreateCompanyCammandHandler : IRequestHandler<CreateCompanyCammandRequest, CreateCompanyCammandResponse>
    {
        readonly ICompanyWriteRepository _companyWriteRepository;

        public CreateCompanyCammandHandler(ICompanyWriteRepository companyWriteRepository)
        {
            _companyWriteRepository = companyWriteRepository;
        }

        public async Task<CreateCompanyCammandResponse> Handle(CreateCompanyCammandRequest request, CancellationToken cancellationToken)
        {

            await _companyWriteRepository.AddAsync(new()
            {
                Name = request.Name,
                State = request.State,
                OrderStart = TimeSpan.Parse(request.OrderStart),
                OrderEnd = TimeSpan.Parse(request.OrderEnd),
            });
            return new();
        }
    }
}
