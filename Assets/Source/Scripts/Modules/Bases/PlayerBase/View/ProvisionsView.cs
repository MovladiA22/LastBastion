using System;
using UnityEngine;
using UnityEngine.UI;
using Common.Interfaces;
using System.Collections;
using Common.VariableSystem;
using UnityUtilities.Coroutines;

namespace LastBastion.Bases
{
    internal class ProvisionsView : ManagedBehavior
    {
        [SerializeField] private Slider _slider;

        private IVariableInt _provisions;
        private CoroutineRunner _coroutineRunner;

        public override void Init()
        {
            _coroutineRunner = new CoroutineRunner(this, RenderingSmooth);
        }

        public override void Activate()
        {
            base.Activate();

            if (_provisions == null)
                throw new ArgumentNullException(nameof(_provisions));

            _coroutineRunner.Run();
        }

        public override void Deactivate()
        {
            base.Deactivate();

            if (_provisions == null)
                throw new ArgumentNullException(nameof(_provisions));

            _coroutineRunner.Cancel();
        }

        public void SetProvisions(IVariableInt provisions) =>
            _provisions = provisions ?? throw new ArgumentNullException(nameof(provisions));

        private IEnumerator RenderingSmooth()
        {
            float targetValue = 0.0f;
            _slider.value = _slider.maxValue;

            while (_slider.value != targetValue)
            {
                _slider.value = Mathf.Lerp(_slider.value, targetValue, Time.deltaTime / _provisions.CurrentValue);

                yield return null;
            }
        }
    }
}
