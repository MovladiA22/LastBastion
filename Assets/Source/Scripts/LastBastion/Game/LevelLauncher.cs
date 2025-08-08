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

        private bool _isLevelActivate = false;

        public event Action OnLevelChanged;
        public event Action OnLevelPassed;
        public event Action OnLevelLost;

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
            if (_isLevelActivate == false && CurrentLevel < NumberOfLevels)
            {
                CurrentLevel++;
                OnLevelChanged?.Invoke();
            }
        }

        public void LaunchLevel()
        {
            if (_isLevelActivate)
                return;
            else if (CurrentLevel > NumberOfLevels)
                return;

            _playerBase.Activate();
            _enemyBases[CurrentLevel - LevelIndexlOffset].Activate();

            _battleMenuView.SetHealthBar(_playerBase.IHealth, _enemyBases[CurrentLevel - LevelIndexlOffset].IHealth);
            _battleMenuView.Activate();

            _isLevelActivate = true;
        }

        public void EndUpLevel()
        {
            if (_isLevelActivate)
            {
                _playerBase.Deactivate();
                _enemyBases[CurrentLevel - LevelIndexlOffset].Deactivate();

                _battleMenuView.Deactivate();
                _isLevelActivate = false;
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
