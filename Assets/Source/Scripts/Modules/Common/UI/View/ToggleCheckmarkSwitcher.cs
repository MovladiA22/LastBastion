using UnityEngine;
using UnityEngine.UI;

namespace Common.UI.View
{
    public class ToggleCheckmarkSwitcher : MonoBehaviour
    {
        [SerializeField] private Toggle _toggle;
        [SerializeField] private Image _checkmarkImage;
        [SerializeField] private Sprite _enableSprite;
        [SerializeField] private Sprite _disableSprite;

        private void Start()
        {
            OnSwitchSprite(_toggle.isOn);
        }

        private void OnEnable()
        {
            _toggle.onValueChanged.AddListener(OnSwitchSprite);
        }

        private void OnDisable()
        {
            _toggle.onValueChanged.RemoveListener(OnSwitchSprite);
        }

        private void OnSwitchSprite(bool isEnabled)
        {
            if (isEnabled)
                _checkmarkImage.sprite = _enableSprite;
            else
                _checkmarkImage.sprite = _disableSprite;
        }
    }
}
