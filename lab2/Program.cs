using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
 
using System.Threading.Tasks;

namespace lab_2
{
    class Program
    {
        public class HexString
        {
            public byte[] _data;

            public HexString(byte[] data)
            {
                _data = data;
            }

            public HexString(string data)
            {
                _data = Enumerable.Range(0, data.Length)
                    .Where(x => x % 2 == 0)
                    .Select(x => Convert.ToByte(data.Substring(x, 2), 16))
                    .ToArray();
            }

            static public HexString operator ^(HexString LHS, HexString RHS)
            {
                return new HexString
                    (
                        LHS._data.Zip
                            (
                                RHS._data,
                                (a, b) => (byte)(a ^ b)
                            )
                        .ToArray()
                    );
            }

            public override string ToString()
            {
                string hex = BitConverter.ToString(_data);
                return hex.Replace("-", "");
            }
        }

        public static void CribDragging(HexString str1, HexString str2)
        {

            Console.WriteLine("Enter a word that might appear in one of the messages.");
            Console.WriteLine("To stop crib dragging enter exit()");
            string crib_word = String.Empty;
            while (true)
            {
                crib_word = Console.ReadLine();
                if(crib_word == "exit()")
                {
                    break;
                }
                HexString crib_word_hex = new HexString(String.Concat(crib_word.Select(x => ((int)x).ToString("x"))));
                HexString xored_strs = str1 ^ str2;
                string temp = BitConverter.ToString(xored_strs._data).Replace("-", "");
                int step = 0;
                for (int i = 0; i < xored_strs._data.Length * 2; i++)
                {
                    if ((i % 2) == 0 & i != 0)
                    {
                        step++;
                        HexString temp_hex = new HexString(temp);
                        if(temp_hex._data.Length < crib_word_hex._data.Length)
                        {
                            break;
                        }
                        HexString z = temp_hex ^ crib_word_hex;
                        Console.Write("Step " + step + ": ");
                        Console.WriteLine(Encoding.ASCII.GetString(z._data));
                        temp = temp.Remove(0, 2);
                    }
                }
            }
        }



        static void Main(string[] args)
        {
            string[] ciphertext = File.ReadAllLines(@"./../../ciphertext.txt");
            List<HexString> hexStrings = new List<HexString>();
            for (int i = 0; i < ciphertext.Length; i++)
            {
                hexStrings.Add(new HexString(ciphertext[i]));
            }
            int n = 0;
            foreach (var str in hexStrings)
            {
                Console.WriteLine(n.ToString() + ": " + str);
                n++;
            }
            Console.WriteLine("Enter number of first string for crib dragging");
            int first = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter number of second string for crib dragging");
            int second = Convert.ToInt32(Console.ReadLine());
            CribDragging(hexStrings[first], hexStrings[second]);



        }
    }
}
