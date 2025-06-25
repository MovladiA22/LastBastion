using System;
using UnityEngine;

namespace LastBastion.UpgradeSystem
{
    public abstract class ValueUpgrader<Value> : Upgrader
    {
        [SerializeField] private Value[] _values;

        private int _levelIndexlOffset = 1;

        public Value GetUpgradedValue()
        {
            if (_values.Length != Level.MaxValue)
                throw new ArgumentOutOfRangeException(nameof(_values));

            return _values[Level.CurrentValue - _levelIndexlOffset];
        }
    }
}
