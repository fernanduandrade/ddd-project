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
        [Fact(DisplayName="Criar um usuário e o id deve ser igual a 2")]
        public void CreateUserTest()
        {
            // Arrange Context
            var repository = new Mock<IBaseRepository<Users>>().Object;
            var business = new BaseService<Users>(repository);
            var user = new Users()
            {
                Id= 2,
                Email = "onanduandrade@gmail.com",
                Name = "Fernando",
                Password = "123654",
            };

            // Act
            var result = business.Add<UserValidator>(user);

            // Assert
            Assert.Equal(2, result.Id);
        }
    }
}
