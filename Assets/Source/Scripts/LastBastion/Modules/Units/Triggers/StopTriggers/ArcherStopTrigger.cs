using LastBastion.CombatSystem.Interfaces;
using LastBastion.Units.PlayerUnits;
using UnityEngine;

namespace LastBastion.Units.Triggers
{
    internal class ArcherStopTrigger :PlayerStopTrigger
    {
        protected override bool IsNeedingStopper(Collider2D collision) =>
            collision.TryGetComponent<Archer>(out _) || collision.TryGetComponent<IEnemy>(out _);
    }
}
