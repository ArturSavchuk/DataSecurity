using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.Net;
using System.IO;
using Newtonsoft.Json.Linq;

namespace lab3
{

    static class Program
    {
        public static long modinv(long a, long modulus)
        {
            if (modulus == 1) return 0;
            long m0 = modulus;
            (long x, long y) = (1, 0);

            while (a > 1)
            {
                long q = a / modulus;
                (a, modulus) = (modulus, a % modulus);
                (x, y) = (y, x - q * y);
            }
            return x < 0 ? x + m0 : x;
        }
        public static long crack_multiplier(long[] states, long modulus)
        {
            long difference = states[2] - states[1];
            if (difference < 0)
            {
                difference += modulus;
            }
            long multiplier = (difference * modinv((states[1] - states[0]), modulus)) % modulus;
            return multiplier;

        }
        public static long crack_increment(long[] states, long modulus, long multiplier)
        {
            long increment = (modulus - ((states[0] * multiplier) % modulus) + states[1]) % modulus;
            return increment;
        }

        static void Main(string[] args)
        {
            //    //modulus = 2^32 = 4294967296
            //    long[] states = { 3848296624, 4007236687, 2320102754};

            //    Console.WriteLine("a = "+ crack_multiplier(states, 4294967296));
            //    Console.WriteLine("c = "+ crack_increment(states, 4294967296, crack_multiplier(states, 4294967296)));

            //getting first 3 states for cracking
            long[] states = new long[3];
            for (int i = 0; i < 3; i++)
            {
                WebRequest webRequest = WebRequest.Create("http://95.217.177.249/casino/playLcg?id=1&bet=1&number=1");
                WebResponse response = webRequest.GetResponse();

                using (Stream stream = response.GetResponseStream())
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        string line = "";
                        while ((line = reader.ReadLine()) != null)
                        { 
                            dynamic test = JObject.Parse(line);
                            Console.WriteLine(test);
                            states[i] = (long)test.realNumber; 
                        }
                    }
                }
                response.Close();
            }

            for(int i = 0; i < 3; i++)
            {
                Console.WriteLine(states[i]);
            }





        }
    }
}

