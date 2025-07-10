using System;
using UnityEngine;

namespace LastBastion.UpgradeSystem
{
    public abstract class ValueUpgrader<Value> : Upgrader
    {
        private const int LevelIndexlOffset = 1;

        [SerializeField] private Value[] _values;

        public Value GetUpgradedValue()
        {
            if (_values.Length != Level.MaxValue)
                throw new ArgumentOutOfRangeException(nameof(_values));

            return _values[Level.CurrentValue - LevelIndexlOffset];
        }
    }
}
