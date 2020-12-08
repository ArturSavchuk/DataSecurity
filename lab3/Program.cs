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
        public int MakeLuckyBet(long realmumber)
        {
            int money = 0;
            WebRequest webRequest = WebRequest.Create(String.Format("http://95.217.177.249/casino/playLcg?id={0}&bet=500&number={1}", this.id, realmumber));
            WebResponse response = webRequest.GetResponse();
            using (Stream stream = response.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    string line = "";
                    while ((line = reader.ReadLine()) != null)
                    {
                        dynamic json = JObject.Parse(line);
                        money = json.account.money;
                        Console.WriteLine(json);
                    }
                }
            } 
            response.Close();
            return money;
        }
        public bool MakeTestBet(long realmumber)
        {
            string message = string.Empty;
            WebRequest webRequest = WebRequest.Create(String.Format("http://95.217.177.249/casino/playLcg?id={0}&bet=1&number={1}", this.id, realmumber));
            WebResponse response = webRequest.GetResponse();
            using (Stream stream = response.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    string line = "";
                    while ((line = reader.ReadLine()) != null)
                    {
                        dynamic json = JObject.Parse(line);
                        message = json.message;
                    }
                }
            }
            response.Close();
            return message != "You lost this time";
        }

    }
    public class PRNG_LCG
    {
        private long multiplier;//= 1664525;
        private long increment;// = 1013904223;
        private long modulus;

        private long seed;

        public PRNG_LCG() { modulus = 4294967296; }

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
            multiplier = ((difference * modinv((states[1] - states[0]), modulus)) % modulus);
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

            long new_seed = ((multiplier * seed + increment) % modulus);
            if (new_seed > 2144000000)
            {
                new_seed = (long)Math.IEEERemainder((multiplier * seed + increment), -modulus);
            }
            else if(new_seed < -2144000000)
            {
                new_seed = (long)Math.IEEERemainder((multiplier * seed + increment), modulus);
            }
            seed = new_seed;
            return new_seed;
        }
    }
    static class Program
    {

        static void Main(string[] args)
        {
            
            PRNG_LCG pRNG_LCG = new PRNG_LCG();
            CasinoPlayer casinoPlayer = new CasinoPlayer(12345);
            casinoPlayer.CreateAcc();

            pRNG_LCG.init(casinoPlayer.Get3RealNumbers());
            while (!casinoPlayer.MakeTestBet(pRNG_LCG.genNext()))
            {
                pRNG_LCG.init(casinoPlayer.Get3RealNumbers());
            }

              
            int money = 0;
            while(money <= 10000000)
            {
                money = casinoPlayer.MakeLuckyBet(pRNG_LCG.genNext());
            }
        }
    }
}
