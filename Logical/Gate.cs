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

        protected Gate(int inputs)
        {
            VDD = false;
            Ground = true;
            Input = new BitArray(inputs, false);
            Output = false;
        }

        public Gate SetInputBit(int index, bool value)
        {
            if (index >= 0 && Input.Length > index)
            {
                Input[index] = value;
            }

            return this;
        }

        public bool GetUpdatedOutput(int index, bool value)
        {
            Update(index, value);
            return Output;
        }
        public virtual void Update(int index, bool value) { }
    }

    public class ANDGate : Gate
    {
        public ANDGate() : base(2) { }

        public override void Update(int index, bool value)
        {
            if (index >= 0 && Input.Length > index)
            {
                Input[index] = value;

                bool output = Input[0];
                foreach (bool bit in Input)
                {
                    output &= bit;
                }
                Output = output && VDD && !Ground;
            }
        }
    }

    public class NANDGate : Gate
    {
        public NANDGate() : base(2) { }

        public override void Update(int index, bool value)
        {
            if (index >= 0 && Input.Length > index)
            {
                Input[index] = value;

                bool output = Input[0];
                foreach (bool bit in Input)
                {
                    output &= bit;
                }
                Output = !output && VDD && !Ground;
            }
        }
    }

    public class ORGate : Gate
    {
        public ORGate() : base(2) { }

        public override void Update(int index, bool value)
        {
            if (index >= 0 && Input.Length > index)
            {
                Input[index] = value;

                bool output = Input[0];
                foreach (bool bit in Input)
                {
                    output |= bit;
                }
                Output = output && VDD && !Ground;
            }
        }
    }

    public class NORGate : Gate
    {
        public NORGate() : base(2) { }

        public override void Update(int index, bool value)
        {
            if (index >= 0 && Input.Length > index)
            {
                Input[index] = value;

                bool output = Input[0];
                foreach (bool bit in Input)
                {
                    output |= bit;
                }
                Output = !output && VDD && !Ground;
            }
        }
    }

    public class XORGate : Gate
    {
        public XORGate() : base(2) { }

        public override void Update(int index, bool value)
        {
            if (index >= 0 && Input.Length > index)
            {
                Input[index] = value;

                bool output = Input[0];
                foreach (bool bit in Input)
                {
                    output ^= bit;
                }
                Output = output && VDD && !Ground;
            }
        }
    }

    public class XNORGate : Gate
    {
        public XNORGate() : base(2) { }

        public override void Update(int index, bool value)
        {
            if (index >= 0 && Input.Length > index)
            {
                Input[index] = value;

                bool output = Input[0];
                foreach (bool bit in Input)
                {
                    output ^= bit;
                }
                Output = !output && VDD && !Ground;
            }
        }
    }

    public class BufferGate : Gate
    {
        public BufferGate() : base(1) { }

        public override void Update(int index, bool value)
        {
            if (index >= 0 && Input.Length > index)
            {
                Input[index] = value;
                Output = value && VDD && !Ground;
            }
        }
    }

    public class NotGate : Gate
    {
        public NotGate() : base(1) { }

        public override void Update(int index, bool value)
        {
            if (index >= 0 && Input.Length > index)
            {
                Input[index] = value;
                Output = !value && VDD && !Ground;
            }
        }
    }
}
