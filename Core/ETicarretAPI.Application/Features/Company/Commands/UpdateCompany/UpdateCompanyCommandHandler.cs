using ETicaretAPI.Domain.Entities;
using ETicarretAPI.Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicarretAPI.Application.Features.Company.Commands.UpdateCompany
{
    public class UpdateCompanyCommandHandler : IRequestHandler<UpdateCompanyCommandRequest, UpdateCompanyCommandResponse>
    {
        readonly ICompanyReadRepository companyReadRepository;
        readonly ICompanyWriteRepository companyWriteRepository;

        public UpdateCompanyCommandHandler(ICompanyReadRepository companyReadRepository, ICompanyWriteRepository companyWriteRepository)
        {
            this.companyReadRepository = companyReadRepository;
            this.companyWriteRepository = companyWriteRepository;
        }

        public async Task<UpdateCompanyCommandResponse> Handle(UpdateCompanyCommandRequest request, CancellationToken cancellationToken)
        {
            ETicaretAPI.Domain.Entities.Company company = await companyReadRepository.GetAsync(x => x.Name == request.Name);
            company.State = request.State;
            company.OrderStart = TimeSpan.Parse(request.OrderStart);
            company.OrderEnd = TimeSpan.Parse(request.OrderEnd);
            companyWriteRepository.Update(company);
            return new();
        }
    }
}
