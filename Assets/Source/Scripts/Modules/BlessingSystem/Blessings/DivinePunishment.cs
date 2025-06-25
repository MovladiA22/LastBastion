using UnityEngine;

namespace LastBastion.BlessingSystem
{
    public abstract class DivinePunishment : DivineIntervention<IPunishable>
    {
        [SerializeField] private int _damage;

        public override void Activate()
        {
            base.Activate();

            DivineTarget.TakePunish(_damage);

            Invoke(nameof(Deactivate), ParticleSystem.main.duration);
        }
    }
}
