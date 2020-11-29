using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;

namespace lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            string text2 = File.ReadAllText(@"C:\Users\artur\Desktop\text2.txt");
            byte[] textBytes = Enumerable.Range(0, text2.Length)
                    .Where(x => x % 2 == 0)
                    .Select(x => Convert.ToByte(text2.Substring(x, 2), 16))
                    .ToArray();
            Console.WriteLine(JoinTransposedStrings(DecryptTransposedPositions(TransposeChunksByKeyLength(GetKeyLenght(textBytes), textBytes))));
        }

        private static int GetHammingDistance(int XORresult)
        {
            string result = Convert.ToString(XORresult, 2);
            int dist = 0;
            for (int i = 0; i < result.Length; i++)
            {
                if (result[i] == '1')
                {
                    dist++;
                }
            }
            return dist;
        }
        private static List<List<byte>> GetChunks(byte[] text, int key_l)
        {
            List<List<byte>> chunks = new List<List<byte>>();
            List<byte> chunk = new List<byte>();

            for (int i = 0; i < text.Length; i++)
            {
                chunk.Add(text[i]);
                if (chunk.Count == key_l)
                {
                    chunks.Add(chunk);
                    chunk = new List<byte>();
                }
            }
            return chunks;
        }
        private static int GetKeyLenght(byte[] textBytes)
        {
            double mindist = Double.MaxValue;
            int key_l = 0;
            for (int i = 2; i < 20; i++)
            {
                List<List<byte>> chunks = GetChunks(textBytes, i);
                double distance = GetChunksAvHammingDistance(chunks);
                if (mindist > distance)
                {
                    mindist = distance;
                    key_l = i;
                }
            }
            return key_l;
        }
        private static double GetChunksAvHammingDistance(List<List<byte>> chunks)
        {
            double distance = 0.0;
            for (int i = 0; i < chunks.Count - 1; i++)
            {
                for (int j = 0; j < chunks[0].Count; j++)
                {
                    distance += GetHammingDistance(chunks[i][j] ^ chunks[i + 1][j]);
                }
            }
            return distance;
        }
        public static bool isEnglishLetter(char c) => (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z');
        private static double GetSquareCHi(string DecryptedString)
        {
            double[] expectedFreq = { 8.2, 1.5, 2.8, 4.3, 12.7, 2.2, 2.0, 6.1, 7.0, 0.2, 0.8, 4.0, 2.4, 6.7, 7.5, 1.9, 0.1, 6.0, 6.3, 9.1, 2.8, 1.0, 2.4, 0.2, 2.0, 0.1 };     
            int[] observedFreq = countFreq(DecryptedString);

            double chi = 0;
            int sum = 0;

            foreach (int freq in observedFreq)
                sum += freq;
            for (int i = 0; i < 26; i++)
                chi += Math.Pow(((1.0 * observedFreq[i] / 100) - (expectedFreq[i]/ 100.0)), 2.0) / (expectedFreq[i]/ 100.0);
            return chi;
        }

        public static int indexOfLetter(char c) => char.IsUpper(c) ? 65 : 97;
        public static int[] countFreq(string text)
        { //count occurences of every letter in the text
            int[] observedFreq = new int[26];
            foreach (char c in text)
                if (isEnglishLetter(c))//just English letters are counted
                    observedFreq[c - indexOfLetter(c)]++;   //subtract UNICODE of A or a so the range will be always between 0-25                                       

            return observedFreq;
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
        private static List<List<byte>> TransposeChunksByKeyLength(int keyLength, byte[] text)
        {
            List<List<byte>> chunks = new List<List<byte>>();
            for (int i = 0; i < keyLength; i++)
            {
                List<byte> chunk = new List<byte>();
                for (int j = i; j < text.Length; j += keyLength)
                {
                    chunk.Add(text[j]);
                }
                chunks.Add(chunk);
            }

            return chunks;
        }
        private static List<string> DecryptTransposedPositions(List<List<byte>> transposed)
        {
            List<string> DecryptedStrings = new List<string>();
            List<string> MostConcidenceStrings = new List<string>();
            string result = "";
            List<double> frequencieslist = new List<double>();
            for (int k = 0; k < transposed.Count; k++)
            {

                for (int i = 0; i < 256; i++)
                {

                    result = "";

                    foreach (var ch in transposed[k])
                    {
                        result += (char)(ch ^ i);
                    }
                    DecryptedStrings.Add(result);
                    frequencieslist.Add(GetSquareCHi(result));
                }

                MostConcidenceStrings.Add(DecryptedStrings[GetIndexOfMin(frequencieslist)]);
                DecryptedStrings = new List<string>();
                frequencieslist = new List<double>();
            }

            return MostConcidenceStrings;
        }
        private static string JoinTransposedStrings(List<string> DecryptedTransposedStrings)
        {
            string result = "";
            for (int j = 0; j < DecryptedTransposedStrings[0].Length; j++)
            {
                for (int k = 0; k < DecryptedTransposedStrings.Count; k++)
                {
                    try
                    {
                        result += DecryptedTransposedStrings[k][j].ToString();
                    }
                    catch (IndexOutOfRangeException)
                    {
                        return result;
                    }
                }
            }
            return result;
        }


    }

}   