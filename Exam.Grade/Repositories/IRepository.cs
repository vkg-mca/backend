using Points.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Grade.Repositories
{
    public interface IRepository<TEntity, TIdentity>
    {
        void Create(TEntity entity);
        TEntity Read(TIdentity id);
        IEnumerable<TEntity>? Read();
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}
