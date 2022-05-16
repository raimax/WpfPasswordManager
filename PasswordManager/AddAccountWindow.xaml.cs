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
        private BitmapImage? UploadedImage;

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
                UploadedImage = new BitmapImage(new Uri(fileDialog.FileName));
                AddAccountImage.Source = UploadedImage;
            }
        }

        public void OnFormSubmit()
        {
            if (FormSubmited != null)
            {
                FormSubmited(this, new AddAccountEventArgs(LabelAppName.Text, LabelUsername.Text, LabelPassword.Text, LabelUrl.Text, UploadedImage));
            }

            Close();
        }

        private void ButtonAddAccount_Click(object sender, RoutedEventArgs e)
        {
            OnFormSubmit();
        }
    }
}
