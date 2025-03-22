using System;
using System.Numerics;

namespace LastBastion.View.Interface
{
    public interface IDamageable
    {
        event Action<IDamageable> OnValueIsOver;

        void TakeDamage(int amount);
        void ReactToDamage();
    }
}
