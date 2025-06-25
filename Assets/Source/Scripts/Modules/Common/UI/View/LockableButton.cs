using Common.UI.Input;
using UnityEngine.UI;
using UnityEngine;

namespace Common.UI.View
{
    public abstract class LockableButton : ButtonClickHandler<int>
    {
        [SerializeField] private Sprite _lockedStatusSprite;
        [SerializeField] private Sprite _unlockedStatusSprite;

        [field: SerializeField] protected Image ButtonImage {  get; private set; }
        [field: SerializeField] protected bool IsLocked { get; private set; } = false;

        public virtual void LockButton()
        {
            if (IsLocked)
                return;

            SetLockedSprite();
            IsLocked = true;
        }

        public virtual void UnlockButton()
        {
            if (IsLocked == false)
                return;

            SetUnlockedSprite();
            IsLocked = false;
        }

        protected override void HandleClick()
        {
            if (IsLocked == false)
                base.HandleClick();
        }

        protected virtual void SetUnlockedSprite() =>
            ButtonImage.sprite = _unlockedStatusSprite;

        protected virtual void SetLockedSprite() =>
            ButtonImage.sprite = _lockedStatusSprite;
    }
}
