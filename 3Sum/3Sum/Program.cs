using System;
using System.Collections.Generic;

namespace _3Sum
{
    class Program
    {
        public class Solution
        {
            /// <summary>
            /// Made by Mike
            /// </summary>
            /// <param name="l1"></param>
            /// <param name="l2"></param>
            /// <returns></returns>
            bool IsEqual(IList<int> l1, IList<int> l2)
            {
                int[] v1 = ((List<int>)l1).ToArray();
                int[] v2 = ((List<int>)l2).ToArray();
                for (int i = 0; i < v1.Length && i < v2.Length; i++)
                    if (v1[i] != v2[i])
                        return false;
                return true;
            }
            private int[,] TwoSum(int[] nums, int target, int skip)
            {
                SortedList<int, int> dicti = new SortedList<int, int>();
                int searchedVal;
                List<int[]> ret = new List<int[]>();
                for (int i = 0; i < nums.Length; i++)
                {
                    if (i == skip) continue;
                    try
                    {
                        dicti.Add(nums[i], i);

                        if (i == 0) continue;

                        searchedVal = target - nums[i];

                        if (dicti.ContainsKey(searchedVal) && i != dicti[searchedVal])
                            ret.Add(new int[] { nums[dicti[searchedVal]], nums[i] });
                            //Add to List
                            //return new int[] { nums[dicti[searchedVal]], nums[i] };
                    }
                    catch (ArgumentException E)
                    {
                        searchedVal = target - nums[i];
                        if (dicti.ContainsKey(searchedVal) && i != dicti[searchedVal])
                            ret.Add(new int[] { nums[dicti[searchedVal]], nums[i] });
                        //Add to List
                        //return new int[] { nums[dicti[searchedVal]], nums[i] };
                    }
                }
                if (ret.Count == 0)
                    return null;
                int[,] l = new int[ret.Count, 2];
                int q = 0;
                foreach(var v in ret)
                {
                    l[q,0] = v[0];
                    l[q++, 1] = v[1];
                }
                return l;
            }
            public IList<IList<int>> ThreeSum(int[] nums)
            {
                IList<IList<int>> ret = new List<IList<int>>();
                if (nums.Length == 0 || nums == null)
                    return null;
                for (int i = 0; i < nums.Length; i++)
                {
                    int[,] a = TwoSum(nums, -nums[i], i);
                    
                    if (a == null) continue;

                    for (int q = 0; q < a.Length/2; q++)
                    {
                        List<int> b = new List<int> { nums[i],a[q,0],a[q,1]};
                        b.Sort();
                        bool ok = true;
                        foreach (var c in ret)
                        {
                            if (IsEqual(c, b))
                                ok = false;
                        }
                        if (ok) ret.Add(b);
                    }
                }
                return ret;
            }
        }
        static void Main(string[] args)
        {
            int[] nums = new int[] { -4, -2, -2, -2, 0, 1, 2, 2, 2, 3, 3, 4, 4, 6, 6 };
            var a = new Solution().ThreeSum(nums);
            foreach(var i in a)
            {
                foreach (var j in i)
                    Console.Write("{0} ", j);
                Console.WriteLine();
            }
        }
    }
}
