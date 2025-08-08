using System;

namespace Common.VariableSystem
{
    public class VariableFloatObject : VariableObject<float>
    {
        public VariableFloatObject(float maxValue) : base(maxValue) { }

        public override void SetMaxValue(float maxValue)
        {
            if (maxValue <= 0.0f)
                throw new ArgumentOutOfRangeException(nameof(maxValue));

            base.SetMaxValue(maxValue);
        }

        public override void SetValue(float value)
        {
            if (value < 0.0f || value > MaxValue)
                throw new ArgumentOutOfRangeException(nameof(value));

            base.SetValue(value);
        }

        public void Decrease(float amount)
        {
            if (amount < 0.0f)
                throw new ArgumentOutOfRangeException(nameof(amount));

            SetValue(Math.Max(CurrentValue - amount, 0.0f));
        }

        public void Increase(float amount)
        {
            if (amount < 0.0f)
                throw new ArgumentOutOfRangeException(nameof(amount));

            SetValue(Math.Min(CurrentValue + amount, MaxValue));
        }
    }
}
