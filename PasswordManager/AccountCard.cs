using System.Windows;
using System.Windows.Controls;

namespace PasswordManager
{
    internal class AccountCard : StackPanel
    {
        public Account Account { get; set; }

        public AccountCard(Account account)
        {
            Account = account;
            Init();
        }

        private void Init()
        {
            Orientation = Orientation.Horizontal;
            VerticalAlignment = VerticalAlignment.Center;
            Height = 30;
            Image image = new()
            {
                Source = Account.Image,
                Margin = new Thickness(0, 0, 10, 0),
                Height = 25,
                Width = 25
            };
            Label label = new()
            {
                Content = Account.AppName
            };
            Children.Add(image);
            Children.Add(label);
        }
    }
}
