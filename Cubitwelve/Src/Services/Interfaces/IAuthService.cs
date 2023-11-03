using Cubitwelve.Src.DTOs.Auth;

namespace Cubitwelve.Src.Services.Interfaces
{
    public interface IAuthService
    {
        /// <summary>
        /// Authenticates a user by attempting to log in using the provided credentials.
        /// </summary>
        /// <param name="loginRequestDto">A data transfer object containing login credentials.</param>
        /// <returns>
        /// A task that represents the asynchronous login operation and returns a <see cref="LoginResponseDto"/>.
        /// </returns>
        public Task<LoginResponseDto> Login(LoginRequestDto loginRequestDto);

        /// <summary>
        /// Registers a student using the provided registration information.
        /// </summary>
        /// <param name="registerStudentDto">A data transfer object containing student registration details.</param>
        /// <returns>
        /// A task that represents the asynchronous registration operation.
        /// Upon successful registration, the system automatically logs in the registered user.
        /// The returned <see cref="LoginResponseDto"/> contains information about the newly registered user's session.
        /// </returns>
        public Task<LoginResponseDto> Register(RegisterStudentDto registerStudentDto);

        /// <summary>
        /// Gets the email inside the JWT token identified as <see cref="ClaimTypes.Email"/> 
        /// </summary>
        /// <returns>email</returns>
        /// <exception cref="UnauthorizedAccessException">
        /// Thrown when the token do not contain <see cref="ClaimTypes.Email"/>
        /// </exception>
        public string GetUserEmailInToken();

        /// <summary>
        /// Gets the rolename inside the JWT token identified as <see cref="ClaimTypes.Role"/> 
        /// </summary>
        /// <returns>role</returns>
        /// <exception cref="UnauthorizedAccessException">
        /// Thrown when the token do not contain <see cref="ClaimTypes.Role"/>
        /// </exception>
        public string GetUserRoleInToken();

        public Task UpdatePassword(UpdatePasswordDto updatePasswordDto);

    }
}