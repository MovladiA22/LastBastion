using System.Collections.Generic;
using UnityUtilities.Coroutines;
using LastBastion.CombatSystem;
using LastBastion.UnitSpawners;
using LastBastion.Units;
using Common.Interfaces;
using UnityEngine;
using System;

namespace LastBastion.Bases
{
    public abstract class BaseGarrison : ManagedBehavior
    {
        [SerializeField, Min(0.1f)] private float _spawnCooldown;
        [SerializeField, Min(1)] private int _limitOfSimultaneousPresenceOfUnits = 5;

        [field: SerializeField] protected EnemyAttackTrigger EnemyTrigger { get; private set; }
        [field: SerializeField] protected UnitСommander UnitСommander { get; private set; }
        [field: SerializeField] protected List<UnitSpawner> UnitSpawners { get; private set; }

        public KeeperOfTriggerdOpponents KeeperOfTriggerdOpponents { get; private set; }
        protected CoroutineTimer SpawnCooldownTimer { get; private set; }
        protected bool IsUnitLimitReached => UnitСommander.NumberOfUnits >= _limitOfSimultaneousPresenceOfUnits;

        public override void Init()
        {
            KeeperOfTriggerdOpponents = new KeeperOfTriggerdOpponents();
            SpawnCooldownTimer = new CoroutineTimer(this, _spawnCooldown, HandleSpawnCooldownOver);

            for (int i = 0; i < UnitSpawners.Count; i++)
            {
                UnitSpawners[i].SetIndex(i);
            }
        }

        public override void Activate()
        {
            base.Activate();

            EnemyTrigger.OnEntered += KeeperOfTriggerdOpponents.AddOpponent;
            EnemyTrigger.OnLeft += KeeperOfTriggerdOpponents.RemoveOpponent;
            UnitСommander.OnUnitRemoved += OnHandleUnitRemove;

            foreach (var unitSpawner in UnitSpawners)
                unitSpawner.OnSpawned += UnitСommander.OnAddUnit;
        }

        public virtual void Work()
        {
            UnitСommander.SendUnitsToAttack();
        }

        public override void Deactivate()
        {
            base.Deactivate();

            SpawnCooldownTimer.Stop();
            UnitСommander.RecallUnits();
            KeeperOfTriggerdOpponents.RemoveAllOpponents();

            EnemyTrigger.OnEntered -= KeeperOfTriggerdOpponents.AddOpponent;
            EnemyTrigger.OnLeft -= KeeperOfTriggerdOpponents.RemoveOpponent;
            UnitСommander.OnUnitRemoved -= OnHandleUnitRemove;

            foreach (var unitSpawner in UnitSpawners)
                unitSpawner.OnSpawned -= UnitСommander.OnAddUnit;
        }

        public void SpawnUnit(int spawnerIndex)
        {
            if (CanSpawn(spawnerIndex))
            {
                SpawnCooldownTimer.Run();
                UnitSpawners[spawnerIndex].Spawn();
            }
        }

        protected virtual bool CanSpawn(int spawnerIndex)
        {
            if (spawnerIndex < 0 || spawnerIndex >= UnitSpawners.Count)
                throw new ArgumentOutOfRangeException(nameof(spawnerIndex));

            if (IsActivated == false || IsUnitLimitReached || SpawnCooldownTimer.IsTimeUp == false)
                return false;

            return KeeperOfTriggerdOpponents.IsEmpty || UnitSpawners[spawnerIndex].IsIgnoreTriggerdOpponents;
        }

        protected virtual void HandleSpawnCooldownOver() { }

        protected virtual void OnHandleUnitRemove(Unit unit) { }
    }
}
