using Common.UI.Input;
using System;

namespace LastBastion.UpgradeSystem
{
    public abstract class UpgradableButtonClickHandler : ButtonClickHandler<IUpgradable>
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
