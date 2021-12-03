//using Points.Server.DomainObjects;
//using Points.Server.Repositories;
//using Microsoft.Extensions.Logging;
//using Points.DataAccess.Entities;

//namespace Points.Server.Services
//{
//    public class AccessControlService : IAccessControlService
//    {
//        private readonly IAccessControlRepository _repository;
//        private readonly ILogger<AccessControlService> _logger;

//        public AccessControlService(IAccessControlRepository repository,
//            ILogger<AccessControlService> logger)
//        {
//            _logger = logger;
//            _repository = repository;
//        }

//        public AccessControl GetPermission(Guid id)
//        {
//            if (id == default)
//                throw new ArgumentException($"Access Control id cannot be an empty/default GUID", nameof(id));
//            var entiry = _repository.Read(id);
//            return new AccessControl { Permissions = entiry.Permissions, RoleId = entiry.RoleId, UserId = entiry.UserId };
//        }

//        public AccessControl GetPermission(string userId)
//        {
//            if (string.IsNullOrWhiteSpace(userId))
//                throw new ArgumentException($"Access Control id cannot be an empty/default GUID", nameof(userId));
//            var entity = _repository.Read(userId);
//            return new AccessControl { Permissions = entity.Permissions, RoleId = entity.RoleId, UserId = entity.UserId };
//        }

//        public IEnumerable<AccessControl> GetPermissions()
//        {
//            var permissions = new List<AccessControl>();
//            var entities = _repository.Read();
//            if (!(null == entities))
//                foreach (var entity in entities)
//                    permissions.Add(new AccessControl { Permissions = entity.Permissions, UserId = entity.UserId, RoleId = entity.RoleId });
//            return permissions;
//        }

//        public void SavePermission(AccessControl accessControl)
//        {
//            if (accessControl == default)
//                throw new ArgumentException($"Access Control cannot be an empty/null", nameof(accessControl));
//            _repository.Create(new AccessControlEntity { RoleId = accessControl.RoleId, UserId = accessControl.UserId, Permissions = accessControl.Permissions });
//        }
//    }
//}