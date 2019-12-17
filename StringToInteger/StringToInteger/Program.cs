using System;

namespace StringToInteger
{
    public class Solution
    {
        public bool IsPalindrome(int x)
        {
            if (x < 0)
                return false;
            if (x < 10)
                return true;
            int cx = x;
            int nten = 1;
            int n = 0;

            while (cx > 0)
            {
                nten *= 10;
                n++;
                cx /= 10;
            }
            int i = 0;
            while (i < n / 2)
            {
                nten /= 10;
                cx = (x / nten) % 10;
                if (cx != x % 10)
                    return false;
                x /= 10;
                nten /= 10;
                i++;
            }
            return true;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Solution s = new Solution();
            Console.WriteLine(s.IsPalindrome(00));
        }
    }
}
