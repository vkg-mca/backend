using Points.Server.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Points.DataAccess;
using Points.DataAccess.Entities;
using Points.DataAccess.Facades;
using Points.Entities.Models;
using Points.Server.Repositories;
using System.Security.Principal;

namespace Points.Server.Repositories
{
    public class AccessControlRepository : IAccessControlRepository
    {
        private readonly PointsDbContext _context;
        private readonly ILogger<AccessControlRepository> _logger;
        public AccessControlRepository(PointsDbContext context, ILogger<AccessControlRepository> logger)
        {
            _context = context;
            _logger= logger;
        }
        public async Task<IEnumerable<UserRole?>> GetAllAsync()
            => await _context.UserRoles.ToListAsync()
                .ConfigureAwait(false);

        public async Task<UserRole?> GetAsync(int identity)
        {
            if (identity <= 0)
                throw new ArgumentException(
                    $"Identity cannot be less than or equal to zero", nameof(identity));
            return await _context.UserRoles.FindAsync(identity)
                .ConfigureAwait(false);
        }

        public async Task<UserRole?> GetAsync(string userId)
        {
            if (string.IsNullOrWhiteSpace(userId))
                throw new ArgumentException(
                    $"userId cannot be null/empty", nameof(userId));
            return await _context.UserRoles.Where(x => x.User.Code == userId)
                .FirstOrDefaultAsync()
                .ConfigureAwait(false);
        }

        public async Task UpdateAsync(int identity, UserRole entity)
        {
            if (identity != entity.Id)
                throw new AccessViolationException(
                    $"Source entity id {entity.Id} and target entity id {identity} do not match");
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync()
                .ConfigureAwait(false);
        }

        public async Task CreateAsync(UserRole entity)
        {
            _context.UserRoles.Add(entity);
            await _context.SaveChangesAsync()
                .ConfigureAwait(false); ;
        }

        public async Task DeleteAsync(int identity)
        {
            var entity = await _context.UserRoles.FindAsync(identity)
                .ConfigureAwait(false); ;
            await Delete(entity);
        }

        public async Task DeleteAsync(string userId)
        {
            var entity = await _context.UserRoles.Where(x => x.User.Code == userId)
                .FirstOrDefaultAsync()
                .ConfigureAwait(false);
            await Delete(entity);
        }

        private async Task Delete(UserRole? entity)
        {
            if (entity == null) return;
            _context.UserRoles.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}