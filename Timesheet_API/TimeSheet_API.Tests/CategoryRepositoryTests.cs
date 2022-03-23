using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using Timesheet_API.Models.Data;
using Timesheet_API.Models.Models;
using Timesheet_API.Repositories.CategoryRepo;
using Xunit;

namespace TimeSheet_API.Repository.Tests
{
    public class CategoryRepositoryTests : RepositoryTests<Category>
    {
        public CategoryRepositoryTests()
        {
            options = new DbContextOptionsBuilder<timesheet_dbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
                .Options;
            context = new timesheet_dbContext(options);
            repository = AddItems(context);
        }

        public override CategoryRepository AddItems(timesheet_dbContext context)
        {
            context.Categories.Add(new Category()
            {
                Id = new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd9c200"),
                CategoryName = "Frontend"
            });

            context.Categories.Add(new Category()
            {
                Id = new Guid("815accac-fd5b-478a-a9d6-f171a2f6ae7f"),
                CategoryName = "Backend"
            });

            context.Categories.Add(new Category()
            {
                Id = new Guid("80af33f7-a832-4ef4-a323-cb12f736a589"),
                CategoryName = "Design"
            });

            context.SaveChanges();

            CategoryRepository categoryRepository = new CategoryRepository(context);
            return categoryRepository;
        }

        [Fact]
        public void Insert_DatabaseHasThreeCategories_ReturnsDatabaseWithFourCategories()
        {

            // Assert count
            IList<Category> categories = repository.GetAll();
            Assert.Equal(3, categories.Count);

            // Act
            repository.Insert(new Category()
            {
                Id = Guid.NewGuid(),
                CategoryName = "Test"
            });
            repository.Save();

            // Assert recount
            categories = repository.GetAll();
            Assert.NotNull(categories);
            Assert.Equal(4, categories.Count);

            // Delete In-memory database after test is finished
            context.Database.EnsureDeleted();
        }

        [Fact]
        public void Update_DatabaseHasObject_UpdateObjectProperties_ReturnsObjectWithUpdatedProperties()
        {
            // Arrange
            Guid guid = new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd9c200");

            // Assert before update
            Category original = repository.GetByID(guid);
            Assert.Equal("Frontend", original.CategoryName);

            // Act
            original.CategoryName = "Frontend Updated";
            repository.Update(original);
            repository.Save();

            // Assert after update
            Category changed = repository.GetByID(guid);
            Assert.Equal("Frontend Updated", changed.CategoryName);

            context.Database.EnsureDeleted();
        }
    }
}
