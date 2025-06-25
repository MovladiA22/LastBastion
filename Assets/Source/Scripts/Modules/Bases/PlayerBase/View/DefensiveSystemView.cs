using Common.VariableSystem;
using UnityEngine;

namespace LastBastion.Bases
{
    public class DefensiveSystemView : PlayerBaseLockableButtonsView
    {
        [SerializeField] private DefensiveSystem _defensiveSystem;

        protected override IVariableInt Level => _defensiveSystem.Level;
        protected override IVariableInt Money => _defensiveSystem.Payable.Money;

        public override void Init() { }

        protected override void OnHandleClick(int index)
        {
            if (IsActivated == false)
                return;

            _defensiveSystem.TryTurnOn(index);
        }
    }
}
