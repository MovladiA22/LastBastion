using System;
using UnityEngine;
using Common.Interfaces;
using LastBastion.Units;
using LastBastion.UnityUtilities.Spawning;

namespace LastBastion.UnitSpawners
{
    public abstract class UnitSpawner : MonoBehaviour, ISpawner, IIndexable
    {
        [SerializeField] private UnitSpawnZone _spawnZone;
        [SerializeField, Min(1)] private int _capacity = 5;
        [SerializeField, Min(1)] private int _maxSize = 15;

        private MainObjectPool _pool;

        public event Action<Unit> OnSpawned;

        public int Index { get; private set; }
        public IUnitSpawnZone SpawnZone => _spawnZone;
        public Vector2 SpawnPosition => _spawnZone.transform.position;
        public virtual bool IsIgnoreTriggerdOpponents => false;

        protected virtual void Awake()
        {
            _pool = new MainObjectPool(this, _capacity, _maxSize);
        }

        public abstract SpawnableObject CreateObj();

        public void Spawn() =>
            _pool.GetObj();

        public void DestroyObj(SpawnableObject obj) =>
            Destroy(obj.gameObject);

        public void InvokeSpawnedEvent(SpawnableObject obj)
        {
            if (obj is Unit unit)
                OnSpawned?.Invoke(unit);
        }

        public void SetIndex(int index)
        {
            if (index < 0)
                throw new ArgumentOutOfRangeException(nameof(index));

            Index = index;
        }
    }
}
