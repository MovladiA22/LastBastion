using System;
using System.Collections;
using UnityEngine;

namespace LastBastion.Model
{
    public class CoroutineModel
    {
        private readonly MonoBehaviour _monoBehaviour;
        private readonly IEnumerator _coroutine;
        private Coroutine _activeCoroutine;

        public CoroutineModel(MonoBehaviour monoBehaviour, IEnumerator coroutine)
        {
            _coroutine = coroutine ?? throw new ArgumentNullException(nameof(coroutine));
            _monoBehaviour = monoBehaviour ?? throw new ArgumentNullException(nameof(monoBehaviour));
        }

        public void Start()
        {
            if (_coroutine == null)
                throw new ArgumentNullException(nameof(_coroutine));

            Stop();
            _activeCoroutine = _monoBehaviour.StartCoroutine(_coroutine);
        }

        public void Stop()
        {
            if (_activeCoroutine != null)
            {
                _monoBehaviour.StopCoroutine(_activeCoroutine);
                _activeCoroutine = null;
            }
        }
    }
}
