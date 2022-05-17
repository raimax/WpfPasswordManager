using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace PasswordManager
{
    public class AuthManager
    {
        public string Login(Auth auth)
        {
            if (!File.Exists("encrypted." + auth.Username + ".csv")) throw new Exception("User doesn't exist");

            FileInfo fs = Encryption.DecryptFile("encrypted." + auth.Username + ".csv", auth.Password);

            using var reader = new StreamReader(auth.Username + ".csv");
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);

            try
            {
                Auth userInfo = csv.GetRecords<Auth>().ToList()[0];
                bool verified = BCrypt.Net.BCrypt.Verify(auth.Password, userInfo.Password);
            }
            catch (Exception)
            {
                throw new Exception("Wrong password");
            }

            GlobalConfiguration.Auth = auth;
            return auth.Username + ".csv";
        }

        public string Register(Auth auth)
        {
            if (File.Exists("encrypted." + auth.Username + ".csv"))
            {
                throw new Exception("Username already exists");
            }

            List<Auth> list = new()
            {
                auth
            };

            string file = auth.Username + ".csv";

            using var stream = File.Open(file, FileMode.Append);
            using var writer = new StreamWriter(stream);

            using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
            csv.WriteRecords(list);

            return file;
        }
    }
}
