using LastBastion.UpgradeSystem.Interfaces;
using LastBastion.UpgradeSystem.Input;
using Common.UnityUtilities.Behaviors;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;

namespace LastBastion.UpgradeSystem.View
{
    public class UpgradeButtonsView : ManagedBehavior
    {
        private readonly Stack<IUpgrader> _upgraders = new();

        [SerializeField] private Text _upgradePointsTextField;
        [SerializeField] private List<UpgradeButton> _upgradedButtons;
        [SerializeField, Min(0)] private int _defaultNumberOfUpgradePoints;

        private int _currentNumberOfUpgradePoints;

        public override void Init()
        {
            if (_upgraders == null || _upgraders.Count == 0)
                throw new ArgumentNullException(nameof(_upgraders));

            _currentNumberOfUpgradePoints = _defaultNumberOfUpgradePoints;

            foreach (var button in _upgradedButtons)
                button.Init();
        }

        public override void Activate()
        {
            base.Activate();

            foreach (var button in _upgradedButtons)
            {
                button.Activate();
                button.OnUpgradeClicked += OnUpgrade;
                button.OnDowngradeClicked += OnDowngrade;
            }

            RenderNumberOfUpgradePoints();
        }

        public override void Deactivate()
        {
            base.Deactivate();

            foreach (var button in _upgradedButtons)
            {
                button.Deactivate();
                button.OnUpgradeClicked -= OnUpgrade;
                button.OnDowngradeClicked -= OnDowngrade;
            }
        }

        public void AddUpgrader(IUpgrader upgrader)
        {
            if (upgrader == null)
                throw new ArgumentNullException(nameof(upgrader));

            _upgraders.Push(upgrader);
        }

        public void ResetProgress()
        {
            foreach (var upgrader in _upgraders)
            {
                while (upgrader.TryDowngrade()) { }
            }

            _currentNumberOfUpgradePoints = _defaultNumberOfUpgradePoints;
            RenderNumberOfUpgradePoints();
        }

        public void IncreaseUpgradePoints(int value)
        {
            if (value <= 0)
                throw new ArgumentOutOfRangeException(nameof(value));

            _currentNumberOfUpgradePoints += value;
            RenderNumberOfUpgradePoints();
        }

        private void RenderNumberOfUpgradePoints() =>
            _upgradePointsTextField.text = _currentNumberOfUpgradePoints.ToString();

        private void OnUpgrade(IUpgradable upgradable)
        {
            if (IsActivated == false || _currentNumberOfUpgradePoints == 0)
                return;

            foreach (var upgrader in _upgraders)
            {
                if (upgradable == upgrader.Upgradable)
                {
                    if (upgrader.TryUpgrade())
                    {
                        _currentNumberOfUpgradePoints--;
                        RenderNumberOfUpgradePoints();
                    }
                }
            }
        }

        private void OnDowngrade(IUpgradable upgradable)
        {
            if (IsActivated == false)
                return;

            foreach (var upgrader in _upgraders)
            {
                if (upgradable == upgrader.Upgradable)
                {
                    if (upgrader.TryDowngrade())
                    {
                        _currentNumberOfUpgradePoints++;
                        RenderNumberOfUpgradePoints();
                    }
                }
            }
        }
    }
}
