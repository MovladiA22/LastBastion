using Common.UI.Input;
using UnityEngine.UI;
using UnityEngine;
using System;

namespace LastBastion.Game
{
    internal class PauseMenu : ActiveSwitcherUsingButton
    {
        [SerializeField] private PauseMenuView _view;
        [SerializeField] private SettingsMenu _settingsMenu;
        [SerializeField] private ButtonClickHandler _cancelPauseButton;
        [SerializeField] private ButtonClickHandler _restartButton;
        [SerializeField] private ButtonClickHandler _returnHomeButton;

        public event Action OnClickedRestart;
        public event Action OnClickedReturn;

        protected override void Awake()
        {
            base.Awake();
            _view.Init();
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
                _view.Deactivate();
            }
            else
            {
                Time.timeScale = 0f;
                _view.Activate();
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
