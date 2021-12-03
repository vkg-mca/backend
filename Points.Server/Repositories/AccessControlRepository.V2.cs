using Points.Server.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Points.DataAccess;
using Points.DataAccess.Entities;
using Points.DataAccess.Facades;
using Points.Entities.Models;
using Points.Server.Repositories;

namespace Points.Server.Repositories
{
    public class AccessControlRepositoryV2 : IAccessControlRepositoryV2
    {
        private readonly PointsDbContext _context;
        public AccessControlRepositoryV2(PointsDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<UserRole>> GetAllAsync()
        {
            return await _context.UserRoles.ToListAsync();
        }

        public async Task<UserRole> GetAsync(int identity)
        {
            return await _context.UserRoles.FindAsync(identity).ConfigureAwait(false);
        }

        public async Task UpdateAsync(int identity, UserRole entity)
        {
            if (identity != entity.Id)
                throw new AccessViolationException(
                    $"Source entity id {entity.Id} and target entity id {identity} do not match");
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task CreateAsync(UserRole entity)
        {
            _context.UserRoles.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int identity)
        {
            var entity = await _context.UserRoles.FindAsync(identity);
            if (entity == null) return;
            _context.UserRoles.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}