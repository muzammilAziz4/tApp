using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TClub
{
    class percentage
    {
        public string getPercentage(string N1, string N2)
        {
            string ScombinedNames = N1 + "matches" + N2;
            ScombinedNames = ScombinedNames.ToLower();
           


            // Creating array of string length 
            char[] ArrCh = new char[ScombinedNames.Length];

            // Copy character by character into array 
            for (int i = 0; i < ScombinedNames.Length; i++)
            {
                ArrCh[i] = ScombinedNames[i];
            }


            //Convert to number
            string Scount = "";
            for (int i = 0; i < ScombinedNames.Length; i++)
            {
                char currentletter = ArrCh[i];
                int count = 0;
                for (int j = 0; j < ScombinedNames.Length; j++)
                {
                    if ((!currentletter.Equals('*')) && (currentletter.Equals(ArrCh[j])))
                    {
                        count++;
                        ArrCh[j] = '*';

                    }//if
                }//for j
                if (count != 0)
                {
                    Scount = Scount + count.ToString();

                }//if count !=0

            }//for i
            
            //convert to percentage
            while (Scount.Length > 2)
            {
                //convert scount to array
                int[] ArrNumbers = new int[Scount.Length];
                for (int i = 0; i < Scount.Length; i++)
                {
                    String Snum = Scount.Substring(i, 1);
                    int iNum = Convert.ToInt16(Snum);
                    ArrNumbers[i] = iNum;
                }

                int t = Scount.Length / 2;
                int iReverse = Scount.Length - 1;
                Scount = "";
                for (int i = 0; i < t; i++)
                {
                    int isum = ArrNumbers[i] + ArrNumbers[iReverse];
                    iReverse = iReverse - 1;
                    Scount = Scount + isum.ToString();
                }//for
                //if length of scount is odd
                if (ArrNumbers.Length % 2 != 0)
                {
                    int iMiddleDigit = ArrNumbers[t];
                    Scount = Scount + iMiddleDigit.ToString();
                }//if
                

            }//while
            return Scount;

        }
    }//class percentage
}
