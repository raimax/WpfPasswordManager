namespace PasswordManager
{
    public static class GlobalConfiguration
    {
        public static string IconPath { get; private set; } = @"C:\Users\Vartotojas\Projects\PasswordManager\PasswordManager\icons";
        public static Auth Auth { get; set; } = new Auth();
        public static string DataFileName { get; private set; } = "data.csv";
    }
}
