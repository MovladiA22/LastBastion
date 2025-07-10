using UnityEngine;
using Common.UI.Input;

namespace LastBastion.Game
{
    internal class ConfirmationPanel : ActiveSwitcherUsingButton
    {
        [SerializeField] private ButtonClickHandler _cancelButton;
        [SerializeField] private ButtonClickHandler _confirmButton;

        protected override void OnEnable()
        {
            base.OnEnable();

            _cancelButton.OnClicked += ClickOnButton;
            _confirmButton.OnClicked += ClickOnButton;
        }

        protected override void OnDisable()
        {
            base.OnDisable();

            _cancelButton.OnClicked += ClickOnButton;
            _confirmButton.OnClicked += ClickOnButton;
        }
    }
}
