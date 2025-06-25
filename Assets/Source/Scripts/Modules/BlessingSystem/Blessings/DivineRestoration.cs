using System.Collections;
using UnityEngine;
using UnityUtilities.Coroutines;

namespace LastBastion.BlessingSystem
{
    public abstract class DivineRestoration : DivineIntervention<IRestorable>
    {
        [SerializeField] private int _valueOfRestoration;

        private CoroutineTimer _timer;

        public override void Init()
        {
            _timer = new CoroutineTimer(this, ParticleSystem.main.duration, Deactivate);
        }

        public override void Activate()
        {
            if(_timer.IsTimeUp == false)
                return;

            base.Activate();

            _timer.Run();

            DivineTarget.Restore(_valueOfRestoration);
        }
    }
}
