using System.Windows.Media.Imaging;

namespace PasswordManager
{
    public class Account : AccountState
    {
        public string AppName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Url { get; set; }
        public BitmapImage Image { get; set; }

        public Account(string name, string username, string password, string url, BitmapImage image)
        {
            AppName = name;
            Username = username;
            Password = password;
            Image = image;
            Url = url;
        }
    }
}