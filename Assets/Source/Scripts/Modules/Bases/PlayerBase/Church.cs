using System;
using UnityEngine;
using Common.Interfaces;
using Common.VariableSystem;
using LastBastion.UpgradeSystem;
using LastBastion.BlessingSystem;
using System.Collections.Generic;

namespace LastBastion.Bases
{
    public class Church : ManagedBehavior, IUpgradable
    {
        private const float OneSecond = 1f;

        [SerializeField] private int _maxNumberOfFaithPoints;
        [SerializeField] private List<Blessing> _blessings;
        [SerializeField] private Upgrader _blessingAccessUpgrader;

        private ChurchFaithPoints _faithPoints;
        private float _timer = 0f;

        public Level Level => _blessingAccessUpgrader.Level;
        public IVariableInt FaithPoints => _faithPoints;
        public IUpgrader Upgrader => _blessingAccessUpgrader;

        public override void Init()
        {
            _faithPoints = new ChurchFaithPoints(_maxNumberOfFaithPoints);
            _blessingAccessUpgrader.SetUpgradable(this);

            for (int i = 0; i < _blessings.Count; i++)
            {
                _blessings[i].SetIndex(i);
                _blessings[i].Init();
            }
        }

        public void TryUseBlessing(int blessingIndex)
        {
            if (IsActivated == false)
                return;

            if (blessingIndex < 0 || blessingIndex >= _blessings.Count)
                throw new ArgumentOutOfRangeException(nameof(blessingIndex));
            else if (_blessings[blessingIndex].Price > _faithPoints.CurrentValue)
                return;

            _blessings[blessingIndex].Activate();
        }

        public void Upgrade() { }

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
