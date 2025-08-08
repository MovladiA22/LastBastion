using Common.VariableSystem.Interfaces;
using Common.UI.View;
using UnityEngine;

namespace LastBastion.DefensiveSystem.View
{
    public class DefensiveSystemView : AccessCostableLockableButtonsToggle
    {
        [SerializeField] private DefensiveWeaponsSystem _defensiveSystem;

        protected override IVariable<int> Level => _defensiveSystem.Level;
        protected override IVariable<int> Money => _defensiveSystem.Payable.Money;

        protected override void OnHandleClick(int index)
        {
            if (IsActivated == false)
                return;

            _defensiveSystem.TryTurnOn(index);
        }
    }
}
