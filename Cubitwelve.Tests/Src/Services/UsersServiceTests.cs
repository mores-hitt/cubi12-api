using Cubitwelve.Src.DTOs.Models;
using Cubitwelve.Src.Models;
using Cubitwelve.Src.Repositories.Interfaces;
using Cubitwelve.Src.Services;
using Cubitwelve.Src.Services.Interfaces;
using FluentAssertions;
using Moq;

namespace Cubitwelve.Tests.Src.Services
{
    public class UsersServiceTests
    {
        private static Mock<IUnitOfWork> CreateIUnitOfWorkMock()
        {
            return new Mock<IUnitOfWork>();
        }

        private static Mock<IMapperService> CreateIMapperServiceMock()
        {
            return new Mock<IMapperService>();
        }

        private static Mock<IAuthService> CreateIAuthServiceMock()
        {
            return new Mock<IAuthService>();
        }

        private static List<User> CreateUsers()
        {
            var users = new List<User>();
            for (int i = 0; i < 10; i++)
            {
                var user = new User()
                {
                    Id = i,
                    Name = $"User {i}",
                    FirstLastName = $"User FirstLastName {i}",
                    SecondLastName = $"User SecondLastName {i}",
                    RUT = $"User RUT {i}",
                    Email = $"user{i}@users.cl",
                    HashedPassword = "$@8977||$$$%&/&$$$%13467&%$",
                    IsEnabled = true,
                    CareerId = i,
                    Career = new Career
                    {
                        Id = i,
                        Name = $"Career {i}",
                    },
                    RoleId = 1,
                    Role = new Role
                    {
                        Id = 1,
                        Name = "student",
                    }
                };
                users.Add(user);
            }
            return users;
        }

        private static List<UserDto> CreateUsersDto()
        {
            var usersDto = new List<UserDto>();
            for (int i = 0; i < 10; i++)
            {
                var user = new UserDto
                {
                    Id = i,
                    Name = $"User {i}",
                    FirstLastName = $"User FirstLastName {i}",
                    SecondLastName = $"User SecondLastName {i}",
                    RUT = $"User RUT {i}",
                    Email = $"user{i}@users.cl",
                    Career = new CareerDto
                    {
                        Id = i,
                        Name = $"Career {i}",
                    },
                };
                usersDto.Add(user);
            }
            return usersDto;
        }

        [Fact]
        public async Task GetAll_Users_ReturnListOfUserDto()
        {
            // Arrange
            var unitOfWorkMock = CreateIUnitOfWorkMock();
            var mapperServiceMock = CreateIMapperServiceMock();
            var authServiceMock = CreateIAuthServiceMock();
            var users = CreateUsers();
            var usersDto = CreateUsersDto();

            unitOfWorkMock.Setup(x => x.UsersRepository.GetAll()).ReturnsAsync(users);
            mapperServiceMock.Setup(x => x.MapList<User, UserDto>(users)).Returns(usersDto);


            IUsersService usersService = new UsersService(
                unitOfWorkMock.Object,
                mapperServiceMock.Object,
                authServiceMock.Object
            );
            // Act
            var result = await usersService.GetAll();

            // Assert
            result.Should().BeEquivalentTo(usersDto);
        }

        [Fact]
        public async Task GetAll_Users_ReturnListOfSameLength()
        {
            // Arrange
            var unitOfWorkMock = CreateIUnitOfWorkMock();
            var mapperServiceMock = CreateIMapperServiceMock();
            var authServiceMock = CreateIAuthServiceMock();
            var users = CreateUsers();
            var usersDto = CreateUsersDto();

            unitOfWorkMock.Setup(x => x.UsersRepository.GetAll()).ReturnsAsync(users);
            mapperServiceMock.Setup(x => x.MapList<User, UserDto>(users)).Returns(usersDto);


            IUsersService usersService = new UsersService(
                unitOfWorkMock.Object,
                mapperServiceMock.Object,
                authServiceMock.Object
            );
            // Act
            var result = await usersService.GetAll();

            // Assert
            result.Should().HaveCount(usersDto.Count);
        }

    }
}