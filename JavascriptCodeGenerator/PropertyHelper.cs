namespace JavascriptModelGenerator
{
    public static class PropertyHelper
    {
        public static string Format(string format)
        {
            return string.Format(@"""format"": ""{0}"",", format);
        }
    }
}
