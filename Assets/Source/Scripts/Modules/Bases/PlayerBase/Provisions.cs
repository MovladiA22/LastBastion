using UnityEngine;
using Common.VariableSystem;
using System;

namespace LastBastion.Bases
{
    internal class Provisions : VariableIntObject, IVariableInt
    {
        private const float OneSecond = 1f;

        private float _timer = 0f;

        public event Action OnOutOfProvisions;

        public Provisions(int maxValue) : base(maxValue) { }

        public bool IsActivated { get; private set; } = false;

        public void UpdateProvisionsDecrease()
        {
            if (CurrentValue == 0)
                return;

            _timer += Time.deltaTime;

            if (_timer >= OneSecond)
            {
                _timer = 0f;
                Decrease((int)OneSecond);

                if (CurrentValue == 0)
                    OnOutOfProvisions?.Invoke();
            }
        }
    }
}
