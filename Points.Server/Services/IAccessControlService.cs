using Points.Server.Models;

namespace Points.Server.Services
{
    public interface IAccessControlService
    {
        Task<AccessControl> GetPermissionAsync(int id);
        Task<AccessControl> GetPermissionAsync(string userId);
        Task<IEnumerable<AccessControl>> GetPermissionsAsync();
        Task SavePermissionAsync(AccessControl accessControl);
    }
}
