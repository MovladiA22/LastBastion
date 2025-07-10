using System;
using Common.UI;
using UnityEngine;
using Common.UI.Input;
using LastBastion.Game.View;
using LastBastion.Bases.PlayerBase;

namespace LastBastion.Game.Menu
{
    internal class BattlePreparationMenu : UIMenu
    {
        [SerializeField] private PlayerBaseUpgrader _baseUpgrader;
        [SerializeField] private LevelInfoRenderer _levelInfoRenderer;
        [SerializeField] private ButtonClickHandler _mainMenuReturnButton;
        [SerializeField] private SettingsPanel _settingsMenu;

        public event Action OnClickedReturn;

        public override void Init()
        {
            _baseUpgrader.Init();
            _levelInfoRenderer.Init();

            base.Init();
        }

        public override void Activate()
        {
            base.Activate();

            _baseUpgrader.Activate();
            _levelInfoRenderer.Activate();
            _settingsMenu.Activate();

            _mainMenuReturnButton.OnClicked += InvokeClickedReturnEvent;
        }

        public override void Deactivate()
        {
            base.Deactivate();

            _baseUpgrader.Deactivate();
            _levelInfoRenderer.Deactivate();
            _settingsMenu.Deactivate();

            _mainMenuReturnButton.OnClicked -= InvokeClickedReturnEvent;
        }

        public void ResetProgress() =>
            _baseUpgrader.ResetProgress();

        private void InvokeClickedReturnEvent() =>
            OnClickedReturn?.Invoke();
    }
}
