namespace QuenchYourThirst.Utilities
{
    public class Functions
    {
        public static string changeStringToString(string name)
        {
            return SlugGenerator.SlugGenerator.GenerateSlug(name);
        }
    }
}
