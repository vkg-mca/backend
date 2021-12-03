using Points.Server.Repositories;
using Points.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Points.Server.Repositories
{
    public interface IAccessControlRepositoryV2 : IRepositoryV2<int, RolePermission>
    {
    }
}
