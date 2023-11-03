using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Cubitwelve.Src.DataAnnotations
{
    public class RutAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            var rut = value?.ToString() ?? string.Empty;
            if (rut.Length != 12) return false;
            return ValidaRut(rut);
        }

        public static bool ValidaRut(string rut)
        {
            rut = rut.Replace(".", "").ToUpper();
            Regex expresion = new("^([0-9]+-[0-9K])$");
            string dv = rut.Substring(rut.Length - 1, 1);
            if (!expresion.IsMatch(rut))
            {
                return false;
            }
            char[] dash = { '-' };
            string[] splittedRut = rut.Split(dash);
            if (dv != Digito(int.Parse(splittedRut[0])))
                return false;
            return true;
        }

        public static string Digito(int rut)
        {
            int sum = 0;
            int multiplier = 1;
            while (rut != 0)
            {
                multiplier++;
                if (multiplier == 8)
                    multiplier = 2;
                sum += rut % 10 * multiplier;
                rut /= 10;
            }
            sum = 11 - (sum % 11);

            return sum switch
            {
                11 => "0",
                10 => "K",
                _ => sum.ToString(),
            };
        }
    }
}