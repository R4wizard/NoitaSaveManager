using System;

namespace NoitaSaveManager.Noita
{
    class PseudoRNG
    {
        const int SEED = 258024811;
        public double Seed { get; private set; }

        public static byte[] GetBytes(int seed, bool beta, int init = SEED)
        {
            return (new PseudoRNG(seed, beta, init)).GetBytes();
        }

        public PseudoRNG(int seed, bool beta = false, int init = SEED)
        {
            Seed = (double)(uint)init + seed;
            if (beta && Seed >= 2147483647)
                Seed *= 0.5;
            Get();
        }

        public PseudoRNG(double seed)
        {
            Seed = seed;
            Get();
        }

        public double Get()
        {
            Seed = ((int)Seed) * 16807 + ((int)Seed) / 127773 * -int.MaxValue;
            if (Seed < 0) Seed += int.MaxValue;
            return Seed / int.MaxValue;
        }

        public byte[] GetBytes()
        {
            var value = new byte[16];
            for (int i = 0; i < 4; i++)
            {
                byte[] bytes = BitConverter.GetBytes((int)(Get() * int.MinValue));
                Buffer.BlockCopy(bytes, 0, value, i * 4, 4);
            }
            return value;
        }
    }
}
