using System;

namespace Common.VariableSystem
{
    public class VariableIntObject : IVariableInt
    {
        public event Action OnChanged;

        public VariableIntObject(int maxValue)
        {
            SetMaxValue(maxValue);
        }

        public int MaxValue {  get; private set; }
        public int CurrentValue {  get; private set; }

        public void SetMaxValue(int maxValue)
        {
            if (maxValue <= 0)
                throw new ArgumentOutOfRangeException(nameof(maxValue));

            MaxValue = maxValue;
            CurrentValue = maxValue;

            OnChanged?.Invoke();
        }

        public void ReplenishFullValue() =>
            Increase(MaxValue);

        public void Decrease(int amount)
        {
            if (amount < 0)
                throw new ArgumentOutOfRangeException(nameof(amount));

            CurrentValue = Math.Max(CurrentValue - amount, 0);
            OnChanged?.Invoke();
        }

        public void Increase(int amount)
        {
            if (amount < 0)
                throw new ArgumentOutOfRangeException(nameof(amount));

            CurrentValue = Math.Min(CurrentValue + amount, MaxValue);
            OnChanged?.Invoke();
        }
    }
}
