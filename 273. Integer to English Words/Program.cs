using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using LeetCode;

namespace _273._Integer_to_English_Words
{
    class Solution
    {
        public static string NumberToWords(int num)
        {
            List<KeyValuePair<int, string>> table = new List<KeyValuePair<int, string>>()
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

            int n = num;
            string res = "";

           // Dictionary<string,int> keys = new Dictionary<string,int> ();

            List<Dictionary<string, int>> ledger = new List<Dictionary<string, int>>();

            void IntToNumericalUnits(int _n)
            {
                var _keys = new Dictionary<string, int>();
                while (_n > 0)
                {
                    foreach (var item in table)
                    {
                        if (_n >= item.Key)
                        {
                            _n -= item.Key;
                            if (!_keys.ContainsKey(item.Value))
                            {
                                _keys.Add(item.Value, 0);
                            }

                            _keys[item.Value]++;
                            // res += item.Value+ " ";
                            break;
                        }
                                                    
                       
                    }
                } ledger.Add(_keys);
            }

            IntToNumericalUnits(n);
            var l = ledger[0];
            foreach (var line in table)
            {
                if (l.ContainsKey(line.Value))
                {
                    IntToNumericalUnits(l[line.Value]);
                }
            }

            int index = 0;
            foreach (var line in table)
            {
                index++;
                if (index > ledger.Count )
                {
                    break;
                }
                if (l.ContainsKey(line.Value))
                {
                    string s = "";
                    foreach (var line2 in table)
                    {
                        if (ledger[index].ContainsKey(line2.Value))
                        {
                            s += $"{line2.Value} ";
                        }
                    }

                    res += $"{s}{line.Value} ";
                }

                
            }
            
            res += $"\n{ledger} ";
            return res;
        }
        static void Main(string[] args)
        {
            Common.StartBenchmark();

            Console.WriteLine(NumberToWords(1234123499));

            Common.EndBenchmark();

        }
    }
}
