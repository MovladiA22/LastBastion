using System;
using UnityEngine.Pool;

namespace LastBastion.UnityUtilities.Spawning
{
    public class MainObjectPool
    {
        private readonly ObjectPool<SpawnableObject> _pool;
        private readonly ISpawner _spawner;

        public MainObjectPool(ISpawner spawner, int capacity, int maxSize)
        {
            _spawner = spawner ?? throw new ArgumentNullException(nameof(spawner));

            _pool = new ObjectPool<SpawnableObject>
                 (createFunc: () => CreateObj(),
                 actionOnGet: (obj) => ActivateObj(obj),
                 actionOnRelease: (obj) => DeactivateObj(obj),
                 actionOnDestroy: (obj) => DestroyObj(obj),
                 collectionCheck: false,
                 defaultCapacity: capacity,
                 maxSize: maxSize);
        }

        public void GetObj() =>
            _pool.Get();

        private SpawnableObject CreateObj()
        {
            return _spawner.CreateObj();
        }

        private void ActivateObj(SpawnableObject obj)
        {
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));

            obj.gameObject.SetActive(true);
            obj.OnReleased += _pool.Release;

            _spawner.InvokeSpawnedEvent(obj);
        }

        private void DeactivateObj(SpawnableObject obj)
        {
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));

            obj.OnReleased -= _pool.Release;
            obj.gameObject.SetActive(false);
            obj.transform.position = _spawner.SpawnPosition;
        }

        private void DestroyObj(SpawnableObject obj)
        {
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));

            _spawner.DestroyObj(obj);
        }
    }
}
