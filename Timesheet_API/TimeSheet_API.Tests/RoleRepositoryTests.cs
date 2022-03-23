using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using Timesheet_API.Models.Data;
using Timesheet_API.Models.Models;
using Timesheet_API.Repositories;
using Timesheet_API.Repositories.RoleRepo;
using Xunit;

namespace TimeSheet_API.Repository.Tests
{
    public class RoleRepositoryTests : RepositoryTests<Role>
    {

        public RoleRepositoryTests()
        {
            options = new DbContextOptionsBuilder<timesheet_dbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
                .Options;
            context = new timesheet_dbContext(options);
            repository = AddItems(context);
        }

        public override Repository<Role> AddItems(timesheet_dbContext context)
        {
            context.Roles.Add(new Role()
            {
                Id = new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd9c200"),
                RoleName = "Admin"
            });

            context.Roles.Add(new Role()
            {
                Id = new Guid("815accac-fd5b-478a-a9d6-f171a2f6ae7f"),
                RoleName = "Worker"
            });

            context.Roles.Add(new Role()
            {
                Id = new Guid("80af33f7-a832-4ef4-a323-cb12f736a589"),
                RoleName = "Manager"
            });

            context.SaveChanges();

            RoleRepository repository = new RoleRepository(context);
            return repository;
        }

        [Fact]
        public void Insert_DatabaseHasThreeRoles_ReturnsDatabaseWithFourRoles()
        {

            // Assert count
            IList<Role> roles = repository.GetAll();
            Assert.Equal(3, roles.Count);

            // Act
            repository.Insert(new Role()
            {
                Id = Guid.NewGuid(),
                RoleName = "Test"
            });
            repository.Save();

            // Assert recount
            roles = repository.GetAll();
            Assert.NotNull(roles);
            Assert.Equal(4, roles.Count);

            // Delete In-memory database after test is finished
            context.Database.EnsureDeleted();
        }

        [Fact]
        public void Update_DatabaseHasObject_UpdateObjectProperties_ReturnsObjectWithUpdatedProperties()
        {
            // Arrange
            Guid guid = new Guid("815accac-fd5b-478a-a9d6-f171a2f6ae7f");

            // Assert before update
            Role original = repository.GetByID(guid);
            Assert.Equal("Worker", original.RoleName);
            original.RoleName = "Worker Updated";
            // Act
            repository.Update(original);
            repository.Save();

            // Assert after update
            Role changed = repository.GetByID(guid);
            Assert.Equal("Worker Updated", changed.RoleName);

            context.Database.EnsureDeleted();

        }

    }
}
