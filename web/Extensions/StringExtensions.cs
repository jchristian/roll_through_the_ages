namespace web.Extensions
{
    public static class StringExtensions
    {
        public static string FormatWith(this string @string, params object[] parameters)
        {
            return string.Format(@string, parameters);
        }
    }
}