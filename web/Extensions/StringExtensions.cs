namespace web.Extensions
{
    public static class StringExtensions
    {
        public static string Format(this string @string, params object[] parameters)
        {
            return string.Format(@string, parameters);
        }
    }
}