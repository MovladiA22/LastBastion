using LastBastion.BlessingSystem.Blessings;
using LastBastion.Units.EnemyUnits;
using LastBastion.Units.Input;
using UnityEngine;

namespace LastBastion.Units
{
    internal class EnemyUnitPunishBlessing : DivinePunishment
    {
        [SerializeField] private EnemyUnitClickTracker _clickTracker;
        [SerializeField] private ParticleSystem _additionalParticleSystem;

        private void OnEnable()
        {
            _clickTracker.OnClicked += OnPunishUnit;
        }

        private void OnDisable()
        {
            _clickTracker.OnClicked -= OnPunishUnit;
        }

        public override void Activate()
        {
            if (_clickTracker.IsActivated)
                _clickTracker.Deactivate();
            else
                _clickTracker.Activate();
        }

        private void OnPunishUnit(EnemyUnit unit)
        {
            SetBlessable(unit);

            Vector2 newPos = new(unit.transform.position.x, ParticleSystem.transform.position.y); 
            ParticleSystem.transform.position = newPos;
            _additionalParticleSystem.transform.position = unit.transform.position;

            base.Activate();
            _additionalParticleSystem.Play();

            _clickTracker.Deactivate();
        }
    }
}
