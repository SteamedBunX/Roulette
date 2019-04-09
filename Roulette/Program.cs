using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roulette
{
    public static class ListExtention
    {

        public static string ToStringExtended<T>(this List<T> list)
        {
            return $"[ {string.Join(", ", list)} ]";
        }

    }

    public class Program
    {
        List<int> black;
        List<int> red;
        Random r;
        static void Main(string[] args)
        {
            Program program = new Program();
            program.Run();
        }

        public Program()
        {
            r = new Random();
            Processor.Color_Ini(out red, out black, ref r);
        }

        public void Run()
        {
            Welcome();
            bool continues = true;
            Console.Write("Press enter to start.");
            Console.ReadLine();
            bool skip = false;
            while (continues)
            {
                if (!skip)
                {
                    int resnum = r.Next(38); // 37 is for 00
                    Print_result(resnum);
                }
                skip = false;
                Console.WriteLine("If you would like to continue the next round, please press Enter.");
                Console.WriteLine("If you would like to reset the color, please enter R and press Enter.");
                Console.WriteLine("If you would like to exit, enter E and press Enter.");
                String c = Console.ReadLine();
                if (c == "E" || c == "e")
                {
                    continues = false;
                }
                if (c == "R" || c == "r")
                {
                    Processor.Color_Ini(out red, out black, ref r);
                    Console.WriteLine("The black numbers are:" + black.ToStringExtended());
                    Console.WriteLine("The red numbers are:" + red.ToStringExtended());
                    skip = true;
                }
            }
        }

        public void Print_result(int num)
        {
            //Special case for 00
            Processor.NumberResult(num);

            // Odd/Even
            Processor.OddOrEven(num);

            // Excludes 0 and 00 for the results
            if (num != 0 && num != 37)
            {
                // Red/Black
                Processor.ColorResult(num, ref black);

                // High/Low
                Processor.LowHigh(num);

                // Dozen
                Processor.Dozen(num);

                // Column
                Processor.Column(num);

                // Street
                Processor.Street(num);

                // 6 Number, since it's using multiple arraylists, move it to a seperate method
                Six_Numbers(num);

                // Split
                Split(num);

                // Corner
                Corner(num);

            }


        }



        public void Corner(int num)
        {
            List<int> group1 = new List<int>();
            List<int> group2 = new List<int>();
            List<int> group3 = new List<int>();
            List<int> group4 = new List<int>();
            Console.Write("Corner: ");
            if (!(num % 3 == 1) && !(num <= 3)) // Excluding first row and first column
            {
                group1.Add(num - 4);
                group1.Add(num - 3);
                group1.Add(num - 1);
                group1.Add(num);
            }
            if (!(num % 3 == 0) && !(num <= 3)) // Excluding first row and third column
            {
                group2.Add(num - 3);
                group2.Add(num - 2);
                group2.Add(num);
                group2.Add(num + 1);
            }
            if (!(num % 3 == 1) && !(num >= 34)) // Excluding last row and first column
            {
                group3.Add(num - 1);
                group3.Add(num);
                group3.Add(num + 2);
                group3.Add(num + 3);
            }
            if (!(num % 3 == 0) && !(num >= 34)) // Excluding last row and third column
            {
                group4.Add(num);
                group4.Add(num + 1);
                group4.Add(num + 3);
                group4.Add(num + 4);
            }
            Console.WriteLine();

        }

        public void Split(int num)
        {
            List<int> groupUP = new List<int>();
            List<int> groupLEFT = new List<int>();
            List<int> groupRIGHT = new List<int>();
            List<int> groupDOWN = new List<int>();
            Console.Write("Split: ");
            if (!(num <= 3)) // Excluding first row
            {
                groupUP.Add(num - 3);
                groupUP.Add(num);
            }
            if (!(num % 3 == 1)) // Excluding first column
            {
                groupLEFT.Add(num - 1);
                groupLEFT.Add(num);
            }
            if (!(num % 3 == 0)) // Excluding third column
            {
                groupRIGHT.Add(num);
                groupRIGHT.Add(num + 1);
            }
            if (!(num >= 34)) // Excluding last row
            {
                groupDOWN.Add(num);
                groupDOWN.Add(num + 3);
            }
        }

        public void Six_Numbers(int num)
        {
            List<int> group1 = new List<int>();
            List<int> group2 = new List<int>();
            Console.Write("Double Row: ");
            if (num >= 4)
            {
                int begin = (num + 2) / 3 * 3 - 5;
                for (int i = 0; i <= 5; i++)
                { group1.Add(begin + i); }
            }
            if (num <= 33)
            {
                int begin = (num + 2) / 3 * 3 - 2;
                for (int i = 0; i <= 5; i++)
                { group2.Add(begin + i); }
            }

            Console.WriteLine();

        }

        public bool Is_black(int num)
        {
            if (black.Contains(num))
                return true;
            return false;
        }

        public void Welcome() // Prints the welcome massage
        {
            Console.WriteLine("Welcome to the game of Roulette!");
            Console.WriteLine("For this table: ");
            Console.WriteLine("The black numbers are:" + black.ToStringExtended());
            Console.WriteLine("The red numbers are:" + red.ToStringExtended());
        }



    }
}
