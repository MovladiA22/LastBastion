using UnityEngine;
using System;
using LastBastion.Presenter;
using LastBastion.View.Interface;

namespace LastBastion.View
{
    public abstract class UnitSpawner : MonoBehaviour, IObjectPoolView, ISpawner
    {
        [SerializeField] private Transform _spawner;
        [SerializeField, Min(1)] private int _capacity = 5;
        [SerializeField, Min(1)] private int _maxSize = 15;
        [SerializeField] private float _cooldownTime;

        private ObjectPoolPresenter _poolPresenter;
        private CoroutineTimer _cooldownTimer;

        public event Action<Unit> OnSpawned;

        public Vector2 SpawnPosition => _spawner.position;

        private void Awake()
        {
            _poolPresenter = new ObjectPoolPresenter(this, _capacity, _maxSize);
            _cooldownTimer = new CoroutineTimer(this, _cooldownTime);
        }

        public void Spawn()
        {
            if (_cooldownTimer.IsTimeUp)
            {
                _cooldownTimer.Run();
                _poolPresenter.GetObj();
            }
        }

        public virtual SpawnableObject CreateObj()
        {
            return null;
        }

        public void DestroyObj(SpawnableObject obj)
        {
            Destroy(obj.gameObject);
        }

        public void InvokeSpawnedEvent(SpawnableObject obj)
        {
            if (obj is Unit unit)
                OnSpawned?.Invoke(unit);
        }
    }
}
