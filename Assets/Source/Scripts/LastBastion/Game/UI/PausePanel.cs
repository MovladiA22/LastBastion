using LastBastion.Game.Menu;
using Common.UI.Input;
using UnityEngine;
using System;

namespace LastBastion.Game.UI
{
    internal class PausePanel : ActiveSwitcherUsingButton
    {
        [SerializeField] private PauseMenu _pauseMenu;
        [SerializeField] private SettingsPanel _settingsMenu;
        [SerializeField] private ButtonClickHandler _cancelPauseButton;
        [SerializeField] private ButtonClickHandler _restartButton;
        [SerializeField] private ButtonClickHandler _returnHomeButton;

        public event Action OnClickedRestart;
        public event Action OnClickedReturn;

        protected override void Awake()
        {
            base.Awake();

            _pauseMenu.Init();
        }

        protected override void OnEnable()
        {
            base.OnEnable();

            OnSwitched += PauseGame;
            _cancelPauseButton.OnClicked += ClickOnButton;
            _restartButton.OnClicked += OnHandleRestartClick;
            _returnHomeButton.OnClicked += OnHandleReturnClick;
        }

        protected override void OnDisable()
        {
            base.OnDisable();

            OnSwitched -= PauseGame;
            _cancelPauseButton.OnClicked -= ClickOnButton;
            _restartButton.OnClicked -= OnHandleRestartClick;
            _returnHomeButton.OnClicked -= OnHandleReturnClick;
        }

        private void PauseGame(bool isActive)
        {
            if (isActive)
            {
                Time.timeScale = 1f;
                _settingsMenu.Deactivate();
                _pauseMenu.Deactivate();
            }
            else
            {
                Time.timeScale = 0f;
                _pauseMenu.Activate();
                _settingsMenu.Activate();
            }
        }

        private void OnHandleRestartClick()
        {
            OnClickedRestart?.Invoke();
            ClickOnButton();
        }

        private void OnHandleReturnClick()
        {
            ClickOnButton();
            OnClickedReturn?.Invoke();
        }
    }
}
