using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace PasswordManager
{
    internal class AccountCard : Button
    {
        public Account Account { get; set; }
        public event EventHandler<AccountCardEventArgs>? CardClicked;

        public AccountCard(Account account)
        {
            Account = account;
            Init();
        }

        private void Init()
        {
            Click += AccountCard_Click;

            HorizontalContentAlignment = HorizontalAlignment.Left;
            Padding = new Thickness(0, 5, 0, 5);
            Height = 30;
            BorderThickness = new Thickness(0);
            Background = ColorHelper.GetColor("#efefef");

            ColumnDefinition columnAuto = new()
            {
                Width = GridLength.Auto
            };
            ColumnDefinition columnStar = new()
            {
                Width = new GridLength(1, GridUnitType.Star)
            };

            Grid grid = new();
            grid.ColumnDefinitions.Add(columnAuto);
            grid.ColumnDefinitions.Add(columnStar);

            Image image = new()
            {
                Source = new BitmapImage(new Uri($"{Directory.GetCurrentDirectory()}/images/{Account.ImagePath}")),
                Margin = new Thickness(10, 0, 10, 0)
            };
            image.SetValue(Grid.ColumnProperty, 0);

            TextBlock textBlock = new()
            {
                Text = Account.AppName,
                VerticalAlignment = VerticalAlignment.Center

            };
            textBlock.SetValue(Grid.ColumnProperty, 1);

            grid.Children.Add(image);
            grid.Children.Add(textBlock);

            AddChild(grid);
        }

        private void OnCardClick()
        {
            CardClicked?.Invoke(this, new AccountCardEventArgs(Account));
        }

        private void AccountCard_Click(object sender, RoutedEventArgs e)
        {
            OnCardClick();
        }
    }
}
