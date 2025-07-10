using LastBastion.BlessingSystem.Interfaces;
using UnityEngine;

namespace LastBastion.BlessingSystem.Blessings
{
    public abstract class DivineRestoration : DivineIntervention<IRestorable>
    {
        [SerializeField] private int _valueOfRestoration;

        public override void Activate()
        {
            base.Activate();

            DivineTarget.Restore(_valueOfRestoration);
        }
    }
}
