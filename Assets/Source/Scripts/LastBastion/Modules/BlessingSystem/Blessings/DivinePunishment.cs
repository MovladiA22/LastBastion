using LastBastion.BlessingSystem.Interfaces;
using UnityEngine;

namespace LastBastion.BlessingSystem.Blessings
{
    public abstract class DivinePunishment : DivineIntervention<IPunishable>
    {
        [SerializeField] private int _damage;

        public override void Activate()
        {
            base.Activate();

            DivineTarget.TakePunish(_damage);
        }
    }
}
