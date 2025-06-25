using Common.VariableSystem;
using Common.UI.View;
using UnityEngine;

namespace LastBastion.Bases
{
    public class ChurchView : PlayerBaseLockableButtonsView
    {
        [SerializeField] private Church _church;
        [SerializeField] private VariableIntTextRenderer _faithPointsRenderer;

        protected override IVariableInt Level => _church.Level;

        protected override IVariableInt Money =>_church.FaithPoints;

        public override void Init()
        {
            _faithPointsRenderer.SetVariable(_church.FaithPoints);
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
            _church.TryUseBlessing(index);
    }
}
