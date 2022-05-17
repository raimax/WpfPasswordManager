using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace PasswordManager
{
    public class AccountService
    {
        public void AddAccount(Account account)
        {
            List<Account> list = new()
            {
                account
            };

            account.Password = Encryption.EncryptText(account.Password, GlobalConfiguration.Auth.Password);

            using var stream = File.Open($"{GlobalConfiguration.Auth.Username}." + GlobalConfiguration.DataFileName, FileMode.Append);
            using var writer = new StreamWriter(stream);

            if (!IsFileEmpty(stream))
            {
                var config = new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    HasHeaderRecord = false,
                };

                using var csv = new CsvWriter(writer, config);
                csv.Context.RegisterClassMap<AccountMap>();
                csv.WriteRecords(list);
            }
            else
            {
                using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
                csv.Context.RegisterClassMap<AccountMap>();
                csv.WriteRecords(list);
            }
        }

        public void AddAccounts(List<Account> accounts)
        {
            using var stream = File.Open($"{GlobalConfiguration.Auth.Username}." + GlobalConfiguration.DataFileName, FileMode.Create);
            using var writer = new StreamWriter(stream);

            List<Account> encryptedAccounts = EncryptAccountPasswords(accounts);

            using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
            csv.Context.RegisterClassMap<AccountMap>();
            csv.WriteRecords(encryptedAccounts);
        }

        public List<Account> GetAccounts()
        {
            if (File.Exists($"{GlobalConfiguration.Auth.Username}." + GlobalConfiguration.DataFileName))
            {
                using var reader = new StreamReader($"{GlobalConfiguration.Auth.Username}." + GlobalConfiguration.DataFileName);
                using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);

                csv.Context.RegisterClassMap<AccountMap>();
                List<Account> accounts = csv.GetRecords<Account>().ToList();

                return DecryptAccountPasswords(accounts);
            }

            return new List<Account>() { };
        }

        public void RemoveAccount(Account account)
        {
            List<Account> accounts = GetAccounts();

            int oldAccountIndex = accounts.FindIndex(a => a.AppName == account.AppName);

            accounts.RemoveAt(oldAccountIndex);

            AddAccounts(accounts);
        }

        public void UpdateAccount(Account account, Account updatedAccount)
        {
            List<Account> accounts = GetAccounts();

            int oldAccountIndex = accounts.FindIndex(a => a.AppName == account.AppName);

            if (oldAccountIndex == -1) throw new Exception("Can't update account, account not found");

            Account newAccount = new()
            {
                AppName = account.AppName,
                Username = updatedAccount.Username,
                Password = updatedAccount.Password,
                Url = updatedAccount.Url,
                ImagePath = account.ImagePath
            };

            accounts[oldAccountIndex] = newAccount;

            AddAccounts(accounts);
        }

        private bool IsFileEmpty(FileStream file)
        {
            if (file.Length == 0) return true;

            return false;
        }

        private List<Account> DecryptAccountPasswords(List<Account> accounts)
        {
            foreach (Account account in accounts)
            {
                account.Password = Encryption.DectyptText(account.Password, GlobalConfiguration.Auth.Password);
            }

            return accounts;
        }

        private List<Account> EncryptAccountPasswords(List<Account> accounts)
        {
            foreach (Account account in accounts)
            {
                account.Password = Encryption.EncryptText(account.Password, GlobalConfiguration.Auth.Password);
            }

            return accounts;
        }
    }
}
