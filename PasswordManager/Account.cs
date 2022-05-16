using CsvHelper.Configuration.Attributes;

namespace PasswordManager
{
    public class Account : AccountState
    {
        [Index(0)]
        public string AppName { get; set; }
        [Index(1)]
        public string Username { get; set; }
        [Index(2)]
        public string Password { get; set; }
        [Index(3)]
        public string Url { get; set; }
        [Index(4)]
        public string ImagePath { get; set; }

        public Account()
        {
        }

        public Account(string name, string username, string password, string url, string image)
        {
            AppName = name;
            Username = username;
            Password = password;
            ImagePath = image;
            Url = url;
        }
    }
}