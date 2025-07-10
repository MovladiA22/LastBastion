using LastBastion.BlessingSystem.Interfaces;
using LastBastion.CombatSystem.Interfaces;
using UnityEngine;

namespace LastBastion.Units.EnemyUnits
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
