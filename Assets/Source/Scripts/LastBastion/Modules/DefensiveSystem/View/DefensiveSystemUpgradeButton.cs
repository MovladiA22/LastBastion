using LastBastion.UpgradeSystem.Input;
using UnityEngine;

namespace LastBastion.DefensiveSystem.View
{
    internal class DefensiveSystemUpgradeButton : UpgradeButton
    {
        [SerializeField] private DefensiveWeaponsSystem _defensiveSystem;

        public override void Init()
        {
            SetUpgradable(_defensiveSystem);
        }
    }
}
