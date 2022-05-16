using System.Windows;

namespace PasswordManager
{
    public static class WindowManager
    {
        public static void ChangeWindow(Window currentWindow, Window newWindow)
        {
            currentWindow.Visibility = Visibility.Hidden;
            newWindow.Show();
        }

        public static void OpenWindow(Window window)
        {
            window.Show();
        }
    }
}
