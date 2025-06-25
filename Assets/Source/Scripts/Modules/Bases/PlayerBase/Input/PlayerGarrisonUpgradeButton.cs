using UnityEngine;

namespace LastBastion.Bases
{
    internal class PlayerGarrisonUpgradeButton : PlayerUpgradeButton
    {
        [SerializeField] private PlayerGarrison _playerGarrison;

        public override void Init()
        {
            SetUpgradable(_playerGarrison);
        }
    }
}
