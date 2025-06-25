using UnityEngine;

namespace LastBastion.CombatSystem
{
    public class EnemyAttackTrigger : AttackTrigger
    {
        protected override void HandleTriggerEnter(Collider2D collision)
        {
            if (collision.TryGetComponent<IEnemy>(out _))
                base.HandleTriggerEnter(collision);
        }

        protected override void HandleTriggerExit(Collider2D collision)
        {
            if (collision.TryGetComponent<IEnemy>(out _))
                base.HandleTriggerExit(collision);
        }
    }
}
