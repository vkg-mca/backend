using Points.DataAccess.Entities;

namespace Exam.Grade.Repositories
{

    public interface IAccessControlRepository : IRepository<AccessControlEntity, Guid>
    {
        AccessControlEntity Read(string userId);
    }
    
}