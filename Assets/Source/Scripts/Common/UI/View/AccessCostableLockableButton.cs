using Common.Interfaces;
using System;

namespace Common.UI.View
{
    public abstract class AccessCostableLockableButton : LockableButton, IAccessLevel, ICostable
    {
        public event Action<AccessCostableLockableButton> OnLocked;
        public event Action<AccessCostableLockableButton> OnUnlocked;

        public abstract int AccessLevel { get; }
        public abstract int Price { get; }

        protected virtual void InvokeLockEvent() =>
            OnLocked?.Invoke(this);

        protected virtual void InvokeUnlockEvent() =>
            OnUnlocked?.Invoke(this);
    }
}
