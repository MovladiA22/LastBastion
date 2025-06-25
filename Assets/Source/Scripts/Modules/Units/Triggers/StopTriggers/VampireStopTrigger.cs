using UnityEngine;

namespace LastBastion.Units
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
