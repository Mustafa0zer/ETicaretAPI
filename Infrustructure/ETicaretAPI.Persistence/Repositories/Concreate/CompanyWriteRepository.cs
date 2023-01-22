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
    public class CompanyWriteRepository : WriteRepository<Company>, ICompanyWriteRepository
    {
        public CompanyWriteRepository(ETicaretAPIDbContext context) : base(context)
        {
        }
    }
}
