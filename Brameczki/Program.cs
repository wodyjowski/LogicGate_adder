using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brameczki
{
    class Program
    {
        static void Main(string[] args)
        {
            var cr = new Circuit(32);

            cr.Input1 = 5675;
            cr.Input2 = 12;

            Console.WriteLine(cr.Sum());
            Console.ReadKey();
        }
    }
}
