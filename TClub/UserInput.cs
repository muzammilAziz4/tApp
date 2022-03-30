using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TClub
{
    class UserInput
    {
        public UserInput()
        {
            string Sname1 = getName(1);
            string Sname2 = getName(2);
            percentage p = new percentage();
            string sPercentage=p.getPercentage(Sname1, Sname2);
            int ipercentage = Convert.ToInt16(sPercentage);
            if (ipercentage >= 80)
            {
                Console.WriteLine(Sname1 + " matches " + Sname2 + " " + sPercentage + "%, good match");
            }
            else
            {
                Console.WriteLine(Sname1 + " matches " + Sname2 + " " + sPercentage + "%");
            }
            using (StreamWriter sw = File.AppendText("../../logs.txt"))
            {
                sw.WriteLine(sPercentage + "%" + Sname1 + " matches " + Sname2 + " Time :" + DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm"));
            }
            Console.WriteLine("Enter number 3 to exit");
            string input = Console.ReadLine();
            if (input.Equals("3"))
            {
                Environment.Exit(0);
            }

        }//userinput()
        public string getName(int n)
        {
            Console.WriteLine("Enter name:" + n + " or the number 3 to exit");
            string input = Console.ReadLine();
            if (input.Equals("3"))
            {
                Environment.Exit(0);
            }
            bool bcertified = false;
            while (bcertified == false)
            {              
                bcertified = certify(input);
                if (bcertified == false)
                {
                    Console.WriteLine("incorrect input,only alphabets allowed.Enter name:" + n + " or the number 3 to exit");
                    input = Console.ReadLine();
                    if (input.Equals("3"))
                    {
                        Environment.Exit(0);
                    }//if

                }//if
                
            }//while
            return input;
        }//getname
        public bool certify(string sName)//used to make sure theres only alphabets
        {
            foreach (char c in sName)
            {
                if (!Char.IsLetter(c))
                    return false;
            }
            return true;
        }//certify
    }//class
}
