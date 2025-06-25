using UnityEngine;

namespace LastBastion.Bases
{
    internal class DefensiveSystemUpgradeButton : PlayerUpgradeButton
    {
        [SerializeField] private DefensiveSystem _defensiveSystem;

        public override void Init()
        {
            SetUpgradable(_defensiveSystem);
        }
    }
}
