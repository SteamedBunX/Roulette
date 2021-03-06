using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roulette
{


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
            Console.Clear();
            Console.WriteLine($"The black numbers are: {black.ToStringExtended()}");
            Console.WriteLine($"The red numbers are: {red.ToStringExtended()}");
            bool skip = false;
            while (continues)
            {
                if (!skip)
                {

                    int resnum = r.Next(38); // 37 is for 00
                    Processor.PrintResult(Processor.GetResult(resnum, ref black));
                }
                skip = false;
                Console.WriteLine("\nIf you would like to continue the next round, please press Enter.");
                Console.WriteLine("If you would like to reset the color, please enter R and press Enter.");
                Console.WriteLine("If you would like to exit, enter E and press Enter.");
                String c = Console.ReadLine();
                Console.Clear();
                if (c == "E" || c == "e")
                {
                    continues = false;
                }
                if (c == "R" || c == "r")
                {
                    Processor.Color_Ini(out red, out black, ref r);
                    skip = true;
                }
                Console.WriteLine($"The black numbers are: {black.ToStringExtended()}");
                Console.WriteLine($"The red numbers are: {red.ToStringExtended()}");
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
