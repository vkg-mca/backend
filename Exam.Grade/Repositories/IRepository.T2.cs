using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Points.Server.Repositories
{
    public interface IRepository<in TIdentity, TEntity>
    {
        Task<IEnumerable<TEntity>> GetAllAsync() => throw new NotImplementedException();
        Task<TEntity> GetAsync(TIdentity identity) => throw new NotImplementedException();
        Task CreateAsync(TEntity entity) => throw new NotImplementedException();
        Task DeleteAsync(TIdentity identity) => throw new NotImplementedException();
        Task UpdateAsync(TIdentity identity, TEntity entity) => throw new NotImplementedException();
    }
}
