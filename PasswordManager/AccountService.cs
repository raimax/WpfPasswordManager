using CsvHelper;
using CsvHelper.Configuration;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace PasswordManager
{
    public class AccountService
    {
        private readonly string _file = "file.csv";

        public void AddAccount<T>(T c)
        {
            List<T> list = new()
            {
                c
            };

            using var stream = File.Open(_file, FileMode.Append);
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

        public List<Account> GetAccounts()
        {
            if (File.Exists(_file))
            {
                using var reader = new StreamReader(_file);
                using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);

                csv.Context.RegisterClassMap<AccountMap>();
                return csv.GetRecords<Account>().ToList();
            }

            return new List<Account>() { };
        }

        //public void WriteListToCsv<T>(List<T> list)
        //{
        //    using var writer = new StreamWriter(_file);
        //    using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
        //    csv.WriteRecords(list);
        //}

        private bool IsFileEmpty(FileStream file)
        {
            if (file.Length == 0) return true;

            return false;
        }
    }
}
