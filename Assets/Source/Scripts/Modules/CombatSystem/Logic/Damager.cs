using System;

namespace LastBastion.CombatSystem
{
    public class Damager
    {
        private readonly int _damage;

        public Damager(int damage)
        {
            if (damage < 0)
                throw new ArgumentOutOfRangeException(nameof(damage));

            _damage = damage;
        }

        public void DealDamage(IDamageable damageable)
        {
            if (damageable == null)
                return;

            damageable.TakeDamage(_damage);
        }
    }
}
