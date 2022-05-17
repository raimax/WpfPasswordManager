namespace PasswordManager
{
    public class Auth
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public Auth()
        {

        }

        public Auth(string username, string password)
        {
            Username = username;
            Password = password;
        }
    }
}
