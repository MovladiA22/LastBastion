using LastBastion.CombatSystem;
using UnityEngine;

namespace LastBastion.Units
{
    internal class EnemyStopTrigger : UnitStopTrigger
    {
        protected override bool IsNeedingStopper(Collider2D collision) =>
            base.IsNeedingStopper(collision) || collision.TryGetComponent<IPlayer>(out _);
    }
}
