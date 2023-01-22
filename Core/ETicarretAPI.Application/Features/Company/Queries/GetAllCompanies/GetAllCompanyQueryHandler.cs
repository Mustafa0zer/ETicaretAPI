using ETicarretAPI.Application.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicarretAPI.Application.Features.Company.Queries.GetAllCompanies
{
    public class GetAllCompanyQueryHandler : IRequestHandler<GetAllCompanyQueryRequest, GetAllCompanyQueryResponse>
    {
        readonly ICompanyReadRepository companyReadRepository;
       
        public GetAllCompanyQueryHandler(ICompanyReadRepository companyReadRepository )
        {
            this.companyReadRepository = companyReadRepository;
            
        }

        public async Task<GetAllCompanyQueryResponse> Handle(GetAllCompanyQueryRequest request, CancellationToken cancellationToken)
        {
          
            var companies = await companyReadRepository.GetAllAsync();
            return new()
            {
                Companies = companies
            };
        }
    }
}
