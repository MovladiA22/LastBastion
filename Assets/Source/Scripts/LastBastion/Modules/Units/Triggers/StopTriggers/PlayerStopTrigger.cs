using LastBastion.CombatSystem.Interfaces;
using UnityEngine;

namespace LastBastion.Units.Triggers
{
    internal class PlayerStopTrigger : UnitStopTrigger
    {
        protected override bool IsNeedingStopper(Collider2D collision) =>
            base.IsNeedingStopper(collision) || collision.TryGetComponent<IEnemy>(out _);
    }
}
