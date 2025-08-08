using System;
using UnityEngine;
using UnityEngine.UI;

namespace Common.UI.Input
{
    public class ActiveSwitcherUsingButton : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [SerializeField] private GameObject _object;
        [SerializeField] private AudioSource _clickSound;

        public event Action<bool> OnSwitched;

        protected virtual void Awake()
        {
            _object.SetActive(false);
        }

        protected virtual void OnEnable()
        {
            _button.onClick.AddListener(OnSwitchObjectActive);
        }

        protected virtual void OnDisable()
        {
            _button.onClick.RemoveListener(OnSwitchObjectActive);
        }

        public void ClickOnButton()
        {
            _button.onClick?.Invoke();
        }

        private void OnSwitchObjectActive()
        {
            _clickSound.Play();
            _object.SetActive(_object.activeSelf == false);
            OnSwitched?.Invoke(_object.activeSelf == false);
        }
    }
}
