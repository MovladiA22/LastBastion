using LastBastion.BlessingSystem;
using LastBastion.CombatSystem;
using UnityEngine;

namespace LastBastion.Units
{
    public class EnemyUnit : Unit, IEnemy, IPunishable
    {
        [field: SerializeField, Min(0)] public int BountyGold { get; private set; }

        public void TakePunish(int damage)
        {
            TakeDamage(damage);
        }
    }
}
