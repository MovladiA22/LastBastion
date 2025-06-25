using Common.VariableSystem;
using Common.Interfaces;
using System;

namespace Common.UI.View
{
    public class VariableIntTextRenderer : TextRenderer, IActivable
    {
        private IVariableInt _variable;

        public bool IsActivated { get; private set; }

        private void OnDisable()
        {
            if (_variable != null)
                _variable.OnChanged -= RenderVariable;
        }

        public void SetVariable(IVariableInt variable) =>
            _variable = variable ?? throw new ArgumentNullException(nameof(variable));

        private void RenderVariable()
        {
            Render(_variable.CurrentValue.ToString());
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

            if (_variable == null)
                throw new ArgumentNullException(nameof(_variable));

            IsActivated = false;
            _variable.OnChanged -= RenderVariable;
        }
    }
}
