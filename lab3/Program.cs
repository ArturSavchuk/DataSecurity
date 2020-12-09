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

        public int GetId()
        {
            return this.id;
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

        public int MakeLuckyMTBet(long realNumber)
        {
            int money = 0;
            WebRequest webRequest = WebRequest.Create(String.Format("http://95.217.177.249/casino/playMt?id={0}&bet=500&number={1}", this.id, realNumber));
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

        public long GetRealNumber()
        {
            long realNum = 0;
                WebRequest webRequest = WebRequest.Create(String.Format("http://95.217.177.249/casino/playMt?id={0}&bet=1&number=1", id));
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
                            realNum = (long)test.realNumber;
                        }
                    }
                }
                response.Close();
            return realNum;
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

    public class MersenneTwister
	{
		const int MERS_N = 624;
		const int MERS_M = 397;
		const int MERS_U = 11;
		const int MERS_S = 7;
		const int MERS_T = 15;
		const int MERS_L = 18;
		const uint MERS_A = 0x9908B0DF;
		const uint MERS_B = 0x9D2C5680;
		const uint MERS_C = 0xEFC60000;

		uint[] mt = new uint[MERS_N];		   // state vector
		uint mti;							 // index into mt

		private MersenneTwister() { }
		public MersenneTwister(uint seed)
		{		// constructor
			RandomInit(seed);
		}
		public void RandomInit(uint seed)
		{
			mt[0] = seed;
			for (mti = 1; mti < MERS_N; mti++)
				mt[mti] = (1812433253U * (mt[mti - 1] ^ (mt[mti - 1] >> 30)) + mti);
		}
		public void RandomInitByArray(uint[] seeds)
		{
			// seed by more than 32 bits
			uint i, j;
			int k;
			int length = seeds.Length;
			RandomInit(19650218U);
			if (length <= 0) return;
			i = 1; j = 0;
			k = (MERS_N > length ? MERS_N : length);
			for (; k != 0; k--)
			{
				mt[i] = (mt[i] ^ ((mt[i - 1] ^ (mt[i - 1] >> 30)) * 1664525U)) + seeds[j] + j;
				i++; j++;
				if (i >= MERS_N) { mt[0] = mt[MERS_N - 1]; i = 1; }
				if (j >= length) j = 0;
			}
			for (k = MERS_N - 1; k != 0; k--)
			{
				mt[i] = (mt[i] ^ ((mt[i - 1] ^ (mt[i - 1] >> 30)) * 1566083941U)) - i;
				if (++i >= MERS_N) { mt[0] = mt[MERS_N - 1]; i = 1; }
			}
			mt[0] = 0x80000000U; // MSB is 1; assuring non-zero initial array
		}
		public int IRandom(int min, int max)
		{
			// output random integer in the interval min <= x <= max
			int r;
			r = (int)((max - min + 1) * Random()) + min; // multiply interval with random and truncate
			if (r > max)
				r = max;
			if (max < min)
				return -2147483648;
			return r;
		}
		public double Random()
		{
			// output random float number in the interval 0 <= x < 1
			uint r = BRandom(); // get 32 random bits
			if (BitConverter.IsLittleEndian)
			{
				byte[] i0 = BitConverter.GetBytes((r << 20));
				byte[] i1 = BitConverter.GetBytes(((r >> 12) | 0x3FF00000));
				byte[] bytes = { i0[0], i0[1], i0[2], i0[3], i1[0], i1[1], i1[2], i1[3] };
				double f = BitConverter.ToDouble(bytes, 0);
				return f - 1.0;
			}
			return r * (1.0/(0xFFFFFFFF + 1.0));
		}
		public uint BRandom()
		{
			// generate 32 random bits
			uint y;

			if (mti >= MERS_N)
			{
				const uint LOWER_MASK = 2147483647;
				const uint UPPER_MASK = 0x80000000;
				uint[] mag01 = { 0, MERS_A };

				int kk;
				for (kk = 0; kk < MERS_N - MERS_M; kk++)
				{
					y = (mt[kk] & UPPER_MASK) | (mt[kk + 1] & LOWER_MASK);
					mt[kk] = mt[kk + MERS_M] ^ (y >> 1) ^ mag01[y & 1];
				}

				for (; kk < MERS_N - 1; kk++)
				{
					y = (mt[kk] & UPPER_MASK) | (mt[kk + 1] & LOWER_MASK);
					mt[kk] = mt[kk + (MERS_M - MERS_N)] ^ (y >> 1) ^ mag01[y & 1];
				}

				y = (mt[MERS_N - 1] & UPPER_MASK) | (mt[0] & LOWER_MASK);
				mt[MERS_N - 1] = mt[MERS_M - 1] ^ (y >> 1) ^ mag01[y & 1];
				mti = 0;
			}

			y = mt[mti++];

			// Tempering (May be omitted):
			y ^= y >> MERS_U;
			y ^= (y << MERS_S) & MERS_B;
			y ^= (y << MERS_T) & MERS_C;
			y ^= y >> MERS_L;
			return y;
		}
	}


static class Program
    {

        static void Main(string[] args)
        {
            
            PRNG_LCG pRNG_LCG = new PRNG_LCG();
            CasinoPlayer casinoPlayer = new CasinoPlayer(7920);
            casinoPlayer.CreateAcc();
            long seed = DateTimeOffset.UtcNow.ToUnixTimeSeconds();

            //pRNG_LCG.init(casinoPlayer.Get3RealNumbers());
            //while (!casinoPlayer.MakeTestBet(pRNG_LCG.genNext()))
            //{
            //    pRNG_LCG.init(casinoPlayer.Get3RealNumbers());
            //}

            //int money = 0;
            //while(money <= 10000000)
            //{
            //    money = casinoPlayer.MakeLuckyBet(pRNG_LCG.genNext());
            //}

            MersenneTwister mersenneTwister = new MersenneTwister((uint)seed);
            long nextNum = (long)mersenneTwister.BRandom();
            do
            {

                    int id = casinoPlayer.GetId();
                    id++;
                    casinoPlayer = new CasinoPlayer(id);
                    casinoPlayer.CreateAcc();
                    seed = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
                    mersenneTwister = new MersenneTwister((uint)seed);
                    nextNum = (long)mersenneTwister.BRandom();

            }
            while (casinoPlayer.GetRealNumber() != nextNum);

            //easy money

            int money = 0;
            while(money <= 1000000)
            {
                money = casinoPlayer.MakeLuckyMTBet(mersenneTwister.BRandom());
            }


        }
    }
}
