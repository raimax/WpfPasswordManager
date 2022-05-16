using Microsoft.Win32;
using System;
using System.Windows;
using System.Windows.Media.Imaging;

namespace PasswordManager
{
    /// <summary>
    /// Interaction logic for AddAccountWindow.xaml
    /// </summary>
    public partial class AddAccountWindow : Window
    {
        public event EventHandler<AddAccountEventArgs>? FormSubmited;
        private string ImageName;
        private string ImagePath;
        private readonly AccountService _accountService = new();

        public AddAccountWindow()
        {
            InitializeComponent();
        }

        private void ButtonBrowseForImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileDialog = new();
            fileDialog.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp; *.png)|*.jpg; *.jpeg; *.gif; *.bmp; *.png";

            if (fileDialog.ShowDialog() == true)
            {
                LabelAddAccountImage.Content = fileDialog.SafeFileName;
                LabelAddAccountImage.Visibility = Visibility.Visible;
                ImageName = fileDialog.SafeFileName;
                ImagePath = fileDialog.FileName;
                AddAccountImage.Source = new BitmapImage(new Uri(fileDialog.FileName));
            }
        }

        public void OnFormSubmit()
        {
            FileService.SaveFile(ImagePath, ImageName);
            FormSubmited?.Invoke(this, new AddAccountEventArgs(LabelAppName.Text, LabelUsername.Text, LabelPassword.Text, LabelUrl.Text, ImageName));

            _accountService.AddAccount(new Account(LabelAppName.Text, LabelUsername.Text, LabelPassword.Text, LabelUrl.Text, ImageName));

            Close();
        }

        private void ButtonAddAccount_Click(object sender, RoutedEventArgs e)
        {
            OnFormSubmit();
        }
    }
}
