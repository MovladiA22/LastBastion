using System;
using UnityEngine;
using UnityEngine.UI;
using Common.VariableSystem;

namespace Common.UI.View
{
    public class BarRenderer : MonoBehaviour
    {
        [SerializeField] private Slider _slider;

        private IVariableInt _variable;

        protected float SliderValue => _slider.value;

        private void OnDisable()
        {
            if (_variable != null)
                _variable.OnChanged -= Render;
        }

        public void Init(IVariableInt variable)
        {
            _variable = variable ?? throw new ArgumentNullException(nameof(variable));
            _variable.OnChanged += Render;

            Render();
        }

        private void Render()
        {
            if (_slider != null)
                _slider.value = (float)_variable.CurrentValue / _variable.MaxValue;
        }
    }
}
