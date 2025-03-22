using LastBastion.Presenter;
using LastBastion.View.Interface;
using System;
using System.Collections;
using UnityEngine;

namespace LastBastion.View
{
    internal class CoroutineView : MonoBehaviour, ICoroutineView
    {
        private CoroutinePresenter _coroutinePresenter;

        public event Action OnStarted;
        public event Action OnStopped;

        private void OnDisable()
        {
            if (_coroutinePresenter != null)
            {
                Cancel();
                _coroutinePresenter.Disable();
            }
        }

        public void CreateCoroutine(IEnumerator coroutine)
        {
            if (coroutine == null)
                throw new ArgumentNullException(nameof(coroutine));
            if (_coroutinePresenter != null)
                Cancel();

            _coroutinePresenter = new CoroutinePresenter(coroutine, this, this);
            _coroutinePresenter.Enable();
        }

        public void Run()
        {
            if (_coroutinePresenter == null)
                throw new ArgumentNullException(nameof(_coroutinePresenter));
            
            OnStarted?.Invoke();
        }

        public void Cancel()
        {
            if (_coroutinePresenter == null)
                throw new ArgumentNullException(nameof(_coroutinePresenter));

            OnStopped?.Invoke();
        }
    }
}
