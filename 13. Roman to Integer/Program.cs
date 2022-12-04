using System;
using LeetCode;

namespace _13._Roman_to_Integer
{
    class Solution
    {
        static public int RomanToInt(string s)
        {
            int result = 0;
            for (int i = 0; i <s.Length; i++)
            {
                var current = s[i];
                var next = '?';
                var n = i + 1;
                next = s[n> s.Length -1 ? s.Length-1 : n];

                result += current switch
                {
                    'I' => 1   * (next == 'V' || next == 'X' ? -1 : 1), 
                    'X' => 10  * (next == 'L' || next == 'C' ? -1 : 1), 
                    'C' => 100 * (next == 'D' || next == 'M' ? -1 : 1), 
                    'V' => 5,
                    'L' => 50,
                    'D' => 500,
                    'M' => 1000,
                };
            }
            return result;
        }
        static void Main(string[] args)
        {
            
            Common.Run(typeof(Solution),RomanToInt, "MDCCCXLIX");
        }
    }
}
