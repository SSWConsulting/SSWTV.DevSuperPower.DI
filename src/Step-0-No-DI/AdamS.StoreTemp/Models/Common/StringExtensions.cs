namespace AdamS.StoreTemp.Models.Common
{
    public static class StringExtensions
    {
        public static bool IsValidEmailAddress(this string emailAddress)
        {
            return !string.IsNullOrWhiteSpace(emailAddress);
        }
    }
}