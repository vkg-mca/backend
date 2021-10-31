using Exam.Grade.DomainObjects;
using Exam.Grade.Repositories;
using Microsoft.Extensions.Logging;
using Points.DataAccess.Entities;

namespace Exam.Grade.Services
{
    public class AccessControlService : IAccessControlService
    {
        private readonly IAccessControlRepository _repository;
        private readonly ILogger<AccessControlService> _logger;

        public AccessControlService(IAccessControlRepository repository,
            ILogger<AccessControlService> logger)
        {
            _logger = logger;
            _repository = repository;
        }
        
        public AccessControl GetPermission(Guid id)
        {
            var entiry= _repository.Read(id);
            return new AccessControl {Permissions = entiry.Permissions ,RoleId = entiry.RoleId, UserId= entiry.UserId  };
        }

        public AccessControl GetPermission(string userId)
        {
            var entiry = _repository.Read(userId);
            return new AccessControl { Permissions = entiry?.Permissions, RoleId = entiry?.RoleId, UserId = entiry?.UserId };
        }

        public IEnumerable<AccessControl> GetPermissions()
        {
            var permissions = new List<AccessControl>();
          var entities = _repository.Read();
            foreach (var entity in entities)
            {
                permissions.Add(new AccessControl { Permissions = entity.Permissions, UserId = entity.UserId, RoleId = entity.RoleId });
            }

            return permissions;
        }

        public void SavePermission(AccessControl accessControl)
        {
            _repository.Create(new AccessControlEntity {RoleId = accessControl.RoleId,UserId = accessControl.UserId, Permissions = accessControl.Permissions });
        }
    }
}