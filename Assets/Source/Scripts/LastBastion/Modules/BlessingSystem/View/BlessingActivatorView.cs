using Common.VariableSystem.Interfaces;
using Common.UnityUtilities.Behaviors;
using Common.UI.Output;
using Common.UI.View;
using UnityEngine;

namespace LastBastion.BlessingSystem.View
{
    public class BlessingActivatorView : AccessCostableLockableButtonsToggle, IInitializable
    {
        [SerializeField] private BlessingActivator _blessingActivator;
        [SerializeField] private VariableIntTextRenderer _faithPointsRenderer;

        protected override IVariable<int> Level => _blessingActivator.Level;

        protected override IVariable<int> Money =>_blessingActivator.FaithPoints;

        public void Init()
        {
            _faithPointsRenderer.SetVariable(_blessingActivator.FaithPoints);
        }

        public override void Activate()
        {
            base.Activate();

            _faithPointsRenderer.Activate();
        }

        public override void Deactivate()
        {
            base.Deactivate();

            _faithPointsRenderer.Deactivate();
        }

        protected override void OnHandleClick(int index) =>
            _blessingActivator.TryUseBlessing(index);
    }
}
