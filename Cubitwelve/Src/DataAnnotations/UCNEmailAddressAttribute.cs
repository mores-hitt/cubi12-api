using System.ComponentModel.DataAnnotations;
using Cubitwelve.Src.Common.Constants;

namespace Cubitwelve.Src.DataAnnotations
{
    public class UCNEmailAddressAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if (value is not string email) return false;

            var isValidEmail = new EmailAddressAttribute().IsValid(email);
            if (!isValidEmail) return false;

            try
            {
                var emailDomain = email.Split('@')[1];
                return RegularExpressions.UCNEmailDomainRegex().IsMatch(emailDomain);
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}