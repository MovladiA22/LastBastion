using UnityEngine;
using System;

namespace LastBastion.BlessingSystem
{
    public abstract class DivineIntervention<Target> : Blessing where Target : IDivineIntervention
    {
        [SerializeField] private AudioSource _activatedSound;

        protected Target DivineTarget { get; private set; }

        [field: SerializeField] protected ParticleSystem ParticleSystem { get; private set; }

        public override void Activate()
        {
            if (DivineTarget == null)
                throw new ArgumentNullException(nameof(DivineTarget));

            base.Activate();

            ParticleSystem.Play();
            _activatedSound.Play();
        }

        protected void SetBlessable(Target blessable) =>
            DivineTarget = blessable ?? throw new ArgumentNullException(nameof(blessable));
    }
}
