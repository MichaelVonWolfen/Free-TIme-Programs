using System;
using System.Collections.Generic;

namespace Paranthesis_Validator
{
    public class Solution
    {
        public bool IsValid(string s)
        {
            if (s.Length % 2 == 1)
                return false;
            Stack<char> brackets = new Stack<char>();
            Dictionary<char, char> dicti = new Dictionary<char, char>();
            dicti.Add('(', ')');
            dicti.Add('[', ']');
            dicti.Add('{', '}');
            foreach (char c in s)
            {
                if (dicti.ContainsKey(c))
                {
                    brackets.Push(c);
                    continue;
                }
                if (brackets.Count == 0)
                    return false;
                char a = (char)brackets.Pop();
                if (dicti[a] != c)
                    return false;
            }
            if (brackets.Count > 0)
                return false;
            else return true;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(new Solution().IsValid("{[][]{}()}"));
        }
    }
}
