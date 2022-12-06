using System;
using LeetCode;

namespace _4._Median_of_Two_Sorted_Arrays
{
    class Solution
    {
        public static double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            var a = new System.Collections.Generic.List<int>();
            a.AddRange(nums1);
            a.AddRange(nums2);
            a.Sort();
            int x = a.Count / 2;

            return a.Count % 2 == 0 ?
                (a[x - 1] + a[x]) / 2d : a[x];
        }
        static void Main(string[] args)
        {
            Common.Run(typeof(Solution), FindMedianSortedArrays, new[] { 1, 2, 3 }, new[] { 4, 5, 6, });
        }
    }
}
