using LastBastion.CombatSystem;
using UnityEngine;

namespace LastBastion.Units
{
    internal class ArcherStopTrigger :PlayerStopTrigger
    {
        protected override bool IsNeedingStopper(Collider2D collision) =>
            collision.TryGetComponent<Archer>(out _) || collision.TryGetComponent<IEnemy>(out _);
    }
}
