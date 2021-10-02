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

    public interface IAccessControlRepository : IRepository<AccessControlEntity, Guid>
    {
        AccessControlEntity Read(string userId);
    }
    
}