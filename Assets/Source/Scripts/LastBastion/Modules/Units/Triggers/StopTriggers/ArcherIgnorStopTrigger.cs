using LastBastion.Units.PlayerUnits;
using UnityEngine;

namespace LastBastion.Units.Triggers
{
    internal class ArcherIgnorStopTrigger: PlayerStopTrigger
    {
        protected override bool IsNeedingStopper(Collider2D collision)
        {
            if (collision.TryGetComponent<Archer>(out _))
                return false;

            return base.IsNeedingStopper(collision);
        }
    }
}
