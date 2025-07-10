using LastBastion.UpgradeSystem.Interfaces;
using Common.UI.Input;
using System;

namespace LastBastion.UpgradeSystem.Input
{
    internal abstract class UpgradableButtonClickHandler : ButtonClickHandler<IUpgradable>
    {
        private IUpgradable _upgradable;

        public void SetUpgradable(IUpgradable upgradable) =>
            _upgradable = upgradable ?? throw new ArgumentNullException(nameof(upgradable));

        protected override void InvokeClickEvent(IUpgradable eventData)
        {
            if (_upgradable == null)
                throw new ArgumentNullException(nameof(_upgradable));

            eventData = _upgradable;

            base.InvokeClickEvent(eventData);
        }
    }
}
