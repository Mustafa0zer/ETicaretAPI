using ETicaretAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicarretAPI.Application.Features.Company.Queries.GetAllCompanies
{
    public class GetAllCompanyQueryResponse
    {
        public List<ETicaretAPI.Domain.Entities.Company> Companies { get; set; } 
    }
}
