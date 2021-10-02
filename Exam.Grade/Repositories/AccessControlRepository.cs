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
    public class AccessControlRepository : IAccessControlRepository
    {
        private readonly IDataAccessFacade<AccessControlEntity> _dataAccess;
        public AccessControlRepository(IDataAccessFacade<AccessControlEntity> dataAccess)
        {
            _dataAccess = dataAccess;
        }
        public void Create(AccessControlEntity entity)
        {
            _ = entity ?? throw new ArgumentNullException($"{nameof(entity)} ");
            _dataAccess.Create(new DataAccessRequest<AccessControlEntity> { Data = entity });
        }

        public void Delete(AccessControlEntity entity)
        {
            _ = entity ?? throw new ArgumentNullException($"{nameof(entity)} ");
            _dataAccess.Delete(new DataAccessRequest<AccessControlEntity> { Data = entity });
        }

        public AccessControlEntity Read(Guid id)
        {
            return _dataAccess.Read(new DataAccessRequest<AccessControlEntity>() { Data = new AccessControlEntity { Id = id } });
        }

        public AccessControlEntity Read(string userId)
        {
            return _dataAccess.Read(new DataAccessRequest<AccessControlEntity>() { Data = new AccessControlEntity { UserId = userId } });
        }
        public IEnumerable<AccessControlEntity>? Read()
        {
            return AccessControlEntity;
        }

        public void Update(AccessControlEntity entity)
        {
            _ = entity ?? throw new ArgumentNullException($"{nameof(entity)} ");
            _dataAccess.Update(new DataAccessRequest<AccessControlEntity> { Data = entity });
        }

        public IEnumerable<AccessControlEntity> AccessControlEntity
        {
            get
            {
                return new List<AccessControlEntity>
                {
                    new AccessControlEntity {RoleId="Admin", UserId="AdminUser", Permissions=new List<string>{"Create","Read","Update","Delete" }},
                    new AccessControlEntity {RoleId="Manager", UserId="ManagerUser", Permissions=new List<string>{"Create","Read","Update"}},
                    new AccessControlEntity {RoleId="Supervisor", UserId="SupervisorUser", Permissions=new List<string>{"Create","Read"}},
                    new AccessControlEntity {RoleId="Guest", UserId="GuestUser", Permissions=new List<string>{"Read"}},
                };
            }

        }
    }
}