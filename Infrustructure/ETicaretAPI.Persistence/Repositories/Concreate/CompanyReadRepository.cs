using ETicaretAPI.Domain.Entities;
using ETicaretAPI.Persistence.Context;
using ETicarretAPI.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Persistence.Repositories.Concreate
{
    public class CompanyReadRepository : ReadRepository<Company>, ICompanyReadRepository
    {
        public CompanyReadRepository(ETicaretAPIDbContext context) : base(context)
        {
        }
    }
}
