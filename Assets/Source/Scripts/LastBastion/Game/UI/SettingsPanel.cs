using Common.UnityUtilities.Behaviors;
using LastBastion.Game.Menu;
using Common.UI.Input;
using UnityEngine;

namespace LastBastion.Game
{
    internal class SettingsPanel : ActiveSwitcherUsingButton, IActivable
    {
        [SerializeField] private SettingsMenu _settingsMenu;

        public bool IsActivated { get; private set; } = false;

        protected override void Awake()
        {
            base.Awake();

            _settingsMenu.Init();
        }

        public void Activate()
        {
            if (IsActivated)
                return;

            IsActivated = true;

            _settingsMenu.Activate();
        }

        public void Deactivate()
        {
            if (IsActivated == false)
                return;

            IsActivated = false;

            _settingsMenu.Deactivate();
        }
    }
}
