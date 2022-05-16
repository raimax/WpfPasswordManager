using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

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

            MouseEnter += AccountCard_MouseEnter;
            MouseLeave += AccountCard_MouseLeave;

            Image image = new()
            {
                Source = new BitmapImage(new Uri(@$"{Directory.GetCurrentDirectory()}/images/{Account.ImagePath}")),
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

        private void AccountCard_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            Background = null;
        }

        private void AccountCard_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            Background = ColorHelper.GetColor("#fff");
        }
    }
}
