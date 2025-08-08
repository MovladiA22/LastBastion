using Common.VariableSystem.Interfaces;
using System;

namespace Common.VariableSystem
{
    public class IntVariableToFloatConverter : IVariable<float>
    {
        private readonly IVariable<int> _intVariable;

        public IntVariableToFloatConverter(IVariable<int> intVariable)
        {
            _intVariable = intVariable ?? throw new ArgumentNullException(nameof(intVariable));
            _intVariable.OnChanged += () => OnChanged?.Invoke();
        }

        public event Action OnChanged;

        public float MaxValue => _intVariable.MaxValue;
        public float CurrentValue => _intVariable.CurrentValue;
    }
}
