using Points.Server.Services;
using Microsoft.Extensions.Logging;
using Points.DataAccess;
using Points.DataAccess.Entities;
using Points.DataAccess.Facades;

namespace Points.Server.Repositories
{
    public class AccessControlRepository : IAccessControlRepository
    {
        private readonly ILogger<AccessControlRepository> _logger;
        private readonly IDataAccessFacade<AccessControlEntity> _dataAccess;
        private List<AccessControlEntity> _entities;

        public AccessControlRepository(IDataAccessFacade<AccessControlEntity> dataAccess,
            ILogger<AccessControlRepository> logger)
        {
            _dataAccess = dataAccess;
            _logger = logger;
            _entities = new List<AccessControlEntity>(10);
            FillAccessControlEntity();
        }

        public void Create(AccessControlEntity entity)
        {
            _ = entity ?? throw new ArgumentNullException($"{nameof(entity)} ");
            _dataAccess.Create(new DataAccessRequest<AccessControlEntity> { Data = entity });
            _entities.Add(entity);


        }

        public void Delete(AccessControlEntity entity)
        {
            _ = entity ?? throw new ArgumentNullException($"{nameof(entity)} ");
            _dataAccess.Delete(new DataAccessRequest<AccessControlEntity> { Data = entity });
            _entities.Remove(entity);
        }

        public AccessControlEntity? Read(Guid id)
        {
            if (id == default)
                throw new ArgumentException($"Access Control id cannot be an empty/default GUID", nameof(id));
            var entity = _dataAccess.Read(new DataAccessRequest<AccessControlEntity>() { Data = new AccessControlEntity { Id = id } });
            entity = _entities.Where(x => x.Id == id).FirstOrDefault();
            return entity;
        }

        public AccessControlEntity Read(string userId)
        {
            if (string.IsNullOrWhiteSpace(userId))
                throw new ArgumentException($"Access Control id cannot be an empty/default GUID", nameof(userId));
            var entity = _dataAccess.Read(new DataAccessRequest<AccessControlEntity>() { Data = new AccessControlEntity { UserId = userId } });
            entity = _entities.Where(x => x.UserId == userId).FirstOrDefault();
            return entity;
        }
        public IEnumerable<AccessControlEntity> Read()
        {
            var entities = _dataAccess.ReadMany(new DataAccessRequest<AccessControlEntity>());
            entities = _entities;
            return entities;
        }

        public void Update(AccessControlEntity entity)
        {
            _ = entity ?? throw new ArgumentNullException($"{nameof(entity)}");
            _dataAccess.Update(new DataAccessRequest<AccessControlEntity> { Data = entity });
        }

        public void FillAccessControlEntity()
        {
            _entities.Add(new AccessControlEntity { RoleId = "Admin", UserId = "AdminUser", Permissions = new List<string> { "Create", "Read", "Update", "Delete" } });
            _entities.Add(new AccessControlEntity { RoleId = "Manager", UserId = "ManagerUser", Permissions = new List<string> { "Create", "Read", "Update" } });
            _entities.Add(new AccessControlEntity { RoleId = "Supervisor", UserId = "SupervisorUser", Permissions = new List<string> { "Create", "Read" } });
            _entities.Add(new AccessControlEntity { RoleId = "Guest", UserId = "GuestUser", Permissions = new List<string> { "Read" } });
        }
    }
}