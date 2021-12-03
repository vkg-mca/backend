using Points.Server.Repositories;
using Points.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Principal;

namespace Points.Server.Repositories
{
    public interface IAccessControlRepositoryV2 : IRepositoryV2<int, UserRole>
{
        Task<UserRole?> GetAsync(string userId) => throw new NotImplementedException();
        Task DeleteAsync(string userId) => throw new NotImplementedException();
    }
}
