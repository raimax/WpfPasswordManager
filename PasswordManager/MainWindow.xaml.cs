using System;
using System.Collections.ObjectModel;
using System.Windows;

namespace PasswordManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Account> Accounts { get; set; } = new();

        public MainWindow()
        {
            InitializeComponent();
            LoadAccounts();
        }

        private void LoadAccounts()
        {
            PanelAccountList.Children.Clear();

            foreach (Account account in Accounts)
            {
                PanelAccountList.Children.Add(new AccountCard(account));
            }
        }

        private void ButtonLogout_Click(object sender, RoutedEventArgs e)
        {
            WindowManager.ChangeWindow(this, new LoginWindow());
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void ButtonAddAccount_Click(object sender, RoutedEventArgs e)
        {
            AddAccountWindow addAccountWindow = new();
            addAccountWindow.FormSubmited += AddAccountWindow_FormSubmited;
            WindowManager.OpenWindow(addAccountWindow);
        }

        private void AddAccountWindow_FormSubmited(object? sender, AddAccountEventArgs e)
        {
            AddNewAccount(new Account(e.AppName, e.Username, e.Password, e.Url, e.Image));
            LoadAccounts();
        }

        private void AddNewAccount(Account account)
        {
            Accounts.Add(new Account(account.AppName, account.Username, account.Password, account.Url, account.Image));
        }
    }
}
