using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Brameczki
{
    class Program
    {
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
            ulong in1, in2;
            bool correctInput = true;

            Console.WriteLine("-----Adding two digits by logic gates simulation-----");

            Console.Write("First digit: ");
            correctInput = ulong.TryParse(Console.ReadLine(), out in1);

            Console.Write("Second digit: ");
            correctInput = ulong.TryParse(Console.ReadLine(), out in2);

            if (!correctInput)
            {
                Console.WriteLine("Incorrect input.");
                Console.WriteLine($"{Environment.NewLine} Prss to continue...");
                return;
            }

            var cr = new Circuit(sizeof(ulong) * 8);

            cr.Input1 = in1;
            cr.Input2 = in2;

            var sWatch = Stopwatch.StartNew();
            var result = cr.Sum();
            sWatch.Stop();

            Console.WriteLine($"{in1} + {in2} = {result}");
            Console.WriteLine($"{Environment.NewLine}Execution time: {sWatch.Elapsed.TotalMilliseconds}ms");
            Console.WriteLine("Prss to continue...");
            Console.ReadKey();
        }
    }
}
