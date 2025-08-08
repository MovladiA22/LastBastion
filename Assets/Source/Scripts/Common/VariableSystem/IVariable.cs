using System;

namespace Common.VariableSystem.Interfaces
{
    public interface IVariable<T> where T : struct
    {
        event Action OnChanged;

        T MaxValue { get; }
        T CurrentValue { get; }
    }
}
