using LastBastion.Units.PlayerUnits;
using UnityEngine;

namespace LastBastion.Units.Triggers
{
    internal class VampireStopTrigger : EnemyStopTrigger
    {
        protected override bool IsNeedingStopper(Collider2D collision)
        {
            if (collision.TryGetComponent<PlayerUnit>(out _))
                return false;

            return base.IsNeedingStopper(collision);
        }
    }
}
