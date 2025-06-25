using UnityEngine;

namespace LastBastion.Bases
{
    public class PlayerBaseUpgradeButton : PlayerUpgradeButton
    {
        [SerializeField] private PlayerBase _playerBase;

        public override void Init()
        {
            SetUpgradable(_playerBase);
        }
    }
}
