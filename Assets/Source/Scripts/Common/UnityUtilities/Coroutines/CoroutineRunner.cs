using System;
using UnityEngine;
using System.Collections;

namespace Common.UnityUtilities.Coroutines
{
    public class CoroutineRunner
    {
        private readonly MonoBehaviour _monoBehaviour;
        private readonly Func<IEnumerator> _routineFactory;

        private Coroutine _activeCoroutine;

        public CoroutineRunner(MonoBehaviour monoBehaviour, Func<IEnumerator> routineFactory)
        {
            _monoBehaviour = monoBehaviour ?? throw new ArgumentNullException(nameof(monoBehaviour));
            _routineFactory = routineFactory ?? throw new ArgumentNullException(nameof(routineFactory));
        }

        public void Run()
        {
            if (_monoBehaviour.gameObject.activeInHierarchy == false)
                return;

            Cancel();

            if (_monoBehaviour != null)
                _activeCoroutine = _monoBehaviour.StartCoroutine(_routineFactory());
        }

        public void Cancel()
        {
            if (_monoBehaviour.gameObject.activeInHierarchy == false)
                return;

            if (_activeCoroutine != null)
            {
                if (_monoBehaviour != null)
                    _monoBehaviour.StopCoroutine(_activeCoroutine);

                _activeCoroutine = null;
            }
        }
    }
}
