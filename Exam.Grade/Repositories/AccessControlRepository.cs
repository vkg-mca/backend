using Exam.Grade.DomainObjects;
using Points.DataAccess;
using Points.DataAccess.Entities;
using Points.DataAccess.Facades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Grade.Repositories
{
    public class AccessControlRepository<TEntity> : IRepository<TEntity,Guid> where TEntity : AccessControlEntity 
    {
        private readonly IDataAccessFacade<TEntity> _dataAccess;
        public AccessControlRepository(IDataAccessFacade<TEntity> dataAccess)
        {
            _dataAccess = dataAccess;
        }
        public void Create(TEntity entity)
        {
            _ = entity ?? throw new ArgumentNullException($"{nameof(entity)} ");
            _dataAccess.Create(new DataAccessRequest<TEntity> { Data = entity });
        }

        public void Delete(TEntity entity)
        {
            _ = entity ?? throw new ArgumentNullException($"{nameof(entity)} ");
            _dataAccess.Delete(new DataAccessRequest<TEntity> { Data = entity });
        }

        public TEntity Read(Guid id)
        {
            return _dataAccess.Read(new DataAccessRequest<TEntity>());
        }

        public IEnumerable<TEntity>? Read()
        {
            return AccessControlEntity as IEnumerable<TEntity>;
        }

        public void Update(TEntity entity)
        {
            _ = entity ?? throw new ArgumentNullException($"{nameof(entity)} ");
            _dataAccess.Update(new DataAccessRequest<TEntity> { Data = entity });
        }

     

        public IEnumerable<AccessControlEntity> AccessControlEntity
        {
            get
            {
                return new List<AccessControlEntity>
                {
                    new AccessControlEntity {Id =Guid.NewGuid(),RoleId="Admin", UserId="AdminUser", Permissions=new List<string>{"Create","Read","Update","Delete" }},
                    new AccessControlEntity {Id =Guid.NewGuid(),RoleId="Manager", UserId="ManagerUser", Permissions=new List<string>{"Create","Read","Update"}},
                    new AccessControlEntity {Id =Guid.NewGuid(),RoleId="Supervisor", UserId="SupervisorUser", Permissions=new List<string>{"Create","Read"}},
                    new AccessControlEntity {Id =Guid.NewGuid(),RoleId="Guest", UserId="GuestUser", Permissions=new List<string>{"Read"}},
                };
            }

        }
    }
}