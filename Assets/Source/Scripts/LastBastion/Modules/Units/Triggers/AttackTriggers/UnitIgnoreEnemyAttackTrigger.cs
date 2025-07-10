using LastBastion.CombatSystem.Triggers;
using UnityEngine;

namespace LastBastion.Units.Triggers
{
    internal class UnitIgnoreEnemyAttackTrigger : EnemyAttackTrigger
    {
        protected override void HandleTriggerEnter(Collider2D collision)
        {
            if (collision.TryGetComponent<Unit>(out _))
                return;

            base.HandleTriggerEnter(collision);
        }

        protected override void HandleTriggerExit(Collider2D collision)
        {
            if (collision.TryGetComponent<Unit>(out _))
                return;

            base.HandleTriggerExit(collision);
        }
    }
}
