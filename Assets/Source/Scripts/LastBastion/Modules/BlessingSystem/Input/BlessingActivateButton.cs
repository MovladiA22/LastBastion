using Common.UI.View;
using UnityEngine.UI;
using UnityEngine;

namespace LastBastion.BlessingSystem.Input
{
    public class BlessingActivateButton : AccessCostableLockableButton
    {
        private readonly float _transparency = 0.5f;

        [SerializeField] private Blessing _blessing;
        [SerializeField] private Text _priceTextField;

        private Color _defaultColor;

        public override int AccessLevel => _blessing.AccessLevel;
        public override int Price => _blessing.Price;

        private void Awake()
        {
            _priceTextField.text = Price.ToString();
            _defaultColor = ButtonImage.color;
        }

        protected override void OnEnable()
        {
            base.OnEnable();

            _blessing.OnDeactivated += InvokeUnlockEvent;
        }

        protected override void OnDisable()
        {
            base.OnDisable();

            _blessing.OnDeactivated -= InvokeUnlockEvent;
        }

        public override void UnlockButton()
        {
            if (_blessing.IsActivated == false)
                base.UnlockButton();
        }

        protected override void InvokeClickEvent(int eventData)
        {
            eventData = _blessing.Index;

            base.InvokeClickEvent(eventData);
        }

        protected override void SetLockedSprite()
        {
            Color newColor = ButtonImage.color;
            
            newColor.r *= _transparency;
            newColor.g *= _transparency;
            newColor.b *= _transparency;

            ButtonImage.color = newColor;
        }

        protected override void SetUnlockedSprite() =>
            ButtonImage.color = _defaultColor;
    }
}
