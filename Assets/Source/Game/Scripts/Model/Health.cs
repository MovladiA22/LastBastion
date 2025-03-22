using System;
using UnityEngine;

namespace LastBastion.Model
{
    public class Health
    {
        private readonly int _maxValue;

        public Health(int maxValue)
        {
            if (maxValue <= 0)
                throw new ArgumentOutOfRangeException(nameof(maxValue));
            
            _maxValue = maxValue;
            CurrentValue = maxValue;
        }

        public int CurrentValue { get; private set; }

        public void Decrease(int amount)
        {
            if (amount < 0)
                throw new ArgumentOutOfRangeException(nameof(amount));

            CurrentValue = Mathf.Max(CurrentValue - amount, 0);
        }

        public void Increase(int amount)
        {
            if (amount < 0)
                throw new ArgumentOutOfRangeException(nameof(amount));

            CurrentValue = Mathf.Min(CurrentValue + amount, _maxValue);
        }
    }
}
