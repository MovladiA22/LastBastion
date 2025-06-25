using System;
using UnityEngine;
using UnityEngine.UI;

namespace Common.UI.Input
{
    public class ButtonClickHandler : BaseButtonClickHandler
    {
        public event Action OnClicked;

        protected override void HandleClick()
        {
            OnClicked?.Invoke();
        }
    }

    public abstract class ButtonClickHandler<T> : BaseButtonClickHandler
    {
        public event Action<T> OnClicked;

        protected virtual void InvokeClickEvent(T eventData) =>
            OnClicked?.Invoke(eventData);

        protected override void HandleClick()
        {
            InvokeClickEvent(default);
        }
    }

    public abstract class BaseButtonClickHandler : MonoBehaviour
    {
        [SerializeField] protected Button _button;
        [SerializeField] protected AudioSource _clickSound;

        protected virtual void OnEnable() =>
            _button.onClick.AddListener(OnHandleClick);

        protected virtual void OnDisable() =>
            _button.onClick.RemoveListener(OnHandleClick);

        private void OnHandleClick()
        {
            _clickSound.Play();
            HandleClick();
        }

        protected abstract void HandleClick();
    }
}
