using System;
using System.Collections.Generic;
using System.Windows;

namespace PasswordManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Account> Accounts { get; set; } = new();
        private readonly AccountService _accountService = new();
        public AccountInformationPanel AccountInformationPanel { get; set; } = new();

        public MainWindow()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            LoadAccounts();
            RefreshAccountList();
        }

        private void LoadAccounts()
        {
            Accounts = _accountService.GetAccounts();
        }

        private void RefreshAccountList()
        {
            PanelAccountList.Children.Clear();

            foreach (Account account in Accounts)
            {
                AccountCard accountCard = new(account);
                accountCard.CardClicked += AccountCard_CardClicked;
                PanelAccountList.Children.Add(accountCard);
            }
        }

        private void AccountCard_CardClicked(object? sender, AccountCardEventArgs e)
        {
            AccountInformationPanel.Account = e.Account;
            AccountInformationGrid.Children.Clear();
            AccountInformationGrid.Children.Add(AccountInformationPanel);
            AccountInformationPanel.Update();
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
            AddNewAccount(new Account(e.AppName, e.Username, e.Password, e.Url, e.ImagePath));
            RefreshAccountList();
        }

        private void AddNewAccount(Account account)
        {
            Accounts.Add(new Account(account.AppName, account.Username, account.Password, account.Url, account.ImagePath));
        }
    }
}
