using LastBastion.UpgradeSystem.Input;
using UnityEngine;

namespace LastBastion.Bases.PlayerBase.Input
{
    internal class PlayerGarrisonUpgradeButton : UpgradeButton
    {
        [SerializeField] private PlayerGarrison _playerGarrison;

        public override void Init()
        {
            SetUpgradable(_playerGarrison);
        }
    }
}
