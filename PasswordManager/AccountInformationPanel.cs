using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace PasswordManager
{
    public class AccountInformationPanel : StackPanel
    {
        public Account Account { get; set; }

        public AccountInformationPanel()
        {
        }

        public void Update()
        {
            Children.Clear();
            MaxWidth = 300;

            Image image = new()
            {
                Source = new BitmapImage(new Uri($"{Directory.GetCurrentDirectory()}/images/{Account.ImagePath}")),
                Height = 50
            };

            Label appNameLabel = new()
            {
                Content = Account.AppName,
                FontSize = 18,
                HorizontalAlignment = HorizontalAlignment.Center
            };
            appNameLabel.SetValue(TextBlock.FontWeightProperty, FontWeights.Bold);

            Label usernameLabel = new()
            {
                Content = "Username"
            };

            TextBox usernameTextBox = CreateTextBox(Account.Username);

            Label passwordLabel = new()
            {
                Content = "Password"
            };

            TextBox passwordTextBox = CreateTextBox(
                Account.IsPasswordHidden ? "************" : Account.Password, Account.IsPasswordHidden);

            Label urlLabel = new()
            {
                Content = "Url"
            };

            TextBox urlTextBox = CreateTextBox(Account.Url);

            string toggleImage = Account.IsPasswordHidden ? "eye.png" : "hidden.png";
            string copyIcon = "copy.png";

            Button togglePasswordButton = new Button
            {
                Width = 24,
                Height = 24,
                Content = new Image
                {
                    Source = new BitmapImage(new Uri($"{GlobalConfiguration.IconPath}\\{toggleImage}")),
                    VerticalAlignment = VerticalAlignment.Center
                },
                Background = null,
                BorderThickness = new Thickness(0),
                Margin = new Thickness(0, -25, -225, 0),
            };

            Button copyUsernameButton = new Button
            {
                Width = 24,
                Height = 24,
                Content = new Image
                {
                    Source = new BitmapImage(new Uri($"{GlobalConfiguration.IconPath}\\{copyIcon}")),
                    VerticalAlignment = VerticalAlignment.Center
                },
                Background = null,
                BorderThickness = new Thickness(0),
                Margin = new Thickness(0, -25, -276, 0),
            };

            Button copyPasswordButton = new Button
            {
                Width = 24,
                Height = 24,
                Content = new Image
                {
                    Source = new BitmapImage(new Uri($"{GlobalConfiguration.IconPath}\\{copyIcon}")),
                    VerticalAlignment = VerticalAlignment.Center
                },
                Background = null,
                BorderThickness = new Thickness(0),
                Margin = new Thickness(0, -25, -276, 0),
            };

            Button copyUrlButton = new Button
            {
                Width = 24,
                Height = 24,
                Content = new Image
                {
                    Source = new BitmapImage(new Uri($"{GlobalConfiguration.IconPath}\\{copyIcon}")),
                    VerticalAlignment = VerticalAlignment.Center
                },
                Background = null,
                BorderThickness = new Thickness(0),
                Margin = new Thickness(0, -25, -276, 0),
            };

            togglePasswordButton.Click += TogglePasswordButton_Click;
            copyUsernameButton.Click += CopyUsernameButton_Click;
            copyPasswordButton.Click += CopyPasswordButton_Click;
            copyUrlButton.Click += CopyUrlButton_Click;

            Children.Add(image);
            Children.Add(appNameLabel);
            Children.Add(usernameLabel);
            Children.Add(usernameTextBox);
            Children.Add(copyUsernameButton);
            Children.Add(passwordLabel);
            Children.Add(passwordTextBox);
            Children.Add(togglePasswordButton);
            Children.Add(copyPasswordButton);
            Children.Add(urlLabel);
            Children.Add(urlTextBox);
            Children.Add(copyUrlButton);
        }

        private void CopyUrlButton_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(Account.Url);
        }

        private void CopyPasswordButton_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(Account.Password);
        }

        private void CopyUsernameButton_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(Account.Username);
        }

        private void TogglePasswordButton_Click(object sender, RoutedEventArgs e)
        {
            Account.IsPasswordHidden = !Account.IsPasswordHidden;
            Update();
        }

        private TextBox CreateTextBox(string text, bool isReadOnly = false)
        {
            TextBox textBox = new()
            {
                Text = text,
                Background = null,
                BorderThickness = new Thickness(0, 0, 0, 1),
                Padding = new Thickness(0, 0, 0, 3),
                IsReadOnly = isReadOnly
            };

            return textBox;
        }
    }
}
