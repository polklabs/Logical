using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logical
{
    class Program
    {
        static void Main(string[] args)
        {

            ANDGate testGate = new ANDGate()
            {
                Ground = false,
                VDD = true
            };

            //Console.WriteLine("0" + testGate.GetUpdatedOutput());

            //testGate.SetInputBit(0, true);
            //Console.WriteLine("1" + testGate.GetUpdatedOutput());

            Console.WriteLine("0 0 " + testGate.Output);

            //testGate.SetInputBit(0, false).SetInputBit(1, true);
            Console.WriteLine("0 1 " + testGate.GetUpdatedOutput(1, true));

            //testGate.SetInputBit(0, true).SetInputBit(1, false);
            Console.WriteLine("1 1 " + testGate.GetUpdatedOutput(0, true));

            //testGate.SetInputBit(0, true).SetInputBit(1, true);
            Console.WriteLine("1 0 " + testGate.GetUpdatedOutput(1, false));

            Console.Write("Press any key to exit...");
            Console.ReadKey();
        }
    }

}
