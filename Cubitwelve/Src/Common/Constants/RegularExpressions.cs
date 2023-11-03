namespace Cubitwelve.Src.Common.Constants
{
    public static class RegularExpressions
    {
        /// <summary>
        /// Regex for password validation, must have at least one letter and one number
        /// </summary>
        public const string PasswordValidation = @"^(?=.*[a-zA-Z])(?=.*\d).+$";
    }
}