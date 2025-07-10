using LastBastion.BlessingSystem.Interfaces;
using Common.UnityUtilities.Coroutines;
using UnityEngine;
using System;

namespace LastBastion.BlessingSystem
{
    public abstract class DivineIntervention<Target> : Blessing where Target : IDivineIntervention
    {
        [SerializeField] private AudioSource _activatedSound;

        [field: SerializeField] protected ParticleSystem ParticleSystem { get; private set; }

        protected virtual float DeactivateDelay => ParticleSystem.main.duration;
        protected Target DivineTarget { get; private set; }
        protected CoroutineTimer DeactivateTimer { get; private set; }

        public virtual void Awake()
        {
            DeactivateTimer = new CoroutineTimer(this, DeactivateDelay, Deactivate);
        }

        public override void Activate()
        {
            if (DeactivateTimer.IsTimeUp == false)
                return;
            else if (DivineTarget == null)
                throw new ArgumentNullException(nameof(DivineTarget));

            base.Activate();

            ParticleSystem.Play();
            _activatedSound.Play();
            DeactivateTimer.Run();
        }

        public void SetBlessable(Target blessable) =>
            DivineTarget = blessable ?? throw new ArgumentNullException(nameof(blessable));
    }
}
