using Common.UnityUtilities.Behaviors;
using LastBastion.Bases.PlayerBase;
using LastBastion.Bases.EnemyBase;
using System.Collections.Generic;
using LastBastion.Game.Menu;
using LastBastion.Game.UI;
using UnityEngine;
using System;

namespace LastBastion.Game
{
    internal class LevelLauncher : MonoBehaviour, IInitializable
    {
        public const int FirstLevel = 1;
        private const int LevelIndexlOffset = 1;

        [SerializeField] private PlayerBase _playerBase;
        [SerializeField] private List<EnemyBase> _enemyBases;
        [SerializeField] private LevelMenu _battleMenuView;
        [SerializeField] private PausePanel _pauseMenu;

        public event Action OnLevelChanged;
        public event Action OnLevelPassed;
        public event Action OnLevelLost;

        public bool IsLevelActivate { get; private set; } = false;
        public int CurrentLevel { get; private set; }
        public int NumberOfLevels => _enemyBases.Count;

        private void OnEnable()
        {
            _playerBase.OnDestroid += OnInvokeLevelLostEvent;
            _pauseMenu.OnClickedRestart += RestartLevel;
            _pauseMenu.OnClickedReturn += OnInvokeLevelLostEvent;
        }

        private void OnDisable()
        {
            _playerBase.OnDestroid -= OnInvokeLevelLostEvent;
            _pauseMenu.OnClickedRestart -= RestartLevel;
            _pauseMenu.OnClickedReturn -= OnInvokeLevelLostEvent;

            foreach (var enemyBase in _enemyBases)
                enemyBase.OnDestroid -= OnInvokeLevelPassedEvent;
        }

        public void Init()
        {
            CurrentLevel = FirstLevel;
            _playerBase.Init();

            foreach (var enemyBase in _enemyBases)
            {
                enemyBase.Init();
                enemyBase.OnDestroid += OnInvokeLevelPassedEvent;
                enemyBase.gameObject.SetActive(false);
            }

            _battleMenuView.Init();
        }

        public void SetNextLevel()
        {
            if (IsLevelActivate == false && CurrentLevel < NumberOfLevels)
            {
                CurrentLevel++;
                OnLevelChanged?.Invoke();
            }
        }

        public void LaunchLevel()
        {
            if (IsLevelActivate)
                return;
            else if (CurrentLevel > NumberOfLevels)
                return;

            _playerBase.Activate();
            _enemyBases[CurrentLevel - LevelIndexlOffset].Activate();

            _battleMenuView.SetHealthBar(_playerBase.IHealth, _enemyBases[CurrentLevel - LevelIndexlOffset].IHealth);
            _battleMenuView.Activate();

            IsLevelActivate = true;
        }

        public void EndUpLevel()
        {
            if (IsLevelActivate)
            {
                _playerBase.Deactivate();
                _enemyBases[CurrentLevel - LevelIndexlOffset].Deactivate();

                _battleMenuView.Deactivate();
                IsLevelActivate = false;
            }
        }

        public void ResetProgress()
        {
            CurrentLevel = FirstLevel;
            _playerBase.ResetProgress();
        }

        private void RestartLevel()
        {
            EndUpLevel();
            LaunchLevel();
        }

        public void OnInvokeLevelPassedEvent() =>
            OnLevelPassed?.Invoke();

        public void OnInvokeLevelLostEvent() =>
            OnLevelLost?.Invoke();
    }
}
