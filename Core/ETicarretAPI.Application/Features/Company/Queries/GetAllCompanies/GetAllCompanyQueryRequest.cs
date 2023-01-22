using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicarretAPI.Application.Features.Company.Queries.GetAllCompanies
{
    public class GetAllCompanyQueryRequest:IRequest<GetAllCompanyQueryResponse>
    {
    }
}
