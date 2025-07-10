using LastBastion.UpgradeSystem.Input;
using UnityEngine;

namespace LastBastion.BlessingSystem.Input
{
    internal class BlessingActivatorUpgradeButton : UpgradeButton
    {
        [SerializeField] private BlessingActivator _blessingActivator;

        public override void Init()
        {
            SetUpgradable(_blessingActivator);
        }
    }
}
