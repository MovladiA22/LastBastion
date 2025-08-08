using System;
using UnityEngine;
using UnityEngine.UI;
using Common.VariableSystem.Interfaces;

namespace Common.UI.Output
{
    public class BarRenderer : MonoBehaviour
    {
        [SerializeField] private Slider _slider;

        private IVariable<float> _variable;

        private void OnDisable()
        {
            if (_variable != null)
            {
                _variable.OnChanged -= Render;
                _variable = null;
            }
        }

        public void SetVariable(IVariable<float> variable)
        {
            _variable = variable ?? throw new ArgumentNullException(nameof(variable));
            _variable.OnChanged += Render;

            Render();
        }

        private void Render()
        {
            if (_slider != null)
                _slider.value = _variable.CurrentValue / _variable.MaxValue;
        }
    }
}
