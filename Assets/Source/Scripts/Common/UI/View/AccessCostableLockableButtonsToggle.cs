using UnityEngine;
using System.Collections.Generic;
using Common.UnityUtilities.Behaviors;
using Common.VariableSystem.Interfaces;

namespace Common.UI.View
{
    public abstract class AccessCostableLockableButtonsToggle : MonoBehaviour, IActivable
    {
        [SerializeField] private List<AccessCostableLockableButton> _buttons;

        public bool IsActivated { get; private set; }
        protected abstract IVariableInt Level { get; }
        protected abstract IVariableInt Money { get; }

        public virtual void Activate()
        {
            if (IsActivated)
                return;

            IsActivated = true;

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

        public virtual void Deactivate()
        {
            if (IsActivated == false)
                return;

            IsActivated = false;

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

        protected virtual void TryUnlockButton(AccessCostableLockableButton button)
        {
            if (Level.CurrentValue >= button.AccessLevel && Money.CurrentValue >= button.Price)
                button.UnlockButton();
        }

        private void TryToggleLockable()
        {
            foreach (var button in _buttons)
            {
                LockButton(button);
                TryUnlockButton(button);
            }
        }

        private void LockButton(AccessCostableLockableButton button) =>
            button.LockButton();
    }
}
