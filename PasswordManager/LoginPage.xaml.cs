using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace PasswordManager
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        private readonly AuthManager _authManager = new();

        public LoginPage()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            if (!InputsValid()) throw new Exception("Some fields are empty");

            try
            {
                string userFile = _authManager.Login(new Auth(LoginUsernameInput.Text, LoginPasswordInput.Text));
                File.Delete(userFile);
                WindowManager.OpenWindow(new MainWindow());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private bool InputsValid()
        {
            return
                !string.IsNullOrEmpty(LoginUsernameInput.Text) &&
                !string.IsNullOrEmpty(LoginPasswordInput.Text);
        }
    }
}
