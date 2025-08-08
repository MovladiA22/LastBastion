using Common.VariableSystem.Interfaces;
using System;

namespace Common.VariableSystem
{
    public class VariableObject<T> : IVariable<T> where T : struct
    {
        public VariableObject(T maxValue)
        {
            SetMaxValue(maxValue);
            SetValue(maxValue);
        }

        public event Action OnChanged;

        public T MaxValue { get; private set; }
        public T CurrentValue { get; private set; }

        public virtual void SetMaxValue(T maxValue)
        {
            MaxValue = maxValue;
        }

        public virtual void SetValue(T value)
        {
            CurrentValue = value;

            OnChanged?.Invoke();
        }
    }
}
