using Chips;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Components
{
    public class BaseComponent
    {
        // The actual values of the pins
        public BitArray Pins { get; set; }
        //Whether the pins are inputs or outputs
        public BitArray Inputs { get; set; }
        // If the pins are Dirty
        // public BitArray Dirty { get; }

        public void SetBit(int index, bool value)
        {
            if (Inputs[index] == true)
            {
                Pins[index] = value;
            }
        }
        public void SetBits(BitArray bits)
        {
            int i_stop = Math.Min(Pins.Length, bits.Length);

            for(int i = 0; i < i_stop; i++)
            {
                SetBit(i, bits[i]);
            }
        }

        public virtual void SetVDD(bool value) { }
        public virtual void ResetVDD() { }
        public virtual void SetGround(bool value) { }
        public virtual void ResetGround() { }
        public virtual void Update() { }
        
    }

    public class Switch : BaseComponent
    {
        public Switch()
        {
            Pins = new BitArray(2, false);
            Inputs = new BitArray(new bool[2] { true, false });
        }

        public override void Update()
        {
            Pins[4] = (Pins[0] || Pins[1]) && (Pins[2] || Pins[3]);
        }
    }

    public class Test3 : BaseComponent
    {
        public Test3()
        {
            Pins = new BitArray(5, false);
            Inputs = new BitArray(new bool[5] { true, true, true, true, false });
        }

        public override void Update()
        {
            Pins[4] = (Pins[0] || Pins[1]) && (Pins[2] || Pins[3]);
        }

    }

    public class Test3Chip : BaseComponent
    {
        Chip chip;

        public Test3Chip()
        {
            Pins = new BitArray(5, false);
            Inputs = new BitArray(new bool[5] { true, true, true, true, false });

            chip = new TestChip3();            
        }

        public override void Update()
        {
            chip.SetInputBit(0, Pins[0]).SetInputBit(1, Pins[1]).SetInputBit(2, Pins[2]).SetInputBit(3, Pins[3]);
            chip.Update();
            Pins[4] = chip.Output[0];
        }

        public override void SetVDD(bool value)
        {
            chip.SetVDD(value);
        }
        public override void ResetVDD()
        {
            chip.SetVDD(false);
        }
        public override void SetGround(bool value)
        {
            chip.SetGround(value);
        }
        public override void ResetGround()
        {
            chip.SetGround(true);
        }

    }

}