using System;

namespace LastBastion.CombatSystem.Interfaces
{
    public interface IDamageable
    {
        event Action<IDamageable> OnHealthIsOver;

        void TakeDamage(int amount);
    }
}