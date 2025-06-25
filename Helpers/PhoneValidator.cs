using System.Text.RegularExpressions;

namespace TheatreApp.Helpers
{
    public static class PhoneValidator
    {
        public static bool IsValid(string phone)
        {
            return Regex.IsMatch(phone, @"^\+?\d{8,13}$");
        }
    }
}