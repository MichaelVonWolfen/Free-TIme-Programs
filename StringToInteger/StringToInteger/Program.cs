using System;

namespace StringToInteger
{
    public class Solution
    {
        public int MyAtoi(string str)
        {
            int number = 0, index = 0;
            bool negative = false, signfound = false, spacesdone = false;
            while (index < str.Length)
            {
                if (str[index] == ' ' && !spacesdone)
                {
                    index++;
                    continue;
                }
                if (str[index] == '+' || str[index] == '-')
                {
                    if (signfound)
                        return 0;
                    if (str[index++] == '-')
                        negative = true;
                    signfound = true;
                    continue;
                }
                spacesdone = true;
                if (str[index] < '0' || str[index] > '9')
                    break;
                int digit = Int32.Parse(str[index++].ToString());
                if ((Int32.MinValue / 10 > (-1 * number) && negative) ||
                    ((Int32.MinValue / 10) == (-1 * number) && (-1 * digit) <= (Int32.MinValue % 10) && negative)) return Int32.MinValue;
                if (((Int32.MaxValue / 10) < number && !negative) ||
                    ((Int32.MaxValue / 10) == number && digit >= Int32.MaxValue % 10 && !negative)) return Int32.MaxValue;

                number = number * 10 + digit;
            }
            if (!negative)
                return number;
            else return number * -1;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Solution s = new Solution();
            Console.WriteLine(s.MyAtoi("-2147483647"));
        }
    }
}
