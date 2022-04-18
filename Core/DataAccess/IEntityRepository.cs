using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.DataAccess
{
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        DbContext CurrentContext { get; }
        IQueryable<T> Queryable();
        Task AddAsync(T entity);
        Task AddRangeAsync(ICollection<T> entities);
        Task DeleteAsync(T entity);
        Task UpdateAsync(T entity);
        Task UpdateRangeAsync(ICollection<T> entities);

    }
}
