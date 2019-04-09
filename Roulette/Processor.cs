using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roulette
{
    static class Processor
    {
        public static void Color_Ini(out List<int> red, out List<int> black, ref Random r)
        {
            int i = 1;
            black = new List<int>();
            red = new List<int>();
            while (black.Count < 18)
            {
                if (i >= 36)
                {
                    i = 1;
                }
                if (!black.Contains(i))
                {
                    if (r.NextDouble() < 0.5)
                    {
                        black.Add(i);
                    }
                }
                i++;
            }
            black.Sort();
            for (int j = 1; j <= 36; j++)
            {
                if (!black.Contains(j))
                {
                    red.Add(j);
                }
            }
        }

        public static string NumberResult(int num)
        {
            if (num == 37)
            { return "00"; }
            else
            { return $"{num:00}"; }
        }

        public static NumberSet ColorResult(int num, ref List<int> blacks)
        {
            if (blacks.Contains(num))
            { return NumberSet.Black; }
            else
            { return NumberSet.Red; }
        }

        public static NumberSet OddOrEven(int num)
        {
            if (num % 2 == 1 && num != 37)
            { return NumberSet.Odd; }
            else
            { return NumberSet.Even; }
        }

        public static NumberSet LowHigh(int num)
        {
            if (num <= 18)
            { return NumberSet.Low; }
            else
            { return NumberSet.High; }
        }

        public static NumberSet Dozen(int num)
        {
            if (num <= 12)
            { return NumberSet.First; }
            if (num <= 24)
            { return NumberSet.Second; }
            return NumberSet.Third;
        }

        public static NumberSet Column(int num)
        {
            if (num % 3 == 1)
            { return NumberSet.First; }
            if (num % 3 == 2)
            { return NumberSet.Second; }
            return NumberSet.Third;
        }
    }
}
