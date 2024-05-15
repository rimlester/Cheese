using Cheese.Server;
using Cheese.Server.Controllers;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CheeseTests
{
    /// <summary>
    /// These are more intergration tests than unit tests, as there isn't really any logic outside of db access
    /// No real need to go for DI with such a small system using sqlite - just recreate the dbcontext for each req
    /// </summary>
    public class Tests
    {

        /// <summary>
        /// Create a new instance for each call
        /// </summary>
        /// <returns></returns>
        CheeseController Controller() {
            var _dbContext = new CheeseDbContext("test.db");
            _dbContext.Database.EnsureCreated();
            return new CheeseController(_dbContext);
        }

        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public async Task AssertPostPutGetSuccess()
        {

            var id = Guid.NewGuid();
            var message =
            new Cheese.Server.Cheese()
            {
                Id = id,
                Name = "Tasty",
                Price = 2.1M,
                Description = "Bega",
                Url = "example.com/average.jpg"
            };
            
            var result = await Controller().PostCheese(message);


            var allItems = await Controller().GetCheeses();
            allItems.Value.First(x => x.Id == id).Should().BeEquivalentTo(message);

            var message2 =
                new Cheese.Server.Cheese()
                {
                    Id = id,
                    Name = "Colby",
                    Price = 2.1M,
                    Description = "HB",
                    Url = "example.com/average.jpg"
                };

            var patch = await Controller().PutCheese(id, message2);

            var single = await Controller().GetCheese(id);
            single.Value.Should().BeEquivalentTo(message2);

        }

        [Test]
        public async Task AssertPostDeleteSuccess()
        {
            var id = Guid.NewGuid();
            var message =
            new Cheese.Server.Cheese()
            {
                Id = id,
                Name = "Tasty",
                Price = 2,
                Description = "Bega",
                Url = "example.com/average.jpg"
            };


            var res = await Controller().PostCheese(message);

            (await Controller().GetCheese(id)).Value.Should().BeEquivalentTo(message);

            await Controller().DeleteCheese(id);

            (await Controller().GetCheeses()).Value.Should().HaveCount(0);

        }

        [TearDown]
        public void TearDown()
        {
            var _dbContext = new CheeseDbContext("test.db");
            _dbContext.Database.EnsureCreated();
            

            _dbContext.Database.EnsureDeleted();
            _dbContext.Dispose();
        }
    }
}