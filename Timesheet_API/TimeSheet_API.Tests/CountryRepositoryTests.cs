using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using Timesheet_API.Models.Data;
using Timesheet_API.Models.Models;
using Timesheet_API.Repositories;
using Timesheet_API.Repositories.CountryRepo;
using TimeSheet_API.Repository.Tests;
using Xunit;

namespace TimeSheet_API.Repository.Tests
{
    public class CountryRepositoryTests : RepositoryTests<Country>
    {

        public CountryRepositoryTests()
        {
            options = new DbContextOptionsBuilder<timesheet_dbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
                .Options;
            context = new timesheet_dbContext(options);
            repository = AddItems(context);
        }

        public override Repository<Country> AddItems(timesheet_dbContext context)
        {
            context.Countries.Add(new Country()
            {
                Id = new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd9c200"),
                CountryName = "Serbia"
            });

            context.Countries.Add(new Country()
            {
                Id = new Guid("815accac-fd5b-478a-a9d6-f171a2f6ae7f"),
                CountryName = "Croatia"
            });

            context.Countries.Add(new Country()
            {
                Id = new Guid("80af33f7-a832-4ef4-a323-cb12f736a589"),
                CountryName = "Slovenia"
            });

            context.Countries.Add(new Country()
            {
                Id = new Guid("90ebfad0-877e-44db-853a-ab57b5dc96a1"),
                CountryName = "Greece",
                DeletedDate = DateTime.UtcNow
            });

            context.SaveChanges();

            CountryRepository repository = new CountryRepository(context);
            return repository;
        }

        [Fact]
        public void Insert_DatabaseHasThreeCountries_ReturnsDatabaseWithFourCountries()
        {

            // Assert count
            IList<Country> countries = repository.GetAll();
            Assert.Equal(3, countries.Count);

            // Act
            repository.Insert(new Country()
            {
                Id = Guid.NewGuid(),
                CountryName = "Italy"
            });
            repository.Save();

            // Assert recount
            countries = repository.GetAll();
            Assert.NotNull(countries);
            Assert.Equal(4, countries.Count);

            // Delete In-memory database after test is finished
            context.Database.EnsureDeleted();
        }

        [Fact]
        public void Update_DatabaseHasObject_UpdateObjectProperties_ReturnsObjectWithUpdatedProperties()
        {
            // Arrange
            Guid guid = new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd9c200");

            // Assert before update
            Country original = repository.GetByID(guid);
            Assert.Equal("Serbia", original.CountryName);

            original.CountryName = "Italy";
            // Act
            repository.Update(original);
            repository.Save();

            // Assert after update
            Country changed = repository.GetByID(guid);
            Assert.Equal("Italy", changed.CountryName);

            context.Database.EnsureDeleted();

        }
    }
}