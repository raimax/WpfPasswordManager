using System;

namespace PasswordManager
{
    public class AccountCardEventArgs : EventArgs
    {
        public Account Account { get; set; }

        public AccountCardEventArgs(Account account)
        {
            Account = account;
        }
    }
}
