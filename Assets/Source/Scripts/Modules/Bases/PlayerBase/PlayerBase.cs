using System.Collections.Generic;
using LastBastion.BlessingSystem;
using LastBastion.UpgradeSystem;
using LastBastion.CombatSystem;
using Common.VariableSystem;
using Common.Interfaces;
using UnityEngine;
using System;

namespace LastBastion.Bases
{
    public class PlayerBase : Base, IPlayer, IUpgradable, IRestorable, IPayable
    {
        [SerializeField] private DefensiveSystem _defensiveSystem;
        [SerializeField] private IntUpgrader _healthUpgrader;
        [SerializeField] private Church _church;
        [SerializeField] private BountyCollector _bountyCollector;

        [SerializeField, Min(0)] private int _provisionsValue;
        [SerializeField, Min(0)] private int _amountOfMoney;

        private PlayerGarrison _garrison;
        private PlayerBaseMoney _money;
        private Provisions _provisions;

        public Level Level => _healthUpgrader.Level;
        public IVariableInt Provisions => _provisions;
        public IVariableInt Money => _money;

        public override void Init()
        {
            base.Init();
            _garrison = Garrison as PlayerGarrison ?? throw new ArgumentNullException(nameof(_garrison));

            _money = new PlayerBaseMoney(_amountOfMoney);
            _provisions = new Provisions(_provisionsValue);

            _healthUpgrader.SetUpgradable(this);
            _garrison.SetPayable(this);
            _defensiveSystem.SetPayable(this);
            _bountyCollector.SetMoney(_money);

            _defensiveSystem.Init();
            _church.Init();
        }

        public override void Activate()
        {
            base.Activate();
            _provisions.OnOutOfProvisions += HandleDestruction;

            _defensiveSystem.Activate();
            _church.Activate();
        }

        public override void Deactivate()
        {
            base.Deactivate();
            _provisions.OnOutOfProvisions -= HandleDestruction;

            _money.ReplenishFullValue();

            _defensiveSystem.Deactivate();
            _church.Deactivate();
            _provisions.ReplenishFullValue();
        }

        public void Upgrade()
        {
            Health.SetMaxValue(_healthUpgrader.GetUpgradedValue());
        }

        public void Restore(int value) =>
            Health.Increase(value);

        public bool TryPay(int price)
        {
            if (price > Money.CurrentValue)
                return false;

            _money.Decrease(price);

            return true;
        }

        public void SetMoneyValue(int amount) =>
            _money.SetMaxValue(amount);

        public void ResetProgress() =>
            _money.SetMaxValue(_amountOfMoney);

        public IReadOnlyList<IUpgrader> GetUpgraders()
        {
            IUpgrader[] upgradables = { _healthUpgrader, _defensiveSystem.Upgrader, _garrison.Upgrader, _church.Upgrader };

            return upgradables;
        }

        protected override void Work()
        {
            base.Work();

            _defensiveSystem.Defend();
            _provisions.UpdateProvisionsDecrease();

            if (_garrison.KeeperOfTriggerdOpponents.IsEmpty == false)
                _church.ReplenishFaithPoints();
        }
    }
}
