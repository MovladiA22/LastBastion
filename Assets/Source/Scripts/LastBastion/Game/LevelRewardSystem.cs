using System;
using UnityEngine;
using LastBastion.Bases.PlayerBase;

namespace LastBastion.Game
{
    internal class LevelRewardSystem : MonoBehaviour
    {
        [SerializeField] private LevelLauncher _levelLauncher;
        [SerializeField] private PlayerBase _playerBase;
        [SerializeField] private PlayerBaseUpgrader _baseUpgrader;
        [SerializeField] int[] _levelRewardUpgradePoints;
        [SerializeField] int[] _levelRewardMoney;

        private void OnEnable()
        {
            _levelLauncher.OnLevelPassed += OnHandleLevelPassing;
        }

        private void OnDisable()
        {
            _levelLauncher.OnLevelPassed -= OnHandleLevelPassing;
        }

        private void OnHandleLevelPassing()
        {
            int levelIndexlOffset = 1;

            if (_levelLauncher.NumberOfLevels - levelIndexlOffset != _levelRewardMoney.Length)
                throw new ArgumentOutOfRangeException(nameof(_levelRewardMoney));
            else if (_levelLauncher.NumberOfLevels - levelIndexlOffset != _levelRewardUpgradePoints.Length)
                throw new ArgumentOutOfRangeException(nameof(_levelRewardUpgradePoints));

            levelIndexlOffset = 2;

            _baseUpgrader.IncreaseUpgradePoints(_levelRewardUpgradePoints[_levelLauncher.CurrentLevel - levelIndexlOffset]);
            _playerBase.SetMoneyValue(_levelRewardMoney[_levelLauncher.CurrentLevel - levelIndexlOffset]);
        }
    }
}
