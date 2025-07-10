using LastBastion.UpgradeSystem.Input;
using UnityEngine;

namespace LastBastion.Bases.PlayerBase.Input
{
    internal class PlayerBaseUpgradeButton : UpgradeButton
    {
        [SerializeField] private PlayerBase _playerBase;

        public override void Init()
        {
            SetUpgradable(_playerBase);
        }
    }
}
