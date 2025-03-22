using System;

namespace LastBastion.View.Interface
{
    public interface IHealthView
    {
        event Action<int> OnValueIncreased;
        event Action<int> OnValueDecreased;
    }
}
