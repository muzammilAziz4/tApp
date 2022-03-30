using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TClub
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter 1 for user input,2 for file input or 3 to exit");
            string input = Console.ReadLine();
            bool bfound = false;
            while(bfound==false)
            {
                if (input.Equals("1"))
                {
                    UserInput UI = new UserInput();
                    bfound = true;
                    
                }
                else if (input.Equals("2"))
                {
                    FileInput FI = new FileInput();
                    bfound = true;
                }
                else if (input.Equals("3"))
                {
                    Environment.Exit(0);
                }else
                {
                    Console.WriteLine("Enter 1 for user input,2 for file input or 3 to exit");
                    input = Console.ReadLine();

                }
            }//while
        }
    }
}
