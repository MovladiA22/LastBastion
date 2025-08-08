using Common.VariableSystem.Interfaces;
using Common.UI.View;
using UnityEngine;

namespace LastBastion.Bases.PlayerBase.View
{
    public class PlayerGarrisonView : AccessCostableLockableButtonsToggle
    {
        [SerializeField] private PlayerGarrison _playerGarrison;

        protected override IVariable<int> Level => _playerGarrison.Level;
        protected override IVariable<int> Money => _playerGarrison.Payable.Money;

        protected override void TryUnlockButton(AccessCostableLockableButton button)
        {
            if (_playerGarrison.SpawnCooldownIsUp)
                base.TryUnlockButton(button);
        }

        protected override void OnHandleClick(int index)
        {
            if (IsActivated == false)
                return;

            _playerGarrison.SpawnUnit(index);
        }
    }
}
