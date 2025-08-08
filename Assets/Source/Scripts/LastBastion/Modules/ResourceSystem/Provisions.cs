using Common.VariableSystem;
using UnityEngine;
using System;

namespace LastBastion.ResourceSystem
{
    public class Provisions : VariableFloatObject
    {
        private const int MinMultiplier = 1;

        public Provisions(float maxValue) : base(maxValue) { }

        public event Action OnOutOfProvisions;

        public void UpdateProvisionsDecrease(int multiplier = MinMultiplier)
        {
            if (CurrentValue == 0.0f)
                return;
            else if (multiplier < MinMultiplier)
                multiplier = MinMultiplier;

            Decrease(Time.deltaTime * multiplier);

            if (CurrentValue == 0.0f)
                OnOutOfProvisions?.Invoke();
        }

        public void UpdateProvisionsIncrease(int multiplier = MinMultiplier)
        {
            if (CurrentValue == MaxValue)
                return;
            else if (multiplier < MinMultiplier)
                multiplier = MinMultiplier;

            Increase(Time.deltaTime * multiplier);
        }
    }
}
