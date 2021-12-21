using Points.Server.Repositories;
using FakeItEasy;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Points.DataAccess;
using Points.DataAccess.Entities;
using Points.DataAccess.Facades;
using System;
using Xunit;
using Points.Entities.Models;
using System.Threading.Tasks;

namespace Points.Server.Test.UnitTests
{
    [Trait("Category", "Unit Test")]
    public class AccessControlRepositoryTest
    {
        private readonly AccessControlRepository _repo;
        private readonly IDataAccessFacade<AccessControlEntity> _dataAccess;
        private readonly PointsDbContext _context;
        private readonly ILogger<AccessControlRepository> _logger;
        public AccessControlRepositoryTest()
        {
            _dataAccess = A.Fake<IDataAccessFacade<AccessControlEntity>>();
            _context = A.Fake<PointsDbContext>();
            _logger = A.Fake<ILogger<AccessControlRepository>>();
            _repo = new AccessControlRepository(_context, _logger);
        }
        [Fact]
        public async Task CreateAccessControl_WithNullValue_ReturnsArumentNullException()
        {
            UserRole entity = null;

            Action act = async () => await _repo.CreateAsync(entity)
            .ConfigureAwait(false);

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public async Task CreateAccessControl_WithEntity_DataAccessMustHaveCalled()
        {
            var entity = A.Fake<UserRole>();

            await _repo.CreateAsync(entity)
                .ConfigureAwait(false);

            A.CallTo(() => _dataAccess.Create(A<DataAccessRequest<AccessControlEntity>>._)).MustHaveHappened();
        }
    }
}