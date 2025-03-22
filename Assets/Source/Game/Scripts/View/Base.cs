using LastBastion.View.Interface;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LastBastion.View
{
    [RequireComponent(typeof(HealthView))]
    internal abstract class Base : MonoBehaviour
    {
        [SerializeField] private List<UnitSpawner> _unitSpawners;
        [SerializeField] private Unit—ommander _unit—ommander;
        [SerializeField] private KeeperOfTriggerdOpponents _keeperOfTriggerdOpponents;
        [SerializeField] private EnemyTrigger _enemyTrigger;

        private HealthView _health;

        public event Action OnDestroyed;

        protected int SpawnerCount => _unitSpawners.Count;

        private void Awake()
        {
            _health = GetComponent<HealthView>();
        }

        private void OnEnable()
        {
            _health.OnValueIsOver += OnHanldleDestruction;

            _enemyTrigger.OnEntered += _keeperOfTriggerdOpponents.OnAddOpponent;
            _enemyTrigger.OnLeft += _keeperOfTriggerdOpponents.OnRemoveOpponent;

            foreach (var unitSpawner in _unitSpawners)
                unitSpawner.OnSpawned += _unit—ommander.OnAddUnit;
        }

        private void OnDisable()
        {
            _health.OnValueIsOver -= OnHanldleDestruction;

            _enemyTrigger.OnEntered -= _keeperOfTriggerdOpponents.OnAddOpponent;
            _enemyTrigger.OnLeft -= _keeperOfTriggerdOpponents.OnRemoveOpponent;

            foreach (var unitSpawner in _unitSpawners)
                unitSpawner.OnSpawned -= _unit—ommander.OnAddUnit;
        }

        public void SpawnUnit(int spawnerIndex)
        {
            if (spawnerIndex < 0 || spawnerIndex >= _unitSpawners.Count)
                throw new ArgumentOutOfRangeException(nameof(spawnerIndex));

            if (_keeperOfTriggerdOpponents.TryGetOpponent(out _) == false || IsSpawnNeeded(spawnerIndex))
                _unitSpawners[spawnerIndex].Spawn();
        }

        protected virtual bool IsSpawnNeeded(int spawnerIndex) { return false; }

        protected virtual void OnHanldleDestruction(IDamageable damageable)
        {
            OnDestroyed?.Invoke();
        }
    }
}
