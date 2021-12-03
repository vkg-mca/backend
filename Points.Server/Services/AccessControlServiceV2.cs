﻿using Points.Server.Models;
using Points.Server.Repositories;
using Microsoft.Extensions.Logging;
using Points.DataAccess.Entities;
using Points.Entities.Models;

namespace Points.Server.Services
{
    public class AccessControlServiceV2 : IAccessControlService
    {
        private readonly IAccessControlRepositoryV2 _repository;
        private readonly ILogger<AccessControlService> _logger;

        public AccessControlServiceV2(IAccessControlRepositoryV2 repository,
            ILogger<AccessControlService> logger)
        {
            _logger = logger;
            _repository = repository;
        }

        public async Task<AccessControl> GetPermissionAsync(int id)
        {
            if (id == default)
                throw new ArgumentException($"Access Control id cannot be an empty/default GUID", nameof(id));
            var entiry = await _repository.GetAsync(id);
            return new AccessControl();
        }

        public async Task<AccessControl> GetPermissionAsync(string userId)
        {
            if (string.IsNullOrWhiteSpace(userId))
                throw new ArgumentException($"Access Control id cannot be an empty/default GUID", nameof(userId));
            var entiry = await _repository.GetAsync(userId);
            return new AccessControl();
        }

        public async Task<IEnumerable<AccessControl>> GetPermissionsAsync()
        {
            var permissions = new List<AccessControl>();
            var entities = await _repository.GetAllAsync();
            if (!(null == entities))
                foreach (var entity in entities)
                    permissions.Add(new AccessControl { RoleId = entity.RoleId });
            return permissions;
        }

        public async Task SavePermissionAsync(AccessControl accessControl)
        {
            if (accessControl == default)
                throw new ArgumentException($"Access Control cannot be an empty/null", nameof(accessControl));
            await _repository.CreateAsync(new UserRole());
        }
    }
}