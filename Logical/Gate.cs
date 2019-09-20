using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logical
{
    public class Gate
    {

        public bool VDD { get; set; }
        public bool Ground { get; set; }
        public BitArray Input { get; set; }
        public bool Output { get; set; }

        protected bool Dirty;

        protected Gate(int inputs)
        {
            VDD = false;
            Ground = true;
            Input = new BitArray(inputs, false);
            Output = false;
            Dirty = false;
        }

        public Gate SetInputBit(int index, bool value)
        {
            if (index >= 0 && Input.Length > index)
            {
                if (Input[index] != value)
                {
                    Input[index] = value;
                    Dirty = true;
                }
            }

            return this;
        }

        public bool GetUpdatedOutput() { return GetUpdatedOutput(-1, false); }
        public bool GetUpdatedOutput(int index, bool value)
        {
            Update(index, value);
            return Output;
        }
        public void Update() { Update(-1, false); }
        public void Update(int index, bool value) {
            SetInputBit(index, value);

            if (Dirty)
            {
                Dirty = false;
                Output = GetOutput() && VDD && !Ground;
            }
        }

        protected virtual bool GetOutput() { return false; }
    }

    public class ANDGate : Gate
    {
        public ANDGate() : base(2) { }

        protected override bool GetOutput()
        {
            bool output = Input[0];
            foreach (bool bit in Input)
            {
                output &= bit;
            }
            return output;
        }
    }

    public class NANDGate : Gate
    {
        public NANDGate() : base(2) { }

        protected override bool GetOutput()
        {
            bool output = Input[0];
            foreach (bool bit in Input)
            {
                output &= bit;
            }
            return !output;
        }
    }

    public class ORGate : Gate
    {
        public ORGate() : base(2) { }

        protected override bool GetOutput()
        {
            bool output = Input[0];
            foreach (bool bit in Input)
            {
                output |= bit;
            }
            return output;
        }
    }

    public class NORGate : Gate
    {
        public NORGate() : base(2) { }

        protected override bool GetOutput()
        {
            bool output = Input[0];
            foreach (bool bit in Input)
            {
                output |= bit;
            }
            return !output;
        }
    }

    public class XORGate : Gate
    {
        public XORGate() : base(2) { }

        protected override bool GetOutput()
        {
            bool output = Input[0];
            for (int i = 1; i < Input.Length; i++)
            {
                output ^= Input[i];
            }
            return output;
        }
    }

    public class XNORGate : Gate
    {
        public XNORGate() : base(2) { }

        protected override bool GetOutput()
        {
            bool output = Input[0];
            for (int i = 1; i < Input.Length; i++)
            {
                output ^= Input[i];
            }
            return !output;
        }
    }

    public class BufferGate : Gate
    {
        public BufferGate() : base(1) { }

        protected override bool GetOutput()
        {
            return Input[0];
        }
    }

    public class NotGate : Gate
    {
        public NotGate() : base(1) { }

        protected override bool GetOutput()
        {
            return !Input[0];
        }
    }
}
