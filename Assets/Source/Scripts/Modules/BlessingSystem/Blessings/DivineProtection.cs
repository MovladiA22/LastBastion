using UnityEngine;
using UnityUtilities.Coroutines;

namespace LastBastion.BlessingSystem
{
    public abstract class DivineProtection : DivineIntervention<IProtectable>
    {
        [SerializeField] private float _timeOfProtection;

        private CoroutineTimer _protectingTimer;

        protected bool IsActivate => !_protectingTimer.IsTimeUp;

        public override void Init()
        {
            _protectingTimer = new CoroutineTimer(this, _timeOfProtection, Deactivate);
        }

        public override void Activate()
        {
            base.Activate();

            DivineTarget.IsInvulnerable = true;
            _protectingTimer.Run();
        }

        public override void Deactivate()
        {
            base.Deactivate();

            ParticleSystem.Stop();
            DivineTarget.IsInvulnerable = false;
        }
    }
}
