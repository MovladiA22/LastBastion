using System;
using UnityEngine;
using System.Collections;
using Common.UnityUtilities.Behaviors;
using Common.UnityUtilities.Coroutines;

namespace Common.UnityUtilities.Input
{
    public abstract class ClickTracker<Object> : MonoBehaviour, IActivable
    {
        private readonly int _mouseButtonNumber = 0;

        [SerializeField] private Camera _camera;

        private RaycastHit2D[] _hits;
        private Vector2 _mousePosition;
        private CoroutineRunner _coroutineRunner;

        public event Action<Object> OnClicked;

        public bool IsActivated { get; private set; } = false;

        protected virtual void Awake()
        {
            _coroutineRunner = new CoroutineRunner(this, TrackClick);
        }

        public virtual void Activate()
        {
            if (IsActivated)
                return;

            IsActivated = true;
            _coroutineRunner.Run();
        }

        public virtual void Deactivate()
        {
            if (IsActivated == false)
                return;

            IsActivated = false;
            _coroutineRunner.Cancel();
        }

        protected virtual void HandleClick(Object obj) =>
            OnClicked?.Invoke(obj);
        
        private IEnumerator TrackClick()
        {
            while (IsActivated)
            {
                if (UnityEngine.Input.GetMouseButtonDown(_mouseButtonNumber))
                {
                    _mousePosition = _camera.ScreenToWorldPoint(UnityEngine.Input.mousePosition);

                    _hits = Physics2D.RaycastAll(_mousePosition, Vector2.zero);

                    foreach(var hit in _hits)
                    {
                        if (hit.collider != null && hit.collider.TryGetComponent<IClickable>(out _))
                            if (hit.collider.TryGetComponent(out Object obj))
                                HandleClick(obj);
                    }
                }
                
                yield return null;
            }
        }
    }
}
