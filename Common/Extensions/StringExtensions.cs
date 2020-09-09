namespace Common.Extensions
{
    public static class StringExtensions
    {
        public static bool IsNotNullOrEmpty(this string item) => !item.IsNullOrEmpty();
        public static bool IsNullOrEmpty(this string item) =>  string.IsNullOrEmpty(item);
    }
}
