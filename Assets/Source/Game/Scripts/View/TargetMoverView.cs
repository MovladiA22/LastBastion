using LastBastion.Presenter;
using LastBastion.View.Interface;
using System;
using UnityEngine;

namespace LastBastion.View
{
    internal class TargetMoverView : MonoBehaviour, IMovable
    {
        [SerializeField, Min(0.01f)] private float _speed;
        [SerializeField, Min(0.01f)] private float _stoppingDistance;

        private TargetMoverPresenter _presenter;
        private Transform _target;

        public event Action OnMoved;
        public event Action OnReached;

        public Vector2 CurrentPosition => transform.position;
        public Vector2 TargetPosition => _target.position;

        private void Awake()
        {
            _presenter = new TargetMoverPresenter(this, _speed, _stoppingDistance);
        }

        private void OnEnable()
        {
            _presenter.Enable();
        }

        private void OnDisable()
        {
            _presenter.Disable();
        }

        public void Move()
        {
            if (_target == null)
                throw new ArgumentNullException(nameof(_target));

            OnMoved?.Invoke();
        }

        public void UpdatePosition(Vector2 newPosition)
        {
            transform.position = newPosition;
        }

        public void SetTarget(Transform target) =>
            _target = target ?? throw new ArgumentNullException(nameof(target));

        public void InvokeReachedEvent() =>
            OnReached?.Invoke();
    }
}
