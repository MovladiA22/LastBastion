using LastBastion.CombatSystem;
using UnityEngine;

namespace LastBastion.Units
{
    internal class RogueStopTrigger : PlayerStopTrigger
    {
        protected override bool IsNeedingStopper(Collider2D collision)
        {
            if (collision.TryGetComponent<Unit>(out _) == false && collision.TryGetComponent<IEnemy>(out _))
                return true;

            return collision.TryGetComponent<Rogue>(out _);
        }
    }
}
