using LastBastion.BlessingSystem.Interfaces;
using LastBastion.CombatSystem.Interfaces;

namespace LastBastion.Units.PlayerUnits
{
    public class PlayerUnit : Unit, IPlayer, IProtectable
    {
        public bool IsInvulnerable { get; set; }

        protected override void OnDisable()
        {
            base.OnDisable();

            IsInvulnerable = false;
        }

        public override void TakeDamage(int amount)
        {
            if (IsInvulnerable)
                return;

            base.TakeDamage(amount);
        }
    }
}
