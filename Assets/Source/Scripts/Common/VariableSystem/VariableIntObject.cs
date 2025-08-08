using System;
using UnityEngine;

namespace Common.VariableSystem
{
    public class VariableIntObject : VariableObject<int>
    {
        public VariableIntObject(int maxValue) : base(maxValue) { }

        public override void SetMaxValue(int maxValue)
        {
            if (maxValue <= 0)
                throw new ArgumentOutOfRangeException(nameof(maxValue));

            base.SetMaxValue(maxValue);
        }

        public override void SetValue(int value)
        {
            if (value < 0 || value > MaxValue)
                throw new ArgumentOutOfRangeException(nameof(value));

            base.SetValue(value);
        }

        public void Decrease(int amount)
        {
            if (amount < 0)
                throw new ArgumentOutOfRangeException(nameof(amount));

            SetValue(Math.Max(CurrentValue - amount, 0));
        }

        public void Increase(int amount)
        {
            if (amount < 0)
                throw new ArgumentOutOfRangeException(nameof(amount));

            SetValue(Math.Min(CurrentValue + amount, MaxValue));
        }
    }
}
