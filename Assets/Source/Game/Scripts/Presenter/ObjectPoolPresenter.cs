using LastBastion.View.Interface;
using System;
using UnityEngine.Pool;

namespace LastBastion.Presenter
{
    public class ObjectPoolPresenter
    {
        private readonly ObjectPool<SpawnableObject> _model;
        private readonly IObjectPoolView _view;

        public ObjectPoolPresenter(IObjectPoolView view, int capacity, int maxSize)
        {
            _view = view ?? throw new ArgumentNullException(nameof(view));
            
            _model = new ObjectPool<SpawnableObject>
                 (createFunc: () => CreateObj(),
                 actionOnGet: (obj) => ActivateObj(obj),
                 actionOnRelease: (obj) => DeactivateObj(obj),
                 actionOnDestroy: (obj) => DestroyObj(obj),
                 collectionCheck: false,
                 defaultCapacity: capacity,
                 maxSize: maxSize);
        }

        public void GetObj() =>
            _model.Get();

        private SpawnableObject CreateObj()
        {
            return _view.CreateObj();
        }

        private void ActivateObj(SpawnableObject obj)
        {
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));

            obj.gameObject.SetActive(true);
            obj.OnReleased += _model.Release;

            _view.InvokeSpawnedEvent(obj);
        }

        private void DeactivateObj(SpawnableObject obj)
        {
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));

            obj.OnReleased -= _model.Release;
            obj.gameObject.SetActive(false);
            obj.transform.position = _view.SpawnPosition;
        }

        private void DestroyObj(SpawnableObject obj)
        {
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));
            
            _view.DestroyObj(obj);
        }
    }
}
