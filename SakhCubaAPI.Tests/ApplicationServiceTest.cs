using Contracts.Interfaces;
using Entities.Models;
using Moq;
using SakhCubaAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SakhCubaAPI.Tests
{
    public class ApplicationServiceTest
    {
        [Fact]
        public async void ApplicationIsNotNull()
        {
            //Arrange
            var mock = new Mock<IRepositoryWrapper>();
            mock.Setup(repo => repo.News.GetAllNewsAsync()).ReturnsAsync(GetTestNews());
            var service = new ApplicationService(null, mock.Object);

            //Act
            var result = await service.GetAllNewsAsync();

            //Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Equal(GetTestNews().Count(), result.Count());
        }

        private IEnumerable<News> GetTestNews()
        {
            var news = new List<News>
            {
                new() {Id = 1, Title = "SakhCuba", Body = "We are alive!", Date = DateTime.Now, Image = "001"},
                new() {Id = 2, Title = "Vlad", Body = "Vlados krutoy", Date = DateTime.Now.AddYears(1), Image = "002"},
                new() {Id = 3, Title = "Yana", Body = "Yanka prikolnaya", Date = DateTime.Now, Image = "003"},
                new() {Id = 4, Title = "Natasha", Body = "Love her", Date = DateTime.Now, Image = "004"}
            };

            return news;
        }
    }
}
