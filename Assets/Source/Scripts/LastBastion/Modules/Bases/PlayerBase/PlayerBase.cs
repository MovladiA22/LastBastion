using LastBastion.BlessingSystem.Interfaces;
using LastBastion.UpgradeSystem.Interfaces;
using LastBastion.CombatSystem.Interfaces;
using Common.VariableSystem.Interfaces;
using LastBastion.DefensiveSystem;
using System.Collections.Generic;
using LastBastion.BlessingSystem;
using LastBastion.ResourceSystem;
using LastBastion.UpgradeSystem;
using Common.Interfaces;
using UnityEngine;
using System;

namespace LastBastion.Bases.PlayerBase
{
    public class PlayerBase : Base, IPlayer, IUpgradable, IRestorable, IPayable
    {
        [SerializeField] private DefensiveWeaponsSystem _defensiveSystem;
        [SerializeField] private IntUpgrader _healthUpgrader;
        [SerializeField] private BlessingActivator _church;
        [SerializeField] private BountyCollector _bountyCollector;
        [SerializeField, Min(0)] private int _provisionsValue;
        [SerializeField, Min(0)] private int _amountOfMoney;

        private PlayerGarrison _garrison;
        private Provisions _provisions;
        private Money _money;

        public UpgradeLevel Level => _healthUpgrader.Level;
        public IVariable<float> Provisions => _provisions;
        public IVariable<int> Money => _money;

        public override void Init()
        {
            base.Init();
            _garrison = Garrison as PlayerGarrison ?? throw new ArgumentNullException(nameof(_garrison));

            _money = new Money(_amountOfMoney);
            _provisions = new Provisions(_provisionsValue);

            _healthUpgrader.SetUpgradable(this);
            _garrison.SetProvisions(_provisions);
            _garrison.SetPayable(this);
            _defensiveSystem.SetPayable(this);
            _bountyCollector.SetMoney(_money);

            _defensiveSystem.Init();
            _church.Init();
        }

        public override void Activate()
        {
            base.Activate();
            _provisions.OnOutOfProvisions += Collapse;

            _defensiveSystem.Activate();
            _church.Activate();
        }

        public override void Deactivate()
        {
            base.Deactivate();
            _provisions.OnOutOfProvisions -= Collapse;

            _money.SetValue(_money.MaxValue);
            _provisions.SetValue(_provisions.MaxValue);

            _defensiveSystem.Deactivate();
            _church.Deactivate();
        }

        public void SetMoneyValue(int amount)
        {
            _money.SetMaxValue(amount);
            _money.SetValue(_money.MaxValue);
        }

        public void Upgrade()
        {
            Health.SetMaxValue(_healthUpgrader.GetUpgradedValue());
            Health.SetValue(Health.MaxValue);
        }

        public void Restore(int value) =>
            Health.Increase(value);

        public void ResetProgress()
        {
            _money.SetMaxValue(_amountOfMoney);
            _money.SetValue(_money.MaxValue);
        }

        public bool TryPay(int price)
        {
            if (price > Money.CurrentValue)
                return false;

            _money.Decrease(price);

            return true;
        }

        public IReadOnlyList<IUpgrader> GetUpgraders()
        {
            IUpgrader[] upgradables = { _healthUpgrader, _defensiveSystem.Upgrader, _garrison.Upgrader, _church.Upgrader };

            return upgradables;
        }

        protected override void Work()
        {
            base.Work();

            _defensiveSystem.Defend();

            if (_garrison.KeeperOfTriggerdOpponents.IsEmpty == false)
                _church.ReplenishFaithPoints();
        }
    }
}
