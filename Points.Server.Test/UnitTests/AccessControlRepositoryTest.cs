using Exam.Grade.Repositories;
using FakeItEasy;
using FluentAssertions;
using Points.DataAccess;
using Points.DataAccess.Entities;
using Points.DataAccess.Facades;
using System;
using Xunit;

namespace Points.Server.Test.UnitTests
{
    [Trait("Category", "UnitTest")]
    public class AccessControlRepositoryTest
    {
        private readonly AccessControlRepository<AccessControlEntity> _repo;
        private readonly IDataAccessFacade<AccessControlEntity> _dataAccess; 
        public AccessControlRepositoryTest()
        {
            _dataAccess = A.Fake<IDataAccessFacade<AccessControlEntity>>();
            _repo = new AccessControlRepository<AccessControlEntity>(_dataAccess);
        }
        [Fact]
        public void CreateAccessControl_WithNullValue_ReturnsArumentNullException()
        {
            AccessControlEntity entity = null;

            Action act = () => _repo.Create(entity);

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void CreateAccessControl_WithEntity_DataAccessMustHaveCalled()
        {
            var entity = A.Fake<AccessControlEntity>();

            _repo.Create(entity);

            A.CallTo(() => _dataAccess.Create(A<DataAccessRequest<AccessControlEntity>>._)).MustHaveHappened();
        }


       
    }
}