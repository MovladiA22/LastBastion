using System;

namespace LastBastion.Model
{
    public class Damager
    {
        public Damager(int damage)
        {
            if (damage < 0)
                throw new ArgumentOutOfRangeException(nameof(damage));

            Damage = damage;
        }

        public int Damage { get; }
    }
}
