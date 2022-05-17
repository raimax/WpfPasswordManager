using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace PasswordManager
{
    /// <summary>
    /// Interaction logic for RegisterPage.xaml
    /// </summary>
    public partial class RegisterPage : Page
    {
        private readonly AuthManager _authManager = new();

        public RegisterPage()
        {
            InitializeComponent();
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            if (InputsValid())
            {
                string passwordHash = BCrypt.Net.BCrypt.HashPassword(RegisterPasswordInput.Text);

                try
                {
                    string userFile = _authManager.Register(new Auth(RegisterUsernameInput.Text, passwordHash));
                    Encryption.EncryptFile(userFile, RegisterPasswordInput.Text);
                    File.Delete(userFile);

                    SuccessMessage.Visibility = Visibility.Visible;
                    ResetInputs();
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Some fields are empty or passwords do not match");
            }
        }

        private void ResetInputs()
        {
            RegisterUsernameInput.Text = "";
            RegisterPasswordInput.Text = "";
            RegisterRepeatPasswordInput.Text = "";
        }

        private bool InputsValid()
        {
            return
                !string.IsNullOrEmpty(RegisterUsernameInput.Text) &&
                !string.IsNullOrEmpty(RegisterPasswordInput.Text) &&
                (Equals(RegisterPasswordInput.Text, RegisterRepeatPasswordInput.Text));
        }
    }
}
