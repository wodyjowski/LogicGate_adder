using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Brameczki
{
    class Program
    {
        private static Regex regex = new Regex(@"^\d+");


        static void Main(string[] args)
        {
            //Forcing JIT methods compilation to ensure proper execution times
            foreach (Type t in Assembly.GetExecutingAssembly().GetTypes())
            {
                foreach (MethodInfo m in t.GetMethods())
                {
                    System.Runtime.CompilerServices.RuntimeHelpers.PrepareMethod(m.MethodHandle);
                }
            }


            while (true)
            {
                ShowMenu();
                Console.Clear();
            }
        }

        private static void ShowMenu()
        {
            BigInteger in1, in2;
            bool correctInput = true;
            string input;

            WriteLineColor("-----Adding two digits by logic gates simulation-----", ConsoleColor.Cyan);
            Console.WriteLine("Input is limited by ReadLine() method - max 254 characters.");
            Console.WriteLine($"Number of adders/gates is assigned based on input.{Environment.NewLine}");

            WriteLineColor("First digit: ", ConsoleColor.Green);

            input = Console.ReadLine();
            correctInput = BigInteger.TryParse(input, out in1);
            correctInput &= regex.IsMatch(input);

            WriteLineColor("Second digit: ", ConsoleColor.Green);

            input = Console.ReadLine();
            correctInput = BigInteger.TryParse(input, out in2);
            correctInput &= regex.IsMatch(input);

            if (!correctInput)
            {
                WriteLineColor("Incorrect input.", ConsoleColor.Red);
                Console.WriteLine($"{Environment.NewLine}Press to continue...");
                Console.ReadKey();
                return;
            }

            int size = GetCircuitSize(in1, in2);

            var cr = new Circuit(size);

            cr.Input1 = in1;
            cr.Input2 = in2;

            var sWatch = Stopwatch.StartNew();
            var result = cr.Sum();
            sWatch.Stop();

            WriteLineColor($"Result:", ConsoleColor.Green);
            Console.WriteLine(result);
            Console.WriteLine($"{Environment.NewLine}Execution time: {sWatch.Elapsed.TotalMilliseconds}ms");

            WriteColor("Adders used: ", ConsoleColor.DarkMagenta);
            Console.WriteLine(size);
            WriteColor("Logic Gates used: ", ConsoleColor.DarkMagenta);
            Console.WriteLine(size * 5);

            Console.WriteLine("Press to continue...");
            Console.ReadKey();
        }


        private static int GetCircuitSize(BigInteger bi1, BigInteger bi2)
        {
            int result = Math.Max(bi1.ToBinaryString().Length, bi2.ToBinaryString().Length);

            return result;
        }

        private static void WriteColor(string text, ConsoleColor color)
        {
            var recentColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.Write(text);
            Console.ForegroundColor = recentColor;
        }

        private static void WriteLineColor(string text, ConsoleColor color)
        {
            var recentColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ForegroundColor = recentColor;
        }

    }
}
