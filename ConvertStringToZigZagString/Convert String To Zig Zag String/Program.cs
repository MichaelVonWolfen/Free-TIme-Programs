using System;
using System.Text;

namespace Convert_String_To_Zig_Zag_String
{
    class Program
    {
        public class Solution
        {
            public string Convert(string s, int numRows)
            {
                int i = 0;
                int j = 0;
                int z = 2 * numRows - 2;
                if (s == "" || s.Length < 3 || numRows == 1)
                    return s;

                StringBuilder new_string = new StringBuilder();
                while (s.Length > new_string.Length)
                {
                    for (int poz = i; poz < s.Length; poz += z)
                    {
                        new_string.Append(s[poz]);
                        if (j != 0 && poz + j < s.Length)
                            new_string.Append(s[poz + j]);
                    }
                    if (j == 0) j = z - 2;
                    else j -= 2;

                    i++;
                }
                return new_string.ToString();
            }
        }
        static void Main(string[] args)
        {
            Solution a = new Solution();
            string s = "PAYPALISHIRING";
            int rows = 4;
            Console.WriteLine(a.Convert(s,rows));
        }
    }
}
