using Common.UI.View;
using Common.VariableSystem;
using UnityEngine;

namespace LastBastion.Bases
{
    public class PlayerGarrisonView : PlayerBaseLockableButtonsView
    {
        [SerializeField] private PlayerGarrison _playerGarrison;

        protected override IVariableInt Level => _playerGarrison.Level;
        protected override IVariableInt Money => _playerGarrison.Payable.Money;

        public override void Init() { }

        protected override void OnHandleClick(int index)
        {
            if (IsActivated == false)
            { return; }

            _playerGarrison.SpawnUnit(index);
        }

        protected override void TryUnlockButton(AccessCostableLockableButton button)
        {
            if (_playerGarrison.SpawnCooldownIsUp)
                base.TryUnlockButton(button);
        }
    }
}
