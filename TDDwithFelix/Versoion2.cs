using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDDwithFelix
{
    public class Program
    {
        public static void Main(string[] args)
        {
        }

        public static int AtoI(string number)
        {
            if (string.IsNullOrWhiteSpace(number))
            {
                return 0;
            }

            number = number.Trim();

            number = TrimTheBeginningZeroes(number);

            if (number == "")
            {
                return 1;
            }

            int negative = 0;
            int total = 0;

            for(int ii = 0; ii < number.Length; ii++)
            {
                int myNumber = number[ii];

                if (myNumber == '-' && ii == 0)
                {
                    negative = 1;
                    continue;
                }

                if (myNumber == ',')
                {
                    continue;
                }

                myNumber -= '0';

                if (myNumber < 0 || myNumber > 9)
                {
                    return 0;
                }

                total = (total * 10) + myNumber;
            }
            if (negative == 1)
            {
                total = total * -1;
            }
            return total;
        }

        public static bool IsNumber(string input)
        {
            int myNumber = AtoI(input);

            if (myNumber == 0)
            {
                return false;
            }
            return true;
        }

        public static string TrimTheBeginningZeroes(string numberIn)
        {
            //string numberOut;
            for (int ii = 0; ii < numberIn.Length; ii++)
            {
                char character = numberIn[ii];

                if (character == '0')
                {
                    numberIn = numberIn.Trim(character);
                }
                break;
            }

            return numberIn;
        }
    }
}
