using LastBastion.CombatSystem;
using UnityEngine;

namespace LastBastion.Bases
{
    internal class BaseIgnoreAttackTrigger : EnemyAttackTrigger
    {
        protected override void HandleTriggerEnter(Collider2D collision)
        {
            if (collision.TryGetComponent<Base>(out _))
                return;

            base.HandleTriggerEnter(collision);
        }
    }
}
