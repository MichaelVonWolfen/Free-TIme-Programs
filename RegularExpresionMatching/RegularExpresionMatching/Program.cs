using System;

public class Solution
{
    private int GetAparition(string s, int start, char search)
    {
        int i = start;
        while (s[i] != search)
        {
            if (i == s.Length - 1)
                return s.Length;
            else i++;
        }
        return i;
    }
    public bool IsMatch(string s, string p)
    {
        if (p.Length == 0 && s.Length > 0)
            return false;
        if (s == "" && (p == "" || p == ".*"))
            return true;
        int i = 0, j = 0;
        char search = ' ';
        int indexi = 0, indexj = 0;
        bool DotStar = false;

        while (i < s.Length && j < p.Length)
        {
            if (p[j] == '.' && p[j + 1] != '*')
            {
                i++;
                j++;
                continue;
            }
            if (p[j] == '*' && p[j - 1] != '.')
            {
                while (p[j - 1] == s[i])
                {
                    i++;
                    if (i >= s.Length - 1)
                        break;
                }
                j++;
                continue;
            }
            if (p[j] == '.' && p[j + 1] == '*')
            {
                if (j + 2 == p.Length)
                    return true;

                search = p[j + 2];
                i = GetAparition(s, i, search);
                indexi = i;
                j += 2;
                indexj = j;
                DotStar = true;
                continue;
            }
            if (s[i] == p[j])
            {
                i++;
                j++;
            }
            else
                if (DotStar)
            {
                j = indexj;
                i = GetAparition(s, indexi + 1, search);
                indexi = i;
            }
            else if(p[j+1] == '*')
                 {
                    j++;
                    continue;
                }
                else return false;
        }
        if ((s.Length >= i  && j  < p.Length) || (s.Length > i  && j  <= p.Length))
            return false;
        return true;
    }
}

namespace RegularExpresionMatching
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution s = new Solution();

            Console.WriteLine(s.IsMatch("mississippi", "mis*is*p*.")? "True" : "False") ;
            Console.WriteLine(s.IsMatch("aab", "c*a*b") ? "True" : "False");

        }
    }
}
