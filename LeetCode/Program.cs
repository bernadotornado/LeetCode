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
            Console.WriteLine("-----------------");
        }
        static public void EndBenchmark()
        {
            sw.Stop();
            Console.WriteLine("-----------------");
            Console.WriteLine("Time Elapsed: "+sw.Elapsed.TotalMilliseconds+ "ms");
        }
        public delegate TOutput Solution<TInput,TOutput>(TInput input);
        public delegate TOutput Solution<TInput1, TInput2,TOutput>(TInput1 input1, TInput2 input2);
        static public void Run<TInput, TOutput>(Type t,Solution<TInput, TOutput> solution, TInput input) 
        {
            string s = $"{t}";
            var a = s.Split('.', '_');
            Console.Write($"{a[1]}. ");
            for (int i = 3; i < a.Length-1; i++)
                Console.Write($"{a[i]} ");
            Console.Write("\n");
            StartBenchmark();
            Console.WriteLine("Input:");
            Console.WriteLine(input);
            Console.WriteLine("\nOutput:");
            Console.WriteLine($"{solution(input)}");
            EndBenchmark();
        }

        static public void Run<TInput1, TInput2, TOutput>(Type t, Solution<TInput1, TInput2, TOutput> solution, TInput1 input1, TInput2 input2)
        {
            string s = $"{t}";
            var a = s.Split('.', '_');
            Console.Write($"{a[1]}. ");
            for (int i = 3; i < a.Length - 1; i++)
                Console.Write($"{a[i]} ");
            Console.Write("\n");
            StartBenchmark();
            Console.WriteLine("Inputs :");
            Console.WriteLine($"{input1}, {input2}");
            Console.WriteLine("\nOutput:");
            Console.WriteLine($"{solution(input1, input2)}");
            EndBenchmark();
        }

        static void Main(string[] args)
        {
            Console.WriteLine("LeetCode solutions.");
        }
    }
}
