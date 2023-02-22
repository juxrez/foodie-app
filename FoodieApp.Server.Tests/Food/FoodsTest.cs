using FoodieApp.Server.Controllers;
using FoodieApp.Server.Services;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using Moq;

namespace FoodieApp.Server.Tests.Food
{
    public class Tests
    {

        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public async Task Should_Return_All_Foods()
        {
            var controller = new FoodsController();
            var foods = await controller.GetAllFoods();
            Assert.NotNull(foods);
            Assert.IsNotEmpty(foods);
        }

        [Test]
        public void Should_Return_Number_Of_Retries()
        {
            var mockDependency = new Mock<IDependency>();
            mockDependency.Setup(c => c.NumberOfRetries()).Returns(9);
            var service = new Service(mockDependency.Object);
            var result = service.GetNumberOfRetries(true);
            Assert.NotNull(result);
        }
    }
}