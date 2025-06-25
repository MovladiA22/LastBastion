using System.Collections.Generic;
using LastBastion.UpgradeSystem;
using Common.Interfaces;
using UnityEngine.UI;
using UnityEngine;
using System;

namespace LastBastion.Bases
{
    public class PlayerBaseUpgrader : ManagedBehavior
    {
        [SerializeField] private PlayerBase _playerBase;
        [SerializeField] private Text _upgradePointsTextField;
        [SerializeField] private List<PlayerUpgradeButton> _upgradedButtons;
        [SerializeField, Min(0)] private int _defaultNumberOfUpgradePoints;

        private int _currentNumberOfUpgradePoints;

        private void Awake()
        {
            _currentNumberOfUpgradePoints = _defaultNumberOfUpgradePoints;
        }

        public override void Init()
        {
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

        public void ResetProgress()
        {
            foreach (var upgrader in _playerBase.GetUpgraders())
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

        private void OnUpgrade(IUpgradable upgradable)
        {
            if (IsActivated == false || _currentNumberOfUpgradePoints == 0)
                return;

            foreach (var upgrader in _playerBase.GetUpgraders())
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

            foreach (var upgrader in _playerBase.GetUpgraders())
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

        private void RenderNumberOfUpgradePoints() =>
            _upgradePointsTextField.text = _currentNumberOfUpgradePoints.ToString();
    }
}
