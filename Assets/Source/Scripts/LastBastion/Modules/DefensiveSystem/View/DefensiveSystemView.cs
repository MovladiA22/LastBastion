using Common.VariableSystem.Interfaces;
using Common.UI.View;
using UnityEngine;

namespace LastBastion.DefensiveSystem.View
{
    public class DefensiveSystemView : AccessCostableLockableButtonsToggle
    {
        [SerializeField] private DefensiveWeaponsSystem _defensiveSystem;

        protected override IVariableInt Level => _defensiveSystem.Level;
        protected override IVariableInt Money => _defensiveSystem.Payable.Money;

        protected override void OnHandleClick(int index)
        {
            if (IsActivated == false)
                return;

            _defensiveSystem.TryTurnOn(index);
        }
    }
}
