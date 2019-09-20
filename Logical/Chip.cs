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

        protected Chip(int inputs, int outputs)
        {
            VDD = false;
            Ground = true;
            Input = new BitArray(inputs, false);
            Output = new BitArray(outputs, false);
        }

        public Chip SetInputBit(int index, bool value)
        {
            if (index >= 0 && Input.Length > index)
            {
                Input[index] = value;
            }

            return this;
        }

        public bool GetUpdatedOutput() { return GetUpdatedOutput(-1, false); }
        public bool GetUpdatedOutput(int index, bool value)
        {
            Update(index, value);
            return Output[0];
        }
        public void Update() { Update(-1, false); }
        public virtual void Update(int index, bool value) { }
    }

    public class AND4Chip : Chip
    {
        public AND4Chip() : base(8, 2) { }

        public override void Update(int index, bool value)
        {
            if (index >= 0 && Input.Length > index)
            {
                Input[index] = value;
            }

            bool output = Input[0];
            for (int i = 0; i < 4; i++)
            {
                output &= Input[i];
            }
            Output[0] = output && VDD && !Ground;

            output = Input[4];
            for (int i = 4; i < 8; i++)
            {
                output &= Input[i];
            }
            Output[1] = output && VDD && !Ground;
        }

    }
}
