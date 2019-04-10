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

            Model m = new Model();
            m.Number = Processor.NumberResult(num);
            m.OddEven = Processor.OddOrEven(num);

            // Excludes 0 and 00 for the results
            if (num != 0 && num != 37)
            {
                Processor.Color(num, ref black);
                Processor.LowHigh(num);
                Processor.Dozen(num);
                Processor.Column(num);
                Processor.Street(num);
                Processor.Six_Numbers(num);
                Processor.Split(num);
                Processor.Corner(num);
            }


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
