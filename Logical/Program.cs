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

            AND4Chip testGate = new AND4Chip()
            {
                Ground = false,
                VDD = true
            };

            // BUFFER
            //Console.WriteLine("0" + testGate.GetUpdatedOutput());

            //testGate.SetInputBit(0, true);
            //Console.WriteLine("1" + testGate.GetUpdatedOutput());

            //2 INPUT GATES
            //Console.WriteLine("0 0 " + testGate.Output);

            //testGate.SetInputBit(0, false).SetInputBit(1, true);
            //Console.WriteLine("0 1 " + testGate.GetUpdatedOutput());

            //testGate.SetInputBit(0, true).SetInputBit(1, false);
            //Console.WriteLine("1 0 " + testGate.GetUpdatedOutput());

            //testGate.SetInputBit(0, true).SetInputBit(1, true);
            //Console.WriteLine("1 1 " + testGate.GetUpdatedOutput());

            //CHIP
            Console.WriteLine("0 0 0 0 " + testGate.Output);

            testGate.SetInputBit(0, false).SetInputBit(1, false).SetInputBit(2, false).SetInputBit(3, true);
            Console.WriteLine("0 0 0 1 " + testGate.GetUpdatedOutput());

            testGate.SetInputBit(0, false).SetInputBit(1, false).SetInputBit(2, true).SetInputBit(3, false);
            Console.WriteLine("0 0 1 0 " + testGate.GetUpdatedOutput());

            testGate.SetInputBit(0, false).SetInputBit(1, false).SetInputBit(2, true).SetInputBit(3, true);
            Console.WriteLine("0 0 1 1 " + testGate.GetUpdatedOutput());

            testGate.SetInputBit(0, false).SetInputBit(1, true).SetInputBit(2, false).SetInputBit(3, false);
            Console.WriteLine("0 1 0 0 " + testGate.GetUpdatedOutput());

            testGate.SetInputBit(0, false).SetInputBit(1, true).SetInputBit(2, false).SetInputBit(3, true);
            Console.WriteLine("0 1 0 1 " + testGate.GetUpdatedOutput());

            testGate.SetInputBit(0, false).SetInputBit(1, true).SetInputBit(2, true).SetInputBit(3, false);
            Console.WriteLine("0 1 1 0 " + testGate.GetUpdatedOutput());

            testGate.SetInputBit(0, false).SetInputBit(1, true).SetInputBit(2, true).SetInputBit(3, true);
            Console.WriteLine("0 1 1 1 " + testGate.GetUpdatedOutput());

            testGate.SetInputBit(0, true).SetInputBit(1, false).SetInputBit(2, false).SetInputBit(3, false);
            Console.WriteLine("1 0 0 0 " + testGate.GetUpdatedOutput());

            testGate.SetInputBit(0, true).SetInputBit(1, false).SetInputBit(2, false).SetInputBit(3, true);
            Console.WriteLine("1 0 0 1 " + testGate.GetUpdatedOutput());

            testGate.SetInputBit(0, true).SetInputBit(1, false).SetInputBit(2, true).SetInputBit(3, false);
            Console.WriteLine("1 0 1 0 " + testGate.GetUpdatedOutput());

            testGate.SetInputBit(0, true).SetInputBit(1, false).SetInputBit(2, true).SetInputBit(3, true);
            Console.WriteLine("1 0 1 1 " + testGate.GetUpdatedOutput());

            testGate.SetInputBit(0, true).SetInputBit(1, true).SetInputBit(2, false).SetInputBit(3, false);
            Console.WriteLine("1 1 0 0 " + testGate.GetUpdatedOutput());

            testGate.SetInputBit(0, true).SetInputBit(1, true).SetInputBit(2, false).SetInputBit(3, true);
            Console.WriteLine("1 1 0 1 " + testGate.GetUpdatedOutput());

            testGate.SetInputBit(0, true).SetInputBit(1, true).SetInputBit(2, true).SetInputBit(3, false);
            Console.WriteLine("1 1 1 0 " + testGate.GetUpdatedOutput());

            testGate.SetInputBit(0, true).SetInputBit(1, true).SetInputBit(2, true).SetInputBit(3, true);
            Console.WriteLine("1 1 1 1 " + testGate.GetUpdatedOutput());

            Console.Write("Press any key to exit...");
            Console.ReadKey();
        }
    }

}
