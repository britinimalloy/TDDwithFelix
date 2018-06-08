using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDDwithFelixVersion1
{
    public class Program2
    {
        public static void Main2(string[] args)
        {
        }

        public static int AtoI(string number)
        {
            if (String.IsNullOrWhiteSpace(number))
                return 0;

            number = number.Trim();

            int total = 0;
            int negative = 1;

            for (int index = 0; index < number.Length; index++)
            {
                int value = number[index];

                if (value == ',')
                    continue;

                if (value == '-' && index == 0)
                {
                    negative = -1;
                    continue;
                }

                value = value - '0';

                if (value < 0 || value > 9)
                    return 0;

                total = (total * 10) + value;
            }

            return negative * total;
        }
    }
}