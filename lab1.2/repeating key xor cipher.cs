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
            string text2 = File.ReadAllText(@".\text2.txt");
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

            for(int i = 0; i < text.Length; i++)
            {
                chunk.Add(text[i]);
                if(chunk.Count == key_l)
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
        private static double GetConcQuotient(string text)
        {

            var english_freq = new List<double>() {
            0.08167, 0.01492, 0.02782, 0.04253, 0.12702, 0.02228, 0.02015,  // A-G
            0.06094, 0.06966, 0.00153, 0.00772, 0.04025, 0.02406, 0.06749,  // H-N
            0.07507, 0.01929, 0.00095, 0.05987, 0.06327, 0.09056, 0.02758,  // O-U
            0.00978, 0.02360, 0.00150, 0.01974, 0.00074                     // V-Z
            };

            var count = new List<double>();
            int ignored = 0;
            for (var i = 0; i < 26; i++) count.Add(0);

            for (var i = 0; i < text.Length; i++)
            {
                var c = text[i];
                if (c >= 65 && c <= 90)
                    count[c - 65]++;  // uppercase A-Z
                else if (c >= 97 && c <= 122)
                    count[c - 97]++;  // lowercase a-z
                else if (c >= 32 && c <= 126)
                    ignored++;        // numbers and punct.
                else if (!(c == 0x80 || c == 0x99 || c == 0xe2))
                    return float.MaxValue;
            }
            double chi2 = 0;
            int len = text.Length - ignored;
            if (len == 0)
            {
                return Double.MaxValue;
            }
            for (var i = 0; i < 26; i++)
            {
                var observed = count[i];
                double expected = len * english_freq[i];
                var difference = observed - expected;
                chi2 += difference * difference / expected;
            }
            return chi2;
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
            for (int k = 0; k < transposed.Count; k++) {
                
                for (int i = 0; i < 256; i++)
            {
               
                result = "";

                foreach (var ch in transposed[k])
                {
                    result += (char)(ch ^ i);
                }
                DecryptedStrings.Add(result);
                frequencieslist.Add(GetConcQuotient(result));
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
           for(int j = 0; j < DecryptedTransposedStrings[0].Length; j++)
              {
                 for(int k = 0; k < DecryptedTransposedStrings.Count; k++)
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