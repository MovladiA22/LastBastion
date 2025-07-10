using System;
using UnityEngine;
using Common.Interfaces;
using LastBastion.UpgradeSystem;
using Common.UnityUtilities.Behaviors;
using Common.VariableSystem.Interfaces;
using LastBastion.UpgradeSystem.Interfaces;

namespace LastBastion.BlessingSystem
{
    public class BlessingActivator : ManagedBehavior, IUpgradable
    {
        private const float OneSecond = 1f;

        [SerializeField] private Blessing[] _blessings;
        [SerializeField] private int _maxNumberOfFaithPoints;
        [SerializeField] private Upgrader _blessingAccessUpgrader;

        private FaithPoints _faithPoints;
        private float _timer = 0f;

        public UpgradeLevel Level => _blessingAccessUpgrader.Level;
        public IVariableInt FaithPoints => _faithPoints;
        public IUpgrader Upgrader => _blessingAccessUpgrader;

        public override void Init()
        {
            _faithPoints = new FaithPoints(_maxNumberOfFaithPoints);
            _blessingAccessUpgrader.SetUpgradable(this);

            for (int i = 0; i < _blessings.Length; i++)
                _blessings[i].SetIndex(i);
        }

        public override void Activate()
        {
            base.Activate();

            _faithPoints.ReplenishFullValue();

            foreach (var blessing in _blessings)
                blessing.OnActivatedForPay += OnHandleBlessingUse;
        }

        public override void Deactivate()
        {
            base.Deactivate();

            foreach (var blessing in _blessings)
                blessing.OnActivatedForPay -= OnHandleBlessingUse;
        }

        public void TryUseBlessing(int blessingIndex)
        {
            if (IsActivated == false)
                return;
            else if (blessingIndex < 0 || blessingIndex >= _blessings.Length)
                throw new ArgumentOutOfRangeException(nameof(blessingIndex));

            if (_blessings[blessingIndex].Price <= _faithPoints.CurrentValue)
                _blessings[blessingIndex].Activate();
        }

        public void Upgrade() { }

        public void ReplenishFaithPoints()
        {
            if (IsActivated == false || _faithPoints.CurrentValue == _faithPoints.MaxValue)
                return;

            _timer += Time.deltaTime;

            if (_timer >= OneSecond)
            {
                _timer = 0f;
                _faithPoints.Increase((int)OneSecond);
            }
        }

        private void OnHandleBlessingUse(ICostable costable) =>
            _faithPoints.Decrease(costable.Price);
    }
}
