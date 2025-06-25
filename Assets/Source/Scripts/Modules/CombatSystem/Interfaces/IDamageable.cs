using System;

namespace LastBastion.CombatSystem
{
    public interface IDamageable
    {
        event Action<IDamageable> OnHealthIsOver;

        void TakeDamage(int amount);
        void ReactToDamage();
    }
}