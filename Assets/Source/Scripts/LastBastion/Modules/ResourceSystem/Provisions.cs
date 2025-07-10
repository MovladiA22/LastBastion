using Common.VariableSystem.Interfaces;
using Common.VariableSystem;
using UnityEngine;
using System;

namespace LastBastion.ResourceSystem
{
    public class Provisions : VariableIntObject, IVariableInt
    {
        private const float OneSecond = 1f;
        private const int MinMultiplier = 1;

        private float _timer = 0f;

        public Provisions(int maxValue) : base(maxValue) { }

        public event Action OnOutOfProvisions;

        public void UpdateProvisionsDecrease(int multiplier = MinMultiplier)
        {
            if (CurrentValue == 0)
                return;
            else if (multiplier < MinMultiplier)
                multiplier = MinMultiplier;

            _timer += Time.deltaTime;

            if (_timer >= OneSecond)
            {
                _timer = 0f;
                Decrease((int)OneSecond * multiplier);

                if (CurrentValue == 0)
                    OnOutOfProvisions?.Invoke();
            }
        }

        public void UpdateProvisionsIncrease(int multiplier = MinMultiplier)
        {
            if (CurrentValue == MaxValue)
                return;
            else if (multiplier < MinMultiplier)
                multiplier = MinMultiplier;

            _timer += Time.deltaTime;

            if (_timer >= OneSecond)
            {
                _timer = 0f;
                Increase((int)OneSecond * multiplier);
            }
        }
    }
}
