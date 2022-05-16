using System;
using System.Windows.Media.Imaging;

namespace PasswordManager
{
    public class AddAccountEventArgs : EventArgs
    {
        public string AppName { get; private set; }
        public string Username { get; private set; }
        public string Password { get; private set; }
        public string Url { get; private set; }
        public BitmapImage Image { get; private set; }

        public AddAccountEventArgs(string appName, string username, string password, string url, BitmapImage image)
        {
            AppName = appName;
            Username = username;
            Password = password;
            Url = url;
            Image = image;
        }
    }
}
