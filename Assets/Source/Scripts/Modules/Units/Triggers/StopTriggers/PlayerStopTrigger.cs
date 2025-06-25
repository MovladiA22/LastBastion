using LastBastion.CombatSystem;
using UnityEngine;

namespace LastBastion.Units
{
    internal class PlayerStopTrigger : UnitStopTrigger
    {
        protected override bool IsNeedingStopper(Collider2D collision) =>
            base.IsNeedingStopper(collision) || collision.TryGetComponent<IEnemy>(out _);
    }
}
