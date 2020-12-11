using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace lab4
{
    class PasswordGenerator
    {
        private int top100percentage;
        private int top100000percentage;
        private int random_persentage;

        private string[] top100passwords;
        private string[] top100000passwords;
        private string[] most_common_words;
        public PasswordGenerator(int top100, int top100000, int random)
        {
            if (top100 + top100000 + random > 100) throw new Exception("Wrong percentage");
            this.top100percentage = top100;
            this.top100000percentage = top100000;
            this.random_persentage = random;

            top100passwords = File.ReadAllLines(@"../../top100commonusedpasswords.txt");
            top100000passwords = File.ReadAllLines(@"../../top100000commonusedpasswords.txt");
            most_common_words = File.ReadAllLines(@"../../mostcommonwords.txt");
        }
        public List<string> GeneratePasswords(int count)
        {
            int passwords_from_top100 = (count * top100percentage) / 100;
            int passwords_from_top100000 = (count * top100000percentage) / 100;
            int random_passwords = (count * random_persentage) / 100;
            int rest = 100 - passwords_from_top100 - passwords_from_top100000 - random_passwords;

            Random random = new Random(Guid.NewGuid().GetHashCode());
            
            List<string> passwords = new List<string>();
            for(int i = 0; i < passwords_from_top100; i++)
            {
                passwords.Add(top100passwords[random.Next(0, top100passwords.Length)]);
            }
            for(int i = 0; i < passwords_from_top100000; i++)
            {
                passwords.Add(top100000passwords[random.Next(0, top100000passwords.Length)]);
            }
            for(int i = 0; i < random_passwords; i++)
            {
                passwords.Add(this.GenRandomPassword(random.Next(1, 20)));
            }

            return passwords;

        }

        private string ChangeRegister(string pwd)
        {
            string new_pwd = String.Empty;
            for(int i = 0; i < pwd.Length; i++)
            {
                if (Char.IsUpper(pwd[i]))
                {
                   new_pwd += pwd.Replace(pwd[i], Char.ToLower(pwd[i]));
                }
                if (Char.IsLower(pwd[i]))
                {
                    new_pwd += pwd.Replace(pwd[i], Char.ToUpper(pwd[i]));
                }
            }
            return pwd;
        }
        private string GenRandomPassword(int length)
        {
            Random random = new Random(Guid.NewGuid().GetHashCode());
            string allowable_chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890!:$_";
            string password = string.Empty;
            for (int i = 0; i < length; i++)
            {
                password += allowable_chars[random.Next(0, allowable_chars.Length)];
            }
            return password;
        }
        private string ReplaceNumbers(string str)
        {
            Dictionary<char, int> pairs = new Dictionary<char, int>
            {
                ['0'] = 'A',
                ['1'] = 'B',
                ['2'] = 'C',
                ['3'] = 'D',
                ['4'] = 'E',
                ['5'] = 'F',
                ['6'] = 'G',
                ['7'] = 'H',
                ['8'] = 'I',
            };
            foreach (var pair in pairs)
                str = str.Replace(pair.Key, (char)pair.Value);
            return str;
        }
        public string GenHumanLikePassword()
        {
            string numbers = "1234567890";
            string password = String.Empty;
            Random random = new Random(Guid.NewGuid().GetHashCode());

            //combine 2 most common words
            password = most_common_words[random.Next(0, most_common_words.Length)] + most_common_words[random.Next(0, most_common_words.Length)];

            //add 5 numbers to password
            for(int i = 0; i < 5; i++)
            {
                password = password.Insert(random.Next(0, password.Length), numbers[random.Next(0, numbers.Length)].ToString());
            }
            //replace numbers 
            password = ReplaceNumbers(password);

            //add rand.next(0,10) numbers to the end 

            for(int i = 0; i < random.Next(0, 10); i++)
            {
                password += numbers[random.Next(0, numbers.Length)];
            }


            //change register 
            password = ChangeRegister(password);


            return password;
            

        }
           
    }




    class Program
    {
        static void Main(string[] args)
        {
            PasswordGenerator passwordGenerator = new PasswordGenerator(10, 50, 10);
            List<string> l = passwordGenerator.GeneratePasswords(100);

            for(int i = 0; i < 20; i++)
            {
                Console.WriteLine(passwordGenerator.GenHumanLikePassword());
            }
            
            
        }
    }
}
