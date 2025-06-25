using Common.UI.View;
using UnityEngine.UI;
using UnityEngine;

namespace LastBastion.DefensiveWeapons
{
    public class DefensiveWeaponButton : AccessCostableLockableButton
    {
        [SerializeField] private DefensiveWeapon _defensiveWeapon;
        [SerializeField] private Text _priceTextField;

        public override int AccessLevel => _defensiveWeapon.AccessLevel;
        public override int Price => _defensiveWeapon.Price;

        private void Awake()
        {
            _priceTextField.text = _defensiveWeapon.Price.ToString();
        }

        protected override void OnEnable()
        {
            base.OnEnable();

            _defensiveWeapon.OnEnabled += InvokeLockEvent;
            _defensiveWeapon.OnDisabled += InvokeUnlockEvent;
        }

        protected override void OnDisable()
        {
            base.OnDisable();

            _defensiveWeapon.OnEnabled -= InvokeLockEvent;
            _defensiveWeapon.OnDisabled -= InvokeUnlockEvent;
        }

        public override void UnlockButton()
        {
            if (_defensiveWeapon.IsActivated)
                return;

            base.UnlockButton();
        }

        protected override void InvokeClickEvent(int eventData)
        {
            eventData = _defensiveWeapon.Index;

            base.InvokeClickEvent(eventData);
        }
    }
}
