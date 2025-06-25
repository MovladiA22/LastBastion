using Common.Interfaces;
using Common.UI.Input;
using UnityEngine;

namespace LastBastion.Game
{
    internal class SettingsMenu : ActiveSwitcherUsingButton, IActivable
    {
        [SerializeField] private SettingsMenuView _view;

        public bool IsActivated { get; private set; } = false;

        public void Activate()
        {
            if (IsActivated)
                return;

            IsActivated = true;

            _view.Activate();
        }

        public void Deactivate()
        {
            if (IsActivated == false)
                return;

            IsActivated = false;

            _view.Deactivate();
        }
    }
}
