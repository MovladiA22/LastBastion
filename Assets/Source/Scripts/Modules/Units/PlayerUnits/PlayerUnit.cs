using LastBastion.BlessingSystem;
using LastBastion.CombatSystem;
using Common.Interfaces;
using UnityEngine;

namespace LastBastion.Units
{
    public class PlayerUnit : Unit, IPlayer, IProtectable
    {
        public bool IsInvulnerable { get; set; }

        public override void TakeDamage(int amount)
        {
            if (IsInvulnerable)
                return;

            base.TakeDamage(amount);
        }
    }
}
