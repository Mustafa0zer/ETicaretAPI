using ETicaretAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ETicarretAPI.Application.Repositories
{
    public interface IReadRepository<T> :IRepository<T> where T : BaseEntitiy
    {
        T Get(Expression<Func<T, bool>> filter);
        Task<T> GetAsync(Expression<Func<T, bool>> filter);
        IQueryable<T> GetAll();
        Task<List<T>> GetAllAsync();
    }
}
