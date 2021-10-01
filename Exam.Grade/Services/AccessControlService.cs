using Exam.Grade.DomainObjects;
using Exam.Grade.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using Points.DataAccess;

namespace Exam.Grade.Services
{
    public class AccessControlService : IAccessControlService
    {
        private readonly IRepository<AccessControl,Guid> _repository;
        public AccessControlService(IRepository<AccessControl, Guid> repository)
        {
            _repository = repository;
        }
        public AccessControl GetPermission(Guid id)
        {
            return _repository.Read(id);
        }
        public IEnumerable<AccessControl> GetPermissions()
        {
            return _repository.Read();  
        }
        public void SavePermission(AccessControl accessControl)
        {
            _repository.Create(accessControl);
        }
    }
}
