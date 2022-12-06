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
        public delegate void Solution<TInput>(TInput input);
        public delegate TOutput Solution<TInput,TOutput>(TInput input);
        public delegate TOutput Solution<TInput1, TInput2,TOutput>(TInput1 input1, TInput2 input2);
        public delegate TOutput Solution<TInput1, TInput2,TInput3,TOutput>(TInput1 input1, TInput2 input2);
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

        public static string ArrayToString<T>(T[] arr)
        {
            string res = "";
            for (int i = 0; i < arr.Length; i++)
            {
                res += arr[i].ToString();
            }
            return res;
        }
        static public void Run<TInput1, TInput2, TOutput>(Type t, Solution<TInput1, TInput2, TOutput> solution, TInput1 input1, TInput2 input2)
        {
            GetTitle(t);
            StartBenchmark();
            Console.WriteLine("Inputs :");
            Console.WriteLine($"{input1}, {input2}");
            Console.WriteLine("\nOutput:");
            Console.WriteLine($"{solution(input1, input2)}");
            EndBenchmark();
        }

        static public void Run<TInput>(Type t, Solution<TInput> solution, TInput input)
        {
            GetTitle(t);
            StartBenchmark();
            Console.WriteLine("Inputs :");
            Console.WriteLine($"{input}");
            Console.WriteLine("\nOutput:");
            Console.WriteLine($"None");
            EndBenchmark();
        }

        static public void Run<TInput1, TInput2, TInput3, TOutput>(Type t, Solution<TInput1, TInput2, TInput3, TOutput> solution, TInput1 input1, TInput2 input2, TInput3 input3)
        {
            GetTitle(t);
            StartBenchmark();
            Console.WriteLine("Inputs :");
            Console.WriteLine($"{input1}, {input2}, {input3}");
            Console.WriteLine("\nOutput:");
            Console.WriteLine($"{solution(input1, input2)}");
            EndBenchmark();
        }
        
        

        private static void GetTitle(Type t)
        {
            string s = $"{t}";
            var a = s.Split('.', '_');
            Console.Write($"{a[1]}. ");
            for (int i = 3; i < a.Length - 1; i++)
                Console.Write($"{a[i]} ");
            Console.Write("\n");
        }

        static void Main(string[] args)
        {
            Console.WriteLine("LeetCode solutions.");
        }
    }
}
