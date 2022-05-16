using CsvHelper.Configuration;

namespace PasswordManager
{
    public class AccountMap : ClassMap<Account>
    {
        public AccountMap()
        {
            Map(m => m.AppName);
            Map(m => m.Username);
            Map(m => m.Password);
            Map(m => m.Url);
            Map(m => m.ImagePath);
        }
    }
}
