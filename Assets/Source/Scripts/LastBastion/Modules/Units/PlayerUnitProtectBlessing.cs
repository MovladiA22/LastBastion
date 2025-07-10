using LastBastion.BlessingSystem.Blessings;
using LastBastion.Units.PlayerUnits;
using LastBastion.Units.Input;
using UnityEngine;

namespace LastBastion.Units
{
    internal class PlayerUnitProtectBlessing : DivineProtection
    {
        [SerializeField] private PlayerUnitClickTracker _clickTracker;

        private void OnEnable()
        {
            _clickTracker.OnClicked += OnProtectUnit;
        }

        private void OnDisable()
        {
            _clickTracker.OnClicked -= OnProtectUnit;
        }

        public override void Activate()
        {
            if (IsActivate)
                return;

            if (_clickTracker.IsActivated)
                _clickTracker.Deactivate();
            else
                _clickTracker.Activate();
        }

        private void OnProtectUnit(PlayerUnit unit)
        {
            SetBlessable(unit);

            ParticleSystem.transform.position = unit.transform.position;
            ParticleSystem.transform.parent = unit.transform;
            ParticleSystem.transform.localScale = Vector2.one;

            base.Activate();

            _clickTracker.Deactivate();
        }
    }
}
