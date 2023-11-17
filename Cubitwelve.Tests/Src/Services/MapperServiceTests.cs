using AutoMapper;
using Cubitwelve.Src.DTOs.Models;
using Cubitwelve.Src.Models;
using Cubitwelve.Src.Services;
using FluentAssertions;
using Moq;

namespace Cubitwelve.Tests.Src.Services
{
    public class MapperServiceTests
    {
        #region SETUP

        /// <summary>
        /// Creates a new Instance of User with default values and the given id
        /// </summary>
        /// <param name="id">Id to assign</param>
        /// <returns>User Created</returns>
        private static User CreateDefaultUser(int id)
        {
            return new User()
            {
                Id = id,
                Name = $"{id} NameTest",
                FirstLastName = $"{id} FirstLastNameTest",
                SecondLastName = $"{id} SecondLastNameTest",
                Email = $"{id} Email@Test.com",
                RUT = $"{id} RUT-Test",
                Career = new Career()
                {
                    Id = 1,
                    Name = "CareerTest",
                },
                // Not mapped properties
                HashedPassword = "Test",
                IsEnabled = true,
            };
        }

        /// <summary>
        /// Creates a new Instance of UserDto with default values and the given id
        /// </summary>
        /// <param name="id">Id to assign</param>
        /// <returns>UserDto Created</returns>
        private static UserDto CreateDefaultUserDto(int id)
        {
            return new UserDto()
            {
                Id = id,
                Name = $"{id} NameTest",
                FirstLastName = $"{id} FirstLastNameTest",
                SecondLastName = $"{id} SecondLastNameTest",
                Email = $"{id} Email@Test.com",
                RUT = $"{id} RUT-Test",
                Career = new CareerDto()
                {
                    Id = 1,
                    Name = "CareerTest",
                }
            };
        }

        /// <summary>
        /// Creates a new List of 2 Users with default values and id 1 and 2
        /// </summary>
        /// <returns>List of User created</returns>
        private static List<User> CreateDefaultUsersList()
        {
            int firstUserId = 1;
            int secondUserId = 2;
            var firstUser = CreateDefaultUser(firstUserId);
            var secondUser = CreateDefaultUser(secondUserId);
            var firstUserDto = CreateDefaultUserDto(firstUserId);
            var secondUserDto = CreateDefaultUserDto(secondUserId);
            return new List<User>() { firstUser, secondUser };
        }

        /// <summary>
        /// Creates a new List of 2 Users with default values and id 1 and 2
        /// </summary>
        /// <returns>List of UserDto created</returns>
        private static List<UserDto> CreateDefaultUserDtosList()
        {
            int firstUserId = 1;
            int secondUserId = 2;
            var firstUserDto = CreateDefaultUserDto(firstUserId);
            var secondUserDto = CreateDefaultUserDto(secondUserId);
            return new List<UserDto>() { firstUserDto, secondUserDto };
        }

        #endregion


        private static Mock<IMapper> CreateIMapperMock()
        {
            return new Mock<IMapper>();
        }

        [Fact]
        public void Map_Users_ReturnTypeOfUserDto()
        {
            // Arrange
            var user = CreateDefaultUser(1);
            var userDto = CreateDefaultUserDto(1);
            var mapperMock = CreateIMapperMock();
            mapperMock.Setup(m => m.Map<UserDto>(user)).Returns(userDto);

            var mapperService = new MapperService(mapperMock.Object);

            // Act
            var result = mapperService.Map<User, UserDto>(user);

            // Assert
            result.Should().BeOfType<UserDto>();
        }

        [Fact]
        public void Map_User_ReturnUserDto()
        {
            // Arrange
            int userId = 1; // Creates a UserId to assign in the instances through Provider methods
            var user = CreateDefaultUser(userId);
            var userDto = CreateDefaultUserDto(userId);

            var mapperMock = CreateIMapperMock();

            mapperMock.Setup(m => m.Map<UserDto>(user)).Returns(userDto);
            var mapperService = new MapperService(mapperMock.Object);

            // Act
            var result = mapperService.Map<User, UserDto>(user);

            // Assert
            result.Should().BeEquivalentTo(userDto);
        }

        [Fact]
        public void Map_UsersList_ReturnUserDtosList()
        {
            // Arrange
            var users = CreateDefaultUsersList();
            var usersDto = CreateDefaultUserDtosList();

            var mapperMock = CreateIMapperMock();

            mapperMock.Setup(m => m.Map<UserDto>(users[0])).Returns(usersDto[0]);
            mapperMock.Setup(m => m.Map<UserDto>(users[1])).Returns(usersDto[1]);

            var mapperService = new MapperService(mapperMock.Object);

            // Act
            var result = mapperService.MapList<User, UserDto>(users);

            // Assert
            result.Should().BeEquivalentTo(usersDto);
        }

        

    }
}