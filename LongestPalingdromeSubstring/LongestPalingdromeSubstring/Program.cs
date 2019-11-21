using System;
using System.Text;

namespace LongestPalingdromeSubstring
{
    class Program
    {
        public class Solution
        {
            /// <summary>
            /// Adds # character between all letters of the string
            /// </summary>
            /// <param name="s"></param>
            /// <returns></returns>
            private string GetModifiedString(string s)
            {
                var t = new StringBuilder();
                for (int i = 0; i < s.Length; i++)
                {
                    t.Append('#');
                    t.Append(s[i]);
                }
                t.Append('#');
                return t.ToString();
            }
            private string GetString(string s)
            {
                StringBuilder t = new StringBuilder();
                for (int i = 1; i < s.Length; i += 2)
                {
                    t.Append(s[i]);
                }
                return t.ToString();
            }
            public string LongestPalindrome(string s)
            {
                if (s.Length == 0 || s == null) return "";
                if (s.Length == 1) return s;

                int len = 2 * s.Length + 1;
                int c = 0, r = 0, maxLen = 0, centerLocation = 0;

                s = GetModifiedString(s);
                int[] P = new int[len];

                for(int i = 0; i < len; i++)
                {
                    int mirror = 2 * c - i;
                    if (i < r)
                        P[i] = Math.Min(r - i, P[mirror]);
                    int a = i + 1 + P[i];
                    int b = i - (1 + P[i]);
                    while(a < len && b >=0 && s[a]==s[b])
                    {
                        P[i]++;
                        a++;
                        b--;
                    }
                    if (i + P[i] > r)
                    {
                        c = i;
                        r = i + P[i];

                        if (P[i] > maxLen)
                        {
                            maxLen = P[i];
                            centerLocation = i;
                        }
                    }
                }
                return GetString(s.Substring(centerLocation - maxLen, 2 * maxLen + 1));
            }
        }
        static void Main(string[] args)
        {
            string s = "aaaa";
            Solution x = new Solution();
            Console.WriteLine(x.LongestPalindrome(s));
            //Console.ReadKey();
        }
    }
}
