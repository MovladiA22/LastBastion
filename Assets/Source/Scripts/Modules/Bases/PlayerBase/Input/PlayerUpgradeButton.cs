using LastBastion.UpgradeSystem;
using Common.Interfaces;
using UnityEngine;
using System;

namespace LastBastion.Bases
{
    public abstract class PlayerUpgradeButton : MonoBehaviour, IInitializable, IActivable
    {
        [SerializeField] private UpgradedButtonClickHandler _upgradedButton;
        [SerializeField] private DowngradedButtonClickHandler _downgradedButton;
        [SerializeField] private UpgradedLevelRenderer _upgradeLevelRenderer;

        public bool IsActivated {  get; private set; } = false;

        public event Action<IUpgradable> OnUpgradeClicked;
        public event Action<IUpgradable> OnDowngradeClicked;

        public abstract void Init();

        public void Activate()
        {
            if (IsActivated)
                return;

            IsActivated = true;

            _upgradedButton.OnClicked += OnInvokeUpgradeEvent;
            _downgradedButton.OnClicked += OnInvokeDowngradeEvent;

            _upgradeLevelRenderer.Activate();
        }

        public void Deactivate()
        {
            if (IsActivated == false)
                return;

            IsActivated = false;

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
