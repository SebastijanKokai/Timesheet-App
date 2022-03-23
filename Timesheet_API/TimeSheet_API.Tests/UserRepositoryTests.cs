using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using Timesheet_API.Models.Data;
using Timesheet_API.Models.Models;
using Timesheet_API.Repositories;
using Timesheet_API.Repositories.UserRepo;
using Xunit;

namespace TimeSheet_API.Repository.Tests
{
    public class UserRepositoryTests : RepositoryTests<User>
    {

        public UserRepositoryTests() : base()
        {
            options = new DbContextOptionsBuilder<timesheet_dbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
                .Options;
            context = new timesheet_dbContext(options);
            repository = AddItems(context);
        }

        public override Repository<User> AddItems(timesheet_dbContext context)
        {
            context.Roles.Add(new Role() { Id = new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd9c200"), RoleName = "Worker" });
            context.Roles.Add(new Role() { Id = new Guid("815accac-fd5b-478a-a9d6-f171a2f6ae7f"), RoleName = "Admin" });

            context.Users.Add(new User()
            {
                Id = new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd9c200"),
                RoleId = new Guid("815accac-fd5b-478a-a9d6-f171a2f6ae7f"),
                Email = "sebastijan@gmail.com",
                Username = "SebastijanUser",
                UserPassword = "hashashash",
                FirstName = "Sebastijan",
                LastName = "Kokai",
                HoursPerWeek = 40,
                UserStatus = "Active"
            });

            context.Users.Add(new User()
            {
                Id = new Guid("80af33f7-a832-4ef4-a323-cb12f736a589"),
                RoleId = new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd9c200"),
                Email = "petar@gmail.com",
                Username = "PetarUser",
                UserPassword = "hashashash",
                FirstName = "Petar",
                LastName = "Petrovic",
                HoursPerWeek = 20,
                UserStatus = "Active"
            });

            context.Users.Add(new User()
            {
                Id = new Guid("90ebfad0-877e-44db-853a-ab57b5dc96a1"),
                RoleId = new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd9c200"),
                Username = "AnaUser",
                Email = "ana@gmail.com",
                UserPassword = "hashashash",
                FirstName = "Ana",
                LastName = "Anic",
                HoursPerWeek = 40,
                UserStatus = "Inactive"
            });

            context.SaveChanges();

            UserRepository repository = new UserRepository(context);
            return repository;
        }

        [Fact]
        public void Insert_DatabaseHasThreeUsers_ReturnsDatabaseWithFourUsers()
        {
            // Assert count
            IList<User> users = repository.GetAll();
            Assert.Equal(3, users.Count);

            // Act
            repository.Insert(new User()
            {
                Id = new Guid("73d17793-8da1-468d-ad38-deef7640d8a4"),
                RoleId = new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd9c200"),
                Email = "test@gmail.com",
                Username = "Test",
                UserPassword = "hashashash",
                FirstName = "TestFirstName",
                LastName = "TestLastName",
                HoursPerWeek = 40,
                UserStatus = "Active"
            });
            repository.Save();

            // Assert recount
            users = repository.GetAll();
            Assert.NotNull(users);
            Assert.Equal(4, users.Count);

            // Delete In-memory database after test is finished
            context.Database.EnsureDeleted();
        }

        [Fact]
        public void Update_DatabaseHasObject_UpdateObjectProperties_ReturnsObjectWithUpdatedProperties()
        {
            // Arrange
            Guid guid = new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd9c200");

            // Assert before update
            User original = repository.GetByID(guid);
            Assert.Equal("Sebastijan", original.FirstName);

            // Act
            original.FirstName = "Sebastijan Updated";
            repository.Update(original);
            repository.Save();

            // Assert after update
            User changed = repository.GetByID(guid);
            Assert.Equal("Sebastijan Updated", changed.FirstName);

            context.Database.EnsureDeleted();
        }

        //[Fact]
        //public void CanDeleteCountry()
        //{
        //    using (var context = new timesheet_dbContext(options))
        //    {
        //        // Arrange
        //        CountryRepository countryRepository = new CountryRepository(context);
        //        Guid guid = new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd9c200");
        //        Country countryToDelete = countryRepository.GetByID(guid);

        //        // Assert before delete
        //        IList<Country> countries = countryRepository.GetAll();
        //        Assert.Contains(countries, item => item.Id == guid);

        //        // Act
        //        countryRepository.Delete(guid);
        //        countryRepository.Save();

        //        // Assert after delete
        //        countries = countryRepository.GetAll();
        //        Assert.DoesNotContain(countries, item => item.Id == guid);

        //        context.Database.EnsureDeleted();
        //    }

        //}
    }
}
