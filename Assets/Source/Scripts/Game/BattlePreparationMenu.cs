using System;
using UnityEngine;
using Common.UI.Input;
using LastBastion.Bases;

namespace LastBastion.Game
{
    internal class BattlePreparationMenu : UIMenu
    {
        [SerializeField] private BattlePreparationInfoView _infoView;
        [SerializeField] private PlayerBaseUpgrader _playerBaseUpgrader;
        [SerializeField] private ButtonClickHandler _mainMenuReturnButton;
        [SerializeField] private SettingsMenu _settingsMenu;

        public event Action OnClickedReturn;

        public override void Init()
        {
            _playerBaseUpgrader.Init();
            _infoView.Init();

            base.Init();
        }

        public override void Activate()
        {
            base.Activate();

            _infoView.Activate();
            _playerBaseUpgrader.Activate();
            _settingsMenu.Activate();

            _mainMenuReturnButton.OnClicked += InvokeClickedReturnEvent;
        }

        public override void Deactivate()
        {
            base.Deactivate();

            _infoView.Deactivate();
            _playerBaseUpgrader.Deactivate();
            _settingsMenu.Deactivate();

            _mainMenuReturnButton.OnClicked -= InvokeClickedReturnEvent;
        }

        public void ResetProgress() =>
            _playerBaseUpgrader.ResetProgress();

        private void InvokeClickedReturnEvent() =>
            OnClickedReturn?.Invoke();
    }
}
