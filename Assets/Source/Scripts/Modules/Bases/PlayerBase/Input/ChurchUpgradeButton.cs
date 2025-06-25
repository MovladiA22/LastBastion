using UnityEngine;

namespace LastBastion.Bases
{
    internal class ChurchUpgradeButton : PlayerUpgradeButton
    {
        [SerializeField] private Church _church;

        public override void Init()
        {
            SetUpgradable(_church);
        }
    }
}
