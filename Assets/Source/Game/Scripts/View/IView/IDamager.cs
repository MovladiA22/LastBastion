using System;

namespace LastBastion.View.Interface
{
    public interface IDamager
    {
        event Action<IDamageable> OnAttacked;

        void Attack(IDamageable damageable);
    }
}
