﻿using System;
using System.Collections;
using System.Collections.Generic;

namespace Gates
{
    public class Gate
    {
        public Guid ID { get; set; }

        public bool VDD { get; set; }
        public bool Ground { get; set; }
        public BitArray Input { get; set; }
        public bool Output { get; set; }

        protected bool Dirty;

        protected Gate(int inputs)
        {
            ID = Guid.NewGuid();

            VDD = false;
            Ground = true;
            Input = new BitArray(inputs, false);
            Output = false;
            Dirty = false;
        }

        public bool IsDirty()
        {
            return Dirty;
        }

        public void SetVDD(bool value)
        {
            VDD = value;
            Update();
        }
        public void SetGround(bool value)
        {
            Ground = value;
            Update();
        }

        public Gate SetInputBit(int index, bool value)
        {
            if (index >= 0 && Input.Length > index)
            {
                Input[index] = value;
            }

            return this;
        }
        public Gate SetInputBits(BitArray input)
        {
            if (input.Length == Input.Length)
            {
                for(int i = 0; i < input.Length; i++)
                {
                    SetInputBit(i, input[i]);
                }
            }

            return this;
        }

        public bool Update()
        {
            bool oldOutput = Output;

            if (!VDD || Ground)
            {
                Output = false;
            }
            else
            {
                Output = GetOutput();
            }            

            Dirty = oldOutput != Output;

            return Output;
        }

        protected virtual bool GetOutput() { return false; }
    }

    public class ANDGate : Gate
    {
        public ANDGate(int inputs) : base(inputs) { }
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
        public NANDGate(int inputs) : base(inputs) { }
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
        public ORGate(int inputs) : base(inputs) { }
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
        public NORGate(int inputs) : base(inputs) { }
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
        public XORGate(int inputs) : base(inputs) { }
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
        public XNORGate(int inputs) : base(inputs) { }
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
