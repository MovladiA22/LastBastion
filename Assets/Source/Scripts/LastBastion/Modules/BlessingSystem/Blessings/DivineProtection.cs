using LastBastion.BlessingSystem.Interfaces;
using UnityEngine;

namespace LastBastion.BlessingSystem.Blessings
{
    public abstract class DivineProtection : DivineIntervention<IProtectable>
    {
        [SerializeField] private float _timeOfProtection;

        protected bool IsActivate => DeactivateTimer.IsTimeUp == false;
        protected override float DeactivateDelay => _timeOfProtection;

        public override void Activate()
        {
            base.Activate();

            DivineTarget.IsInvulnerable = true;
        }

        public override void Deactivate()
        {
            base.Deactivate();

            ParticleSystem.Stop();
            DivineTarget.IsInvulnerable = false;
        }
    }
}
