using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logical
{
    public class Chip
    {
        public bool VDD { get; set; }
        public bool Ground { get; set; }
        public BitArray Input { get; set; }
        public BitArray Output { get; set; }
        public List<Gate> Gates { get; set; }

        protected Chip(int inputs, int outputs)
        {
            VDD = false;
            Ground = true;
            Input = new BitArray(inputs, false);
            Output = new BitArray(outputs, false);
            Gates = new List<Gate>();
        }

        protected void AddGate(Gate gate, int[] inputLines, int outputLine)
        {
            Gates.Add(gate);
        }

    }

    public class AND4Chip : Chip
    {
        AND4Chip() : base(8, 2) { }



    }
}
