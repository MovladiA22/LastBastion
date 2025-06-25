using LastBastion.CombatSystem;
using UnityEngine;

namespace LastBastion.Units
{
    internal class EnemyUnitAttackTrigger : AttackTrigger
    {
        protected override void HandleTriggerEnter(Collider2D collision)
        {
            if (collision.TryGetComponent<EnemyUnit>(out _))
                base.HandleTriggerEnter(collision);
        }

        protected override void HandleTriggerExit(Collider2D collision)
        {
            if (collision.TryGetComponent<EnemyUnit>(out _))
                base.HandleTriggerExit(collision);
        }
    }
}
