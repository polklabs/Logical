using System;
using System.Collections.Generic;
using System.Collections;
using Gates;
using Chips;
using Components;
using System.Linq;

namespace Logical
{
    class Program
    {
        static void Main(string[] args)
        {
            FlipFlopTest();

            double dd = 0;
            BaseComponent testCircuit = new Test3();
            //Chip testCircuit = new TestChip3();
            testCircuit.SetVDD(true);
            testCircuit.SetGround(false);
            //testCircuit.ResetGround();

            int maxBits = 4;
            for(int i = 0; i < Math.Pow(2,maxBits); i++)
            {
                string binary = Convert.ToString(i, 2);

                while(binary.Length < maxBits)
                {
                    binary = "0" + binary;
                }

                BitArray bitArray = new BitArray(binary.Select(c => c == '1').ToArray());

                //testCircuit.SetInputBits(bitArray);
                testCircuit.SetBits(bitArray);

                var watch = System.Diagnostics.Stopwatch.StartNew();                

                testCircuit.Update();

                watch.Stop();                
                
                for(int j = 0; j < maxBits; j++)
                {
                    Console.Write(binary[j] + " ");                    
                }

                Console.Write("=> ");

                // For testing chips
                for(int j = 0; j < testCircuit.Pins.Length; j++)
                {
                    Console.Write(testCircuit.Pins[j] ? "1 " : "0 ");
                }

                Console.Write(" - " + (watch.Elapsed.TotalMilliseconds * 1000).ToString() + "us");
                dd += (watch.Elapsed.TotalMilliseconds * 1000);

                //For testing gates
                // Console.Write(testCircuit.Output);

                Console.WriteLine("");

            }

            Console.WriteLine("Average: " + (dd / Math.Pow(2, maxBits)).ToString() + "us");
            
            Console.Write("Press any key to exit...");
            Console.ReadKey();
        }

        public static void FlipFlopTest()
        {
            Chip testCircuit = new FlipFlop();
            testCircuit.SetVDD(true); 
            testCircuit.SetGround(false);

            Console.WriteLine("S R | Q     Q'   ");

            testCircuit.SetInputBit(1, true).SetInputBit(0, false);
            testCircuit.Update();
            Console.WriteLine("1 0 | " + testCircuit.Output[0] + " " + testCircuit.Output[1]);

            testCircuit.SetInputBit(1, true).SetInputBit(0, true);
            testCircuit.Update();
            Console.WriteLine("1 1 | " + testCircuit.Output[0] + " " + testCircuit.Output[1]);

            testCircuit.SetInputBit(1, false).SetInputBit(0, true);
            testCircuit.Update();
            Console.WriteLine("0 1 | " + testCircuit.Output[0] + " " + testCircuit.Output[1]);

            testCircuit.SetInputBit(1, true).SetInputBit(0, true);
            testCircuit.Update();
            Console.WriteLine("1 1 | " + testCircuit.Output[0] + " " + testCircuit.Output[1]);

            testCircuit.SetInputBit(1, false).SetInputBit(0, false);
            testCircuit.Update();
            Console.WriteLine("0 0 | " + testCircuit.Output[0] + " " + testCircuit.Output[1]);

        }

    }

}
