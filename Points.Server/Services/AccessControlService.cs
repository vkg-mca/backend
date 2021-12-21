using Points.Server.Models;
using Points.Server.Repositories;
using Microsoft.Extensions.Logging;
using Points.DataAccess.Entities;
using Points.Entities.Models;

namespace Points.Server.Services
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

        public async Task<AccessControl> GetPermissionAsync(int id)
        {
            if (id == default)
            {
                var reason = $"Access Control id cannot be an empty/default GUID";
                var logEntry = new LogEntry
                {
                    Code = ArgumentCode.InvalidArgumet,
                    Message = reason,
                    Context = new Dictionary<string, string> { { nameof(id), id.ToString() } }
                };
                _logger.Log(LogLevel.Error, 0, logEntry,null, (state, exception) => exception?.Message ?? state.ToString());
               

                throw new ArgumentException(reason, nameof(id));
            }
            var entiry = await _repository.GetAsync(id);
            return new AccessControl();
        }

        public async Task<AccessControl> GetPermissionAsync(string userId)
        {
            if (string.IsNullOrWhiteSpace(userId))
                throw new ArgumentException($"Access Control id cannot be an empty/default", nameof(userId));
            var entiry = await _repository.GetAsync(userId);
            return new AccessControl();
        }

        public async Task<IEnumerable<AccessControl>> GetPermissionsAsync()
        {
            var permissions = new List<AccessControl>();
            var entities = await _repository.GetAllAsync();
            if (!(null == entities))
                foreach (var entity in entities)
                    permissions.Add(new AccessControl { RoleId = entity.RoleId });
            return permissions;
        }

        public async Task SavePermissionAsync(AccessControl accessControl)
        {
            if (accessControl == default)
                throw new ArgumentException($"Access Control cannot be an empty/null", nameof(accessControl));
            await _repository.CreateAsync(new UserRole());
        }



        public async Task DeletePermissionAsync(int id)
        {
            if (id <= 0)
                throw new ArgumentException($"Access Control id cannot be zero or negative number", nameof(id)); ;
            await _repository.DeleteAsync(id)
                .ConfigureAwait(false);
        }
        public async Task DeletePermissionAsync(string userId)
        {
            if (string.IsNullOrWhiteSpace(userId))
                throw new ArgumentException($"UserId cannot be empty/blank", nameof(userId)); ;
            await _repository.DeleteAsync(userId)
                .ConfigureAwait(false);
        }

    }
}