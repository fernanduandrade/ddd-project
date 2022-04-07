using Xunit;
using Moq;
using Domain.Interfaces;
using Domain.Entities;
using Service.Services;
using Service.Validators;

namespace ApiTest.UserTest
{
    public class UserTest
    {
        [Fact]
        public void CreateUserTest()
        {
            // Arrange Context
            var repository = new Mock<IBaseRepository<User>>().Object;
            var business = new BaseService<User>(repository);
            User user = new User();

            // Act
            user.SetId(2);
            user.Name = "Fernando";
            user.Email = "onanduandrade@gmail.com";
            user.Password = "123654";
            var result = business.Add<UserValidator>(user);
            // Assert
            Assert.Equal(2, result.id);
        }
    }
}
