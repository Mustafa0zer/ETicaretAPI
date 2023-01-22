using ETicaretAPI.Domain.Entities.Common;
using ETicaretAPI.Persistence.Context;
using ETicarretAPI.Application.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Persistence.Repositories
{
    public class WriteRepository<T> : IWriteRepository<T> where T : BaseEntitiy
    {
        private readonly ETicaretAPIDbContext _context;

        public WriteRepository(ETicaretAPIDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();


        public async Task<bool> AddAsync(T entity)
        {
            EntityEntry<T> Entry = await Table.AddAsync(entity);
            _context.SaveChanges();
            return Entry.State == EntityState.Added;
        }

        public bool Delete(T entity)
        {
            EntityEntry<T> Entry = Table.Remove(entity);
            _context.SaveChanges();
            return Entry.State == EntityState.Deleted;

        }
        public  bool Update(T entity)
        {
            EntityEntry<T> Entry =  Table.Update(entity);
            _context.SaveChanges();
            return Entry.State == EntityState.Modified;
        }
    }
}
