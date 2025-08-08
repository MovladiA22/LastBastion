using LastBastion.UnitSpawners.PlayerSpawners;
using LastBastion.UpgradeSystem.Interfaces;
using LastBastion.CombatSystem.Interfaces;
using System.Collections.Generic;
using LastBastion.ResourceSystem;
using LastBastion.UpgradeSystem;
using LastBastion.Units;
using Common.Interfaces;
using UnityEngine;
using System;

namespace LastBastion.Bases.PlayerBase
{
    internal class PlayerGarrison : BaseGarrison, IUpgradable
    {
        private const int ProvisionCutoffLimit = 1;
        private const int OneHundredMultiplier = 100;

        private readonly List<PlayerUnitSpawner> _unitSpawners = new();

        [SerializeField] private Upgrader _unitAccessUpgrader;

        private Provisions _provisions;

        public IPayable Payable { get; private set; }
        public IUpgrader Upgrader => _unitAccessUpgrader;
        public UpgradeLevel Level => _unitAccessUpgrader.Level;
        public bool SpawnCooldownIsUp => SpawnCooldownTimer.IsTimeUp;

        public override void Init()
        {
            base.Init();

            _unitAccessUpgrader.SetUpgradable(this);

            foreach (var spawner in UnitSpawners)
            {
                if (spawner is not PlayerUnitSpawner)
                    throw new ArgumentNullException(nameof(UnitSpawners));

                _unitSpawners.Add((PlayerUnitSpawner)spawner);
            }
        }

        public override void Activate()
        {
            base.Activate();

            EnemyTrigger.OnEntered += OnHabdleEnemyTriggerEntered;
            EnemyTrigger.OnLeft += OnHabdleEnemyTriggerLeft;
        }

        public override void Work()
        {
            base.Work();

            if (KeeperOfTriggerdOpponents.IsEmpty && UnitСommander.NumberOfUnits == 0)
                _provisions.UpdateProvisionsIncrease(Payable.Money.CurrentValue / OneHundredMultiplier);
            else if (UnitСommander.NumberOfUnits > ProvisionCutoffLimit)
                _provisions.UpdateProvisionsDecrease(UnitСommander.NumberOfUnits);
        }

        public override void Deactivate()
        {
            base.Deactivate();

            EnemyTrigger.OnEntered -= OnHabdleEnemyTriggerEntered;
            EnemyTrigger.OnLeft -= OnHabdleEnemyTriggerLeft;
        }

        public void SetProvisions(Provisions provisions) =>
            _provisions = provisions ?? throw new ArgumentNullException(nameof(provisions));

        public void SetPayable(IPayable payable) =>
            Payable = payable ?? throw new ArgumentNullException(nameof(payable));

        public void Upgrade() { }

        protected override bool CanSpawn(int spawnerIndex)
        {
            if (base.CanSpawn(spawnerIndex) == false || _unitSpawners[spawnerIndex].SpawnZone.IsFree == false
                || _unitSpawners[spawnerIndex].AccessLevel > Level.CurrentValue)
                return false;

            if (Payable.TryPay(_unitSpawners[spawnerIndex].Price))
            {
                foreach (var spawner in _unitSpawners)
                    spawner.InvokeActivateEvent();

                return true;
            }

            return false;
        }

        protected override void HandleSpawnCooldownOver()
        {
            if (IsUnitLimitReached)
                return;

            foreach (var spawner in _unitSpawners)
            {
                if (spawner.IsIgnoreTriggerdOpponents || KeeperOfTriggerdOpponents.IsEmpty)
                    spawner.InvokeDeactivateEvent();
            }
        }

        protected override void OnHandleUnitRemove(Unit unit) =>
            HandleSpawnCooldownOver();

        private void OnHabdleEnemyTriggerLeft(IDamageable damageable) =>
            HandleSpawnCooldownOver();

        private void OnHabdleEnemyTriggerEntered(IDamageable damageable)
        {
            foreach (var spawner in _unitSpawners)
            {
                if (spawner.IsIgnoreTriggerdOpponents == false)
                    spawner.InvokeActivateEvent();
            }
        }
    }
}
