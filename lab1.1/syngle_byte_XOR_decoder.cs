using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = File.ReadAllText(@"C:\Users\artur\Desktop\text.txt");
            string decrypted_text = Decrypt(text);
            Console.WriteLine(decrypted_text);

        }
        private static string Decrypt(string text)
            {
                List<string> DecryptedStrings = new List<string>();
                string result = "";
                for (int i = 0; i < 256; i++)
                {
                    result = "";
                    foreach (char ch in text)
                    {
                        result += (char)(ch ^ i);
                    }
                    DecryptedStrings.Add(result);
                }
                return ChooseMoreConcidence(DecryptedStrings);
            }

        private static string ChooseMoreConcidence(List<string> DecryptedStrings)
            {
                Dictionary<char, double> english_freq = new Dictionary<char, double>()
                {
                    {'a', 0.08167 }, {'b', 0.01492 }, {'c', 0.02782 }, {'d', 0.04253 }, {'e', 0.12702 }, {'f', 0.02228 }, {'g', 0.02015 },
                    {'h', 0.06094 }, {'i', 0.06966 }, {'j', 0.00153 }, {'k', 0.00772 }, {'l', 0.04025 }, {'m', 0.02406 }, {'n', 0.06749},
                    {'o', 0.07507 }, {'p', 0.01929 }, {'q', 0.00095 }, {'r', 0.05987 }, {'s', 0.06327 }, {'t', 0.09056 }, {'u', 0.02758 },
                    {'v', 0.00978 }, {'w', 0.02360 }, {'x', 0.00150 }, {'y', 0.01974 }, {'z', 0.00074 }
                };


                List<double> quetients_list = new List<double>();

            
                for (int i = 0; i < DecryptedStrings.Count; i++)
                {
                            //letters count
                    int length = 0;
                    for (int j = 0; j < DecryptedStrings[i].Length; j++)
                        {
                            if (Char.IsLetter(DecryptedStrings[i][j]))
                            {
                                length++;
                            }
                        }

                     var freqs = DecryptedStrings[i]
                                .Where(c => Char.IsLetter(c) & c <= 122) // a-z
                                .GroupBy(c => Char.ToLower(c))
                                .ToDictionary(g => g.Key, g => (g.Count() / Convert.ToDouble(length))); //dictionary of frequencies
                    
                    double avarage_quetient = 0;

                    foreach (char ch in freqs.Keys)
                    {
                        avarage_quetient += Math.Abs(english_freq[ch] - freqs[ch]);
                    }
                    quetients_list.Add(avarage_quetient);
                }

                return DecryptedStrings[GetIndexOfMin(quetients_list)];

            }

        private static int GetIndexOfMin(List<double> quetients_list)
        {
            double min = quetients_list[0];
            int index = 0;
            for (int i = 0; i < quetients_list.Count; i++)
            {

                if (quetients_list[i] < min && quetients_list[i] != 0)
                {
                    min = quetients_list[i];
                    index = i;
                }
            }
            return index;
        }
    }
}
            