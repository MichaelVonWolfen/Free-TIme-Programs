using System;
using System.Collections.Generic;

namespace PhoneLetterCombination
{
    public class Solution
    {
        private Dictionary<string, string> dicti = new Dictionary<string, string>();
        private List<string> output = new List<string>();
        private void backtrack(string digits, int pivot_digits, string word)
        {
            int letter_nb = 0;
            if (pivot_digits == digits.Length - 1)
            {
                while (letter_nb < (dicti[digits[pivot_digits].ToString()]).Length)
                {
                    output.Add(word + (dicti[digits[pivot_digits].ToString()])[letter_nb]);
                    letter_nb++;
                }
                return;
            }
            while (letter_nb < (dicti[digits[pivot_digits].ToString()]).Length)
            {
                backtrack(digits, pivot_digits + 1, word + (dicti[digits[pivot_digits].ToString()])[letter_nb]);
                letter_nb++;
            }
        }
        public IList<string> LetterCombinations(string digits)
        {
            dicti.Add("2", "abc");
            dicti.Add("3", "def");
            dicti.Add("4", "ghi");
            dicti.Add("5", "jkl");
            dicti.Add("6", "mno");
            dicti.Add("7", "pqrs");
            dicti.Add("8", "tuv");
            dicti.Add("9", "wxyz");

            try
            {
                backtrack(digits, 0, "");

            }
            catch (Exception E)
            {
                Console.WriteLine(E.Message);
                return new List<string>();
            }
            return output;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            foreach(string a in  new Solution().LetterCombinations("237"))
            {
                Console.WriteLine(a);
            }
        }
    }
}
