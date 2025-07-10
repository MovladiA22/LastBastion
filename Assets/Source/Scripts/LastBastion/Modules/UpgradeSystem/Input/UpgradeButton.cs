using LastBastion.UpgradeSystem.Interfaces;
using Common.UnityUtilities.Behaviors;
using LastBastion.UpgradeSystem.View;
using UnityEngine;
using System;

namespace LastBastion.UpgradeSystem.Input
{
    public abstract class UpgradeButton : ManagedBehavior
    {
        [SerializeField] private UpgradedButtonClickHandler _upgradedButton;
        [SerializeField] private DowngradedButtonClickHandler _downgradedButton;
        [SerializeField] private UpgradedLevelRenderer _upgradeLevelRenderer;

        public event Action<IUpgradable> OnUpgradeClicked;
        public event Action<IUpgradable> OnDowngradeClicked;

        public override void Activate()
        {
            base.Activate();

            _upgradedButton.OnClicked += OnInvokeUpgradeEvent;
            _downgradedButton.OnClicked += OnInvokeDowngradeEvent;

            _upgradeLevelRenderer.Activate();
        }

        public override void Deactivate()
        {
            base.Deactivate();

            _upgradedButton.OnClicked -= OnInvokeUpgradeEvent;
            _downgradedButton.OnClicked -= OnInvokeDowngradeEvent;

            _upgradeLevelRenderer.Deactivate();
        }

        protected void SetUpgradable(IUpgradable upgradable)
        {
            if (upgradable == null)
                throw new ArgumentNullException(nameof(upgradable));

            _upgradedButton.SetUpgradable(upgradable);
            _downgradedButton.SetUpgradable(upgradable);

            _upgradeLevelRenderer.SetVariable(upgradable.Level);
        }

        private void OnInvokeUpgradeEvent(IUpgradable upgradable) =>
            OnUpgradeClicked?.Invoke(upgradable);

        private void OnInvokeDowngradeEvent(IUpgradable upgradable) =>
            OnDowngradeClicked?.Invoke(upgradable);
    }
}
