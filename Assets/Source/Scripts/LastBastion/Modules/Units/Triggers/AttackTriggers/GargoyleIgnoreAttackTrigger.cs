using LastBastion.CombatSystem.Triggers;
using LastBastion.Units.EnemyUnits;
using UnityEngine;

namespace LastBastion.Units.Triggers
{
    internal class GargoyleIgnoreAttackTrigger : EnemyAttackTrigger
    {
        protected override void HandleTriggerEnter(Collider2D collision)
        {
            if (collision.TryGetComponent<Gargoyle>(out _))
                return;

            base.HandleTriggerEnter(collision);
        }

        protected override void HandleTriggerExit(Collider2D collision)
        {
            if (collision.TryGetComponent<Gargoyle>(out _))
                return;

            base.HandleTriggerExit(collision);
        }
    }
}
