namespace Domain
{
    public static class Constants
    {
        public static Settings Settings { get; set; }
    }

    public class Settings
    {
        public string SqlConnectionString { get; set; }

    }
}