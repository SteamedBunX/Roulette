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
        }

        public void Run()
        {
            Processor.Color_Ini(out red, out black, ref r);
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
            EvenOrOdd(num);

            // Excludes 0 and 00 for the results
            if (num != 0 && num != 37)
            {
                // Red/Black
                Processor.ColorResult(num, ref black);

                // High/Low
                if (num <= 18)
                { Console.WriteLine("High/Low: LOW"); }
                else
                { Console.WriteLine("High/Low: HIGH"); }

                // Dozen
                if (num <= 12)
                { Console.WriteLine("Dozen : 1ST DOZEN"); }
                else if (num <= 24)
                { Console.WriteLine("Dozen : 2ND DOZEN"); }
                else
                { Console.WriteLine("Dozen : 3RD DOZEN"); }

                // Column
                if (num % 3 == 1)
                { Console.WriteLine("Column : 1ST COLUMN"); }
                else if (num % 3 == 2)
                { Console.WriteLine("Column : 2ND COLUMN"); }
                else
                { Console.WriteLine("Column : 3RD COLUMN"); }

                // Street
                int street = (num - 1) / 3 + 1;
                Console.WriteLine("Street: ROW " + street);

                // 6 Number, since it's using multiple arraylists, move it to a seperate method
                Six_Numbers(num);

                // Split
                Split(num);

                // Corner
                Corner(num);

            }


        }



        private static void EvenOrOdd(int num)
        {
            if (num % 2 == 1 && num != 37)
            { Console.WriteLine("Even/Odd: ODD"); }
            else
            { Console.WriteLine("Even/Odd: Evan"); }
        }

        public void Corner(int num)
        {
            ArrayList group1 = new ArrayList();
            ArrayList group2 = new ArrayList();
            ArrayList group3 = new ArrayList();
            ArrayList group4 = new ArrayList();
            Console.Write("Corner: ");
            if (!(num % 3 == 1) && !(num <= 3)) // Excluding first row and first column
            {
                group1.Add(num - 4);
                group1.Add(num - 3);
                group1.Add(num - 1);
                group1.Add(num);
                Console.Write(Print_ArrayList(group1));
            }
            if (!(num % 3 == 0) && !(num <= 3)) // Excluding first row and third column
            {
                group2.Add(num - 3);
                group2.Add(num - 2);
                group2.Add(num);
                group2.Add(num + 1);
                Console.Write(Print_ArrayList(group2));
            }
            if (!(num % 3 == 1) && !(num >= 34)) // Excluding last row and first column
            {
                group3.Add(num - 1);
                group3.Add(num);
                group3.Add(num + 2);
                group3.Add(num + 3);
                Console.Write(Print_ArrayList(group3));
            }
            if (!(num % 3 == 0) && !(num >= 34)) // Excluding last row and third column
            {
                group4.Add(num);
                group4.Add(num + 1);
                group4.Add(num + 3);
                group4.Add(num + 4);
                Console.Write(Print_ArrayList(group4));
            }
            Console.WriteLine();

        }

        public void Split(int num)
        {
            ArrayList groupUP = new ArrayList();
            ArrayList groupLEFT = new ArrayList();
            ArrayList groupRIGHT = new ArrayList();
            ArrayList groupDOWN = new ArrayList();
            Console.Write("Split: ");
            if (!(num <= 3)) // Excluding first row
            {
                groupUP.Add(num - 3);
                groupUP.Add(num);
                Console.Write(Print_ArrayList(groupUP));
            }
            if (!(num % 3 == 1)) // Excluding first column
            {
                groupLEFT.Add(num - 1);
                groupLEFT.Add(num);
                Console.Write(Print_ArrayList(groupLEFT));
            }
            if (!(num % 3 == 0)) // Excluding third column
            {
                groupRIGHT.Add(num);
                groupRIGHT.Add(num + 1);
                Console.Write(Print_ArrayList(groupRIGHT));
            }
            if (!(num >= 34)) // Excluding last row
            {
                groupDOWN.Add(num);
                groupDOWN.Add(num + 3);
                Console.Write(Print_ArrayList(groupDOWN));
            }
            Console.WriteLine();
        }

        public void Six_Numbers(int num)
        {
            ArrayList group1 = new ArrayList();
            ArrayList group2 = new ArrayList();
            Console.Write("Double Row: ");
            if (num >= 4)
            {
                int begin = (num + 2) / 3 * 3 - 5;
                for (int i = 0; i <= 5; i++)
                { group1.Add(begin + i); }
                Console.Write(Print_ArrayList(group1));
            }
            if (num <= 33)
            {
                int begin = (num + 2) / 3 * 3 - 2;
                for (int i = 0; i <= 5; i++)
                { group2.Add(begin + i); }
                Console.Write(Print_ArrayList(group2));
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
            Console.WriteLine("The black numbers are:" + Print_ArrayList(black));
            Console.WriteLine("The red numbers are:" + Print_ArrayList(red));
        }



    }
}
