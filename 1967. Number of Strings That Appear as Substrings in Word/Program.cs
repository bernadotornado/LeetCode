
using LeetCode;
namespace _1967._Number_of_Strings_That_Appear_as_Substrings_in_Word
{
    class Solution
    {
        public static int NumOfStrings(string[] patterns, string word)
        {
            int res = 0;
            foreach (var patt in patterns)
                res+= word.Contains(patt)?1:0;

            return res;
        }
        static void Main()
        {
            Common.Run(typeof(Solution), NumOfStrings, new []{"a", "a", "a"}, "ab");
        }
    }
}
