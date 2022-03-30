using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TClub
{
    class FileInput
    {
        public FileInput()
        {
            //read the file
            List<string> ListMales = new List<string>();
            List<string> ListFemales = new List<string>(); 
            using (var rd = new StreamReader("../../inputFile.csv"))
            {
                while (!rd.EndOfStream)
                {
                    var line = rd.ReadLine();
                    var values = line.Split(';');
                    if (values[1] == "m")
                    {
                        ListMales.Add(values[0]);
                    }//if
                    else
                    {
                        ListFemales.Add(values[0]);
                    }//else
                }//while
            }//using

            //removing duplicates
            List<string> distinct= ListMales.Distinct().ToList();
            ListMales = distinct;
            distinct = ListFemales.Distinct().ToList();
            ListFemales = distinct;

            //male matches female
            String sline = "";
            percentage p1 = new percentage();
            List<string> matches = new List<string>();
            using (StreamWriter sw = File.AppendText("../../logs.txt"))
            {
                foreach (string male in ListMales)
                {
                foreach (string female in ListFemales)
                    {
                       
                        sline = p1.getPercentage(male, female) + "%" + male + " matches " + female;
                        matches.Add(sline);//stored in mastches list to be sorted and displayed
                        //writing to log textfile
                        sw.WriteLine(sline+" Time :" +DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm"));
                    
                    }//for each female
                }//for each males
            }//using

            //sorting matches list
            matches.Sort();
            matches.Reverse();
            //displaying and writing to textfile
            using (StreamWriter writetext = new StreamWriter("../../output.txt"))
            {
                foreach (string m in matches)
                {
                    
                    string spercentage = m.Substring(0,2);
                    int ipercent = Convert.ToInt16(spercentage);
                    string snames = m.Substring(3);
                    if (ipercent >= 80)
                    {
                        Console.WriteLine(snames + " " + ipercent + "%, good match");
                        writetext.WriteLine(snames + " " + ipercent + "%");
                    }
                    else
                    {
                        Console.WriteLine(snames + " " + ipercent + "%");
                        writetext.WriteLine(snames + " " + ipercent + "%");
                    }
                }//for each
            }
            Console.WriteLine("Enter number 3 to exit");
            string input = Console.ReadLine();
            if (input.Equals("3"))
            {
                Environment.Exit(0);
            }
        }//public FileInput
    }//class
}
