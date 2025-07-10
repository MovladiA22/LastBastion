using LastBastion.CombatSystem.Interfaces;
using UnityEngine;

namespace LastBastion.Units.Triggers
{
    internal class EnemyStopTrigger : UnitStopTrigger
    {
        protected override bool IsNeedingStopper(Collider2D collision) =>
            base.IsNeedingStopper(collision) || collision.TryGetComponent<IPlayer>(out _);
    }
}
