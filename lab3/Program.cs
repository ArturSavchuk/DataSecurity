using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;
using Newtonsoft.Json.Linq;

namespace lab3
{
    public class CasinoPlayer
    {
        private int id;
        public CasinoPlayer(int id) { this.id = id; }
        public void CreateAcc()
        {
            WebRequest webRequest = WebRequest.Create(String.Format("http://95.217.177.249/casino/createacc?id={0}", id.ToString()));
            WebResponse response = webRequest.GetResponse();

            using (Stream stream = response.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    string line = "";
                    while ((line = reader.ReadLine()) != null)
                    { 
                        Console.WriteLine(line);
                    }
                }
            }
            response.Close();
        }
        public long[] Get3RealNumbers()
        {
            long[] states = new long[3];
            for (int i = 0; i < 3; i++) {
                WebRequest webRequest = WebRequest.Create(String.Format("http://95.217.177.249/casino/playLcg?id={0}&bet=1&number=1", id));
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
            return states;
        }  
        public void MakeLuckyBet(long realmumber)
        {

        }
        
    }

    public class PRNG_LCG
    {
        private long multiplier;
        private long increment;
        private long modulus;

        //states for calculating multiplier and increment

        private long seed;

        public PRNG_LCG() { modulus = 4294967296;}
       
        public long modinv(long a, long modulus)
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
        public void crack_multiplier(long[] states, long modulus)
        {
            long difference = states[2] - states[1];
            if (difference < 0)
            {
                difference += modulus;
            }
            multiplier = (difference * modinv((states[1] - states[0]), modulus)) % modulus;

        }
        public void crack_increment(long[] states, long modulus, long multiplier)
        {
            increment = (modulus - ((states[0] * multiplier) % modulus) + states[1]) % modulus;
        }
        public void init(long[] states)
        {
            seed = states[states.Length - 1];
            crack_multiplier(states, modulus);
            crack_increment(states, modulus, multiplier);
        }
        public long genNext()
        {
           
            seed =  ((multiplier * seed + increment) % modulus);
            return seed;
        }
    }
    static class Program
    {

        static void Main(string[] args)
        {
            //    //modulus = 2^32 = 4294967296
            long[] states = { 3848296624, 4007236687, 2320102754 };

            PRNG_LCG pRNG_LCG = new PRNG_LCG();
            pRNG_LCG.init(states);
            Console.WriteLine(pRNG_LCG.genNext());
            
        }
    }
}

