using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roulette
{
    public static class Processor
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

        public static NumberSet Color(int num, ref List<int> blacks)
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

        public static int Street(int num)
        {
            int street = (num - 1) / 3 + 1;
            return street;
        }

        public static List<List<int>> Corner(int num)
        {
            List<List<int>> corners = new List<List<int>>();
            Console.Write("Corner: ");
            if (!(num % 3 == 1) && !(num <= 3)) // Excluding first row and first column
            {
                corners.Add(new List<int>());
                corners.Last().Add(num - 4);
                corners.Last().Add(num - 3);
                corners.Last().Add(num - 1);
                corners.Last().Add(num);
            }
            if (!(num % 3 == 0) && !(num <= 3)) // Excluding first row and third column
            {
                corners.Add(new List<int>());
                corners.Last().Add(num - 3);
                corners.Last().Add(num - 2);
                corners.Last().Add(num);
                corners.Last().Add(num + 1);
            }
            if (!(num % 3 == 1) && !(num >= 34)) // Excluding last row and first column
            {
                corners.Add(new List<int>());
                corners.Last().Add(num - 1);
                corners.Last().Add(num);
                corners.Last().Add(num + 2);
                corners.Last().Add(num + 3);
            }
            if (!(num % 3 == 0) && !(num >= 34)) // Excluding last row and third column
            {
                corners.Add(new List<int>());
                corners.Last().Add(num);
                corners.Last().Add(num + 1);
                corners.Last().Add(num + 3);
                corners.Last().Add(num + 4);
            }
            return corners;

        }

        public static List<List<int>> Split(int num)
        {
            List<List<int>> split = new List<List<int>>();
            Console.Write("Split: ");
            if (!(num <= 3)) // Excluding first row
            {
                split.Add(new List<int>());
                split.Last().Add(num - 3);
                split.Last().Add(num);
            }
            if (!(num % 3 == 1)) // Excluding first column
            {
                split.Add(new List<int>());
                split.Last().Add(num - 1);
                split.Last().Add(num);
            }
            if (!(num % 3 == 0)) // Excluding third column
            {
                split.Add(new List<int>());
                split.Last().Add(num);
                split.Last().Add(num + 1);
            }
            if (!(num >= 34)) // Excluding last row
            {
                split.Add(new List<int>());
                split.Last().Add(num);
                split.Last().Add(num + 3);
            }
            return split;
        }

        public static List<List<int>> Six_Numbers(int num)
        {
            List<List<int>> six_numbers = new List<List<int>>();
            Console.Write("Double Row: ");
            if (num >= 4)
            {
                six_numbers.Add(new List<int>());
                int begin = (num + 2) / 3 * 3 - 5;
                for (int i = 0; i <= 5; i++)
                { six_numbers.Last().Add(begin + i); }
            }
            if (num <= 33)
            {
                six_numbers.Add(new List<int>());
                int begin = (num + 2) / 3 * 3 - 2;
                for (int i = 0; i <= 5; i++)
                { six_numbers.Last().Add(begin + i); }
            }

            return six_numbers;
        }
    }
}
