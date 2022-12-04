using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using LeetCode;

namespace _273._Integer_to_English_Words
{
    class Solution
    {
        static List<KeyValuePair<int, string>> table = new List<KeyValuePair<int, string>>()
            {
                new KeyValuePair<int, string>(1_000_000_000, "Billion"),
                new KeyValuePair<int, string>(1_000_000,  "Million" ),
                new KeyValuePair<int, string>(1_000,  "Thousand" ),
                new KeyValuePair<int, string>(100,  "Hundred" ),
                new KeyValuePair<int, string>(90,   "Ninety" ),
                new KeyValuePair<int, string>(80,   "Eighty" ),
                new KeyValuePair<int, string>(70,   "Seventy" ),
                new KeyValuePair<int, string>(60,   "Sixty" ),
                new KeyValuePair<int, string>(50,   "Fifty" ),
                new KeyValuePair<int, string>(40,   "Forty" ),
                new KeyValuePair<int, string>(30,   "Thirty" ),
                new KeyValuePair<int, string>(20,   "Twenty"),
                new KeyValuePair<int, string>(19,   "Nineteen" ),
                new KeyValuePair<int, string>(18,   "Eighteen" ),
                new KeyValuePair<int, string>(17,   "Seventeen" ),
                new KeyValuePair<int, string>(16,   "Sixteen" ),
                new KeyValuePair<int, string>(15,   "Fifteen" ),
                new KeyValuePair<int, string>(14,   "Fourteen" ),
                new KeyValuePair<int, string>(13,   "Thirteen" ),
                new KeyValuePair<int, string>(12,   "Twelve" ),
                new KeyValuePair<int, string>(11,   "Eleven" ),
                new KeyValuePair<int, string>(10,   "Ten" ),
                new KeyValuePair<int, string>(9,    "Nine" ),
                new KeyValuePair<int, string>(8,    "Eight" ),
                new KeyValuePair<int, string>(7,    "Seven" ),
                new KeyValuePair<int, string>(6,    "Six" ),
                new KeyValuePair<int, string>(5,    "Five" ),
                new KeyValuePair<int, string>(4,    "Four" ),
                new KeyValuePair<int, string>(3,    "Three" ),
                new KeyValuePair<int, string>(2,    "Two" ),
                new KeyValuePair<int, string>(1,    "One" ),
            };
        static Dictionary<string, int> CategorizeIntsToNumericalUnits(int n)
        {
            var keys = new Dictionary<string, int>();
            while (n > 0)
                foreach (var item in table)
                    if (n >= item.Key)
                    {
                        n -= item.Key;
                        if (!keys.ContainsKey(item.Value))
                            keys.Add(item.Value, 0);
                        keys[item.Value]++;
                        break;
                    }
            return keys;
        }
        static string DictToString(Dictionary<string,int> dict)
        {
            string s = "";
            foreach (var line in table)
                if (dict.ContainsKey(line.Value))
                {
                    if (line.Key >= 100)
                        s+= dict[line.Value] < 20 ? 
                            $"{DictToString(CategorizeIntsToNumericalUnits(dict[line.Value]))}":
                            $"{dict[line.Value]} ";
                    s += $"{line.Value} ";
                }
            return s;
        }
        
        public static string NumberToWords(int num)
        {
            string res = "";
            var firstIteration=  CategorizeIntsToNumericalUnits(num);
            string firstIterationAsString = DictToString(firstIteration);
            var words = firstIterationAsString.Split(" ");
            
            foreach (var word in words)
            {
                bool b = int.TryParse(word, out int parsedNum);
                res += b ? DictToString(CategorizeIntsToNumericalUnits(parsedNum)) : word + " ";
            }

            return num == 0 ? "Zero" : res.TrimEnd();
        }
        
        static void Main(string[] args)
        {
            Common.Run(typeof(Solution), NumberToWords, 0);
        }
    }
}
