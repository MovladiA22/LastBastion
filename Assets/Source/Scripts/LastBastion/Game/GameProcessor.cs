using LastBastion.Game.Menu;
using Common.UI.Input;
using Common.Audio;
using UnityEngine;
using System;

namespace LastBastion.Game
{
    internal class GameProcessor : MonoBehaviour
    {
        [SerializeField] private BattlePreparationMenu _battlePreparationMenu;
        [SerializeField] private LevelLauncher _levelLauncher;
        [SerializeField] private ButtonClickHandler _levelStartButton;
        [SerializeField] private MusicRunner _menuBackground;

        public event Action OnGameOver;

        private void Awake()
        {
            _levelLauncher.Init();
            _battlePreparationMenu.Init();
        }

        private void OnEnable()
        {
            _levelLauncher.OnLevelLost += OnHandleDefeat;
            _levelLauncher.OnLevelPassed += OnHandleVictory;
            _battlePreparationMenu.OnClickedReturn += EndGame;

            _levelStartButton.OnClicked += OnHandleLevelStart;
        }

        private void OnDisable()
        {
            _levelLauncher.OnLevelLost -= OnHandleDefeat;
            _levelLauncher.OnLevelPassed -= OnHandleVictory;
            _battlePreparationMenu.OnClickedReturn -= EndGame;

            _levelStartButton.OnClicked -= OnHandleLevelStart;
        }

        public void StartGame()
        {
            _battlePreparationMenu.Activate();
        }

        public void EndGame()
        {
            _levelLauncher.ResetProgress();
            _battlePreparationMenu.ResetProgress();
            _battlePreparationMenu.Deactivate();

            OnGameOver?.Invoke();
        }

        private void OnHandleLevelStart()
        {
            _battlePreparationMenu.Deactivate();
            _menuBackground.StopAudio();

            _levelLauncher.LaunchLevel();
        }

        private void OnHandleDefeat()
        {
            Debug.Log("Lose");
            _levelLauncher.EndUpLevel();

            _menuBackground.RunAudio();
            _battlePreparationMenu.Activate();
        }

        private void OnHandleVictory()
        {
            if (_levelLauncher.CurrentLevel == _levelLauncher.NumberOfLevels)
            {
                Debug.Log("Win");
            }

            _levelLauncher.EndUpLevel();
            _menuBackground.RunAudio();

            _levelLauncher.SetNextLevel();
            _battlePreparationMenu.Activate();
        }
    }
}
