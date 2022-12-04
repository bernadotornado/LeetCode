using System;
using System.Collections.Generic;
using LeetCode;

namespace _12._Integer_to_Roman
{
    public class Solution
    {
        static public string IntToRoman(int num)
        {
            List<KeyValuePair<int, string>> table = new List<KeyValuePair<int, string>>()
            {
                new KeyValuePair<int, string>(1000, "M"),
                new KeyValuePair<int, string>(900,  "CM" ),
                new KeyValuePair<int, string>(500,  "D" ),
                new KeyValuePair<int, string>(400,  "CD" ),
                new KeyValuePair<int, string>(100,  "C" ),
                new KeyValuePair<int, string>(90,   "XC" ),
                new KeyValuePair<int, string>(50,   "L" ),
                new KeyValuePair<int, string>(40,   "XL" ),
                new KeyValuePair<int, string>(10,   "X" ),
                new KeyValuePair<int, string>(9,    "IX" ),
                new KeyValuePair<int, string>(5,    "V" ),
                new KeyValuePair<int, string>(4,    "IV"),
                new KeyValuePair<int, string>(1,    "I" ),
            };
           
            int n = num;
            string res = "";
            while(n > 0)
            {
                foreach (var item in table)
                {
                    if(n >= item.Key)
                    {
                        n -= item.Key;
                        res += item.Value;
                        break;
                    }
                }
            }
            return res;
        }
        static void Main(string[] args)
        {
            Common.Run(typeof(Solution), IntToRoman, 1234);
        }
    }
}
