using Common.VariableSystem.Interfaces;
using Common.UnityUtilities.Behaviors;
using System;

namespace Common.UI.Output
{
    public class VariableIntTextRenderer : TextRenderer, IActivable
    {
        private IVariable<int> _variable;

        public bool IsActivated { get; private set; }

        private void OnDisable()
        {
            if (_variable != null)
                _variable.OnChanged -= RenderVariable;
        }

        public void Activate()
        {
            if (IsActivated)
                return;

            if (_variable == null)
                throw new ArgumentNullException(nameof(_variable));


            IsActivated = true;
            _variable.OnChanged += RenderVariable;

            RenderVariable();
        }

        public void Deactivate()
        {
            if (IsActivated == false)
                return;

            IsActivated = false;
            _variable.OnChanged -= RenderVariable;
        }

        public void SetVariable(IVariable<int> variable) =>
            _variable = variable ?? throw new ArgumentNullException(nameof(variable));

        private void RenderVariable() =>
            Render(_variable.CurrentValue.ToString());
    }
}
