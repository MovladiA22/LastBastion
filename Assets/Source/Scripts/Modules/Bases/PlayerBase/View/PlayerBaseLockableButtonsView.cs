using UnityEngine;
using Common.UI.View;
using Common.Interfaces;
using Common.VariableSystem;
using System.Collections.Generic;

namespace LastBastion.Bases
{
    public abstract class PlayerBaseLockableButtonsView : ManagedBehavior
    {
        [SerializeField] private List<AccessCostableLockableButton> _buttons;

        protected abstract IVariableInt Level { get; }
        protected abstract IVariableInt Money { get; }

        public override void Activate()
        {
            base.Activate();

            foreach (var button in _buttons)
            {
                button.OnClicked += OnHandleClick;
                button.OnLocked += LockButton;
                button.OnUnlocked += TryUnlockButton;
            }

            Level.OnChanged += TryToggleLockable;
            Money.OnChanged += TryToggleLockable;

            TryToggleLockable();
        }

        public override void Deactivate()
        {
            base.Deactivate();

            foreach (var button in _buttons)
            {
                button.OnClicked -= OnHandleClick;
                button.OnLocked -= LockButton;
                button.OnUnlocked -= TryUnlockButton;
            }

            Level.OnChanged -= TryToggleLockable;
            Money.OnChanged -= TryToggleLockable;
        }

        protected abstract void OnHandleClick(int index);

        private void TryToggleLockable()
        {
            foreach (var button in _buttons)
            {
                LockButton(button);
                TryUnlockButton(button);
            }
        }

        protected virtual void TryUnlockButton(AccessCostableLockableButton button)
        {
            if (Level.CurrentValue >= button.AccessLevel && Money.CurrentValue >= button.Price)
                button.UnlockButton();
        }

        private void LockButton(AccessCostableLockableButton button) =>
            button.LockButton();
    }
}
