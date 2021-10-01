using Exam.Grade.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Grade.Services
{
    public interface IAccessControlService
    {
        AccessControl GetPermission(Guid id);
        IEnumerable<AccessControl> GetPermissions();
        void SavePermission(AccessControl accessControl);
    }
}
