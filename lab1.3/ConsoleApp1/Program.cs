using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Timers;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleApp1
{
    class Program
    {
        private static string DecodeSubstitution(string input, string keyAlphabet)
        {
           string Alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
           string output = string.Empty;

            if (Alphabet.Length != keyAlphabet.Length)
                return output;

            for (int i = 0; i < input.Length; ++i)
            {
                int oldCharIndex = Alphabet.IndexOf(char.ToLower(input[i]));

                if (oldCharIndex >= 0)
                    output += char.IsUpper(input[i]) ? char.ToUpper(keyAlphabet[oldCharIndex]) : keyAlphabet[oldCharIndex];
                else
                    output += input[i];
            }

            return output;
        }



        static class GeneticAlgorithm
        {
            private static string Alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            public static int keyLenght = 26;
                
            public static List<string> GeneratePopulation(int pop_size)
            {
                List<string> population = new List<string>();
                for (int i = 0; i < pop_size; i++)
                {
                    population.Add(GenerateRandomKey());
                }
                return population;
            }


            private static string GenerateRandomKey()
            {
                
                string key = String.Empty;
                char ch;

                
                Random random = new Random(Guid.NewGuid().GetHashCode());
                for (int i = 0; i < Alphabet.Length; i++)
                {
                    
                    do
                    {
                        ch = Alphabet[random.Next(Alphabet.Length)];
                    } 
                    while (key.Contains(ch));
                    key += ch;
                }
                return key;
            }

            //public static string Crossover(string key1, string key2)
            //{

            //}

            //public static string MakeMutation(string key)
            //{

            //}



        }


        static void Main()
        {
            string text = File.ReadAllText(@"C:\Users\artur\Desktop\text.txt");
            List<string> test = GeneticAlgorithm.GeneratePopulation(200);
            foreach(var str in test)
            {
                Console.WriteLine(str);
            }

            

        }
    }
}


