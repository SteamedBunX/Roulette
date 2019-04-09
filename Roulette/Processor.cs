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
    }
}
