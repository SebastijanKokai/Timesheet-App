using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using Timesheet_API.Models.Data;
using Timesheet_API.Models.Models;
using Timesheet_API.Repositories;
using Xunit;

namespace TimeSheet_API.Repository.Tests
{
    public class RepositoryTests<T> where T : class, IGenericObject
    {
        public Repository<T> repository;
        public DbContextOptions<timesheet_dbContext> options;
        public timesheet_dbContext context;

        public RepositoryTests()
        {
            options = new DbContextOptionsBuilder<timesheet_dbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
                .Options;
            context = new timesheet_dbContext(options);
            repository = AddItems(context);
        }

        public virtual Repository<T> AddItems(timesheet_dbContext context)
        {
            return repository;
        }

        [Fact]
        public void GetAll_DatabaseHasThreeObjects_ReturnsThreeObjects()
        {
            // Act
            IList<T> items = repository.GetAll();

            // Assert
            Assert.NotNull(items);
            Assert.Equal(3, items.Count);

            // Delete In-memory database after test is finished
            context.Database.EnsureDeleted();
        }

        [Fact]
        public void GetByID_DatabaseHasObject_ReturnsObjectWithExpectedId()
        {
            // Act
            T item = repository.GetByID(new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd9c200"));

            // Assert
            Assert.NotNull(item);
            Assert.True(item is T);

            context.Database.EnsureDeleted();
        }

        [Fact]
        public void Delete_DatabaseHasObject_DeletedObjectFromDatabase()
        {
            // Arrange
            Guid guid = new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd9c200");

            // Assert before delete
            IList<T> items = repository.GetAll();
            Assert.Contains(items, item => item.Id == guid);

            // Act
            repository.Delete(guid);
            repository.Save();

            // Assert after delete
            items = repository.GetAll();
            Assert.DoesNotContain(items, item => item.Id == guid);

            context.Database.EnsureDeleted();
        }
    }
}
