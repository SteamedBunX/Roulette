using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roulette
{
    class Program
    {
        ArrayList black = new ArrayList();
        ArrayList red = new ArrayList();
        static void Main(string[] args)
        {
            Program program = new Program();
            program.Initiate_Color();
            program.Welcome();
            bool continues = true;
            Console.Write("Press enter to start.");
            Console.ReadLine();
            Random r = new Random();
            bool skip = false;
            while (continues)
            {
                if(!skip)
                { 
                    int resnum = r.Next(38); // 37 is for 00
                    program.print_result(resnum);
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
                    program.Initiate_Color();
                    Console.WriteLine("The black numbers are:" + program.Print_ArrayList(program.black));
                    Console.WriteLine("The red numbers are:" + program.Print_ArrayList(program.red));
                    skip = true;
                }
            }
        }



        public void print_result(int num)
        {
            //Special case for 00
            if (num == 37) 
            { Console.WriteLine("Number: 00");}
            else
            { Console.WriteLine("Number: " + num);}

            // Odd/Even
            if (num%2 == 1 && num!= 37) 
            {Console.WriteLine("Even/Odd: ODD");}
            else
            {Console.WriteLine("Even/Odd: Evan");}

            // Excludes 0 and 00 for the results
            if (num != 0 && num != 37) 
            {
                // Red/Black
                if (Is_black(num))
                {Console.WriteLine("Red/Black: BLACK");}
                else
                {Console.WriteLine("Red/Black: RED");}

                // High/Low
                if (num <= 18) 
                {Console.WriteLine("High/Low: LOW");}
                else
                {Console.WriteLine("High/Low: HIGH");}

                // Dozen
                if (num <= 12) 
                {Console.WriteLine("Dozen : 1ST DOZEN");}
                else if(num <= 24)
                {Console.WriteLine("Dozen : 2ND DOZEN");}
                else
                { Console.WriteLine("Dozen : 3RD DOZEN");}

                // Column
                if (num % 3 == 1)
                {Console.WriteLine("Column : 1ST COLUMN");}
                else if(num % 3 == 2)
                {Console.WriteLine("Column : 2ND COLUMN");}
                else
                {Console.WriteLine("Column : 3RD COLUMN");}

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
            if(black.Contains(num))
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

        public void Initiate_Color()     // Initiate the black and red color ArrayList.
        {
            int i = 1;
            black.Clear();
            red.Clear();
            Random r = new Random();
            while(black.Count < 18)
            {
                if(i >= 36)
                {
                    i = 1;
                }
                if(!black.Contains(i))
                {
                    if(r.NextDouble() < 0.5)
                    {
                        black.Add(i);
                    }
                }
                i++;
            }
            black.Sort();
            for(int j = 1; j <= 36; j++)
            {
                if(!black.Contains(j))
                {
                    red.Add(j);
                }
            }
        }

        public String Print_ArrayList(ArrayList array_in)
        {
            String result = "[";

            foreach (int num in array_in)
            {
                result += num;
                if(num != (int)array_in[array_in.Count-1])
                {
                    result += ", ";
                }
            }
            result += "]";
                return result;
        }

    }
}
