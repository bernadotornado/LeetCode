using System;
using System.Diagnostics;

namespace LeetCode
{
    public class Common
    {
        static Stopwatch sw = new Stopwatch();
        static public void StartBenchmark()
        {
            sw.Start();
        }
        static public void EndBenchmark()
        {
            sw.Stop();
            Console.WriteLine(sw.Elapsed.TotalMilliseconds);
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
