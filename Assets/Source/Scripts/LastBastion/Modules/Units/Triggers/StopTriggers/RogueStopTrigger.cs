using LastBastion.CombatSystem.Interfaces;
using LastBastion.Units.PlayerUnits;
using UnityEngine;

namespace LastBastion.Units.Triggers
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
