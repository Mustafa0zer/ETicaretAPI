using ETicaretAPI.Domain.Entities.Common;
using ETicaretAPI.Persistence.Context;
using ETicarretAPI.Application.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Persistence.Repositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : BaseEntitiy
    {
        private readonly ETicaretAPIDbContext _context;

        public ReadRepository(ETicaretAPIDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public T Get(Expression<Func<T, bool>> filter)
        {
            return _context.Set<T>().Where(filter).FirstOrDefault();
        }

        public IQueryable<T> GetAll() => Table;


        public async Task<List<T>> GetAllAsync() =>await Table.ToListAsync();
        

        public async Task<T> GetAsync(Expression<Func<T, bool>> filter)
        {
            return await _context.Set<T>().Where(filter).FirstOrDefaultAsync();
        }
    }
}
