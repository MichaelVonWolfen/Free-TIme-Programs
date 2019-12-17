using System;
using System.Collections.Generic;

namespace _3Sum
{
    class Program
    {
        public class Solution
        {
            
            public IList<IList<int>> ThreeSum(int[] nums)
            {
                List<IList<int>> treeSum = new List<IList<int>>();
                if (nums.Length <= 2) return treeSum;
                Array.Sort(nums);
                int start = 0, left, right;
                int t;

                while (start < nums.Length - 2)
                {
                    t = -nums[start];
                    left = start + 1;
                    right = nums.Length - 1;
                    while (left<right)
                    {
                        if (nums[left] + nums[right] > t)
                            right--;
                        else if (nums[left] + nums[right] < t)
                            left++;
                        else
                        {
                            int a = nums[left];
                            int b = nums[right];
                            treeSum.Add(new List<int> { nums[start], a,b });
                            while (left < right && nums[left] == a) ++left;
                            while (left < right && nums[right] == b) --right;
                        }
                    }
                    int currentStartNumber = nums[start];
                    while (start < nums.Length - 2 && nums[start] == currentStartNumber)
                        ++start;
                }
                return treeSum;
            }
        }
        static void Main(string[] args)
        {
            int[] nums = new int[] {-2, 0, 1, 1, 2};
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
