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
        public PasswordGenerator(int top100, int top100000, int random)
        {
            if (top100 + top100000 + random > 100) throw new Exception("Wrong percentage");
            this.top100percentage = top100;
            this.top100000percentage = top100000;
            this.random_persentage = random;

            top100passwords = File.ReadAllLines(@"../../top100commonusedpasswords.txt");
            top100000passwords = File.ReadAllLines(@"../../top100000commonusedpasswords.txt");
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
            //for(int i = 0; i < random_passwords; i++)
            //{

            //}
            return passwords;

        }
           
    }




    class Program
    {
        static void Main(string[] args)
        {
            PasswordGenerator passwordGenerator = new PasswordGenerator(10, 50, 10);
            List<string> l = passwordGenerator.GeneratePasswords(100);
            foreach(var ch in l)
            {
                Console.WriteLine(ch);
            }
        }
    }
}
