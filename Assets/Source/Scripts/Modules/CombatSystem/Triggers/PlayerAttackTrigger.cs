using LastBastion.CombatSystem;
using UnityEngine;

namespace LastBastion.CombatSystem
{
    public class PlayerAttackTrigger : AttackTrigger
    {
        protected override void HandleTriggerEnter(Collider2D collision)
        {
            if (collision.TryGetComponent<IPlayer>(out _))
                base.HandleTriggerEnter(collision);
        }

        protected override void HandleTriggerExit(Collider2D collision)
        {
            if (collision.TryGetComponent<IPlayer>(out _))
                base.HandleTriggerExit(collision);
        }
    }
}
