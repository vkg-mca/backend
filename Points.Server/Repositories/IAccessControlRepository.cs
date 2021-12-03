using Points.DataAccess.Entities;

namespace Points.Server.Repositories
{

    public interface IAccessControlRepository : IRepository<AccessControlEntity, Guid>
    {
        AccessControlEntity Read(string userId);
    }
    
}