using Points.Server.DomainObjects;

namespace Points.Server.Services
{
    public interface IAccessControlService
    {
        AccessControl GetPermission(Guid id);
        AccessControl GetPermission(string userId);
        IEnumerable<AccessControl> GetPermissions();
        void SavePermission(AccessControl accessControl);
    }
}
