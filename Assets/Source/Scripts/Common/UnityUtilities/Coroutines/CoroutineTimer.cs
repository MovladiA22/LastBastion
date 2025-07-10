using System;
using UnityEngine;
using System.Collections;

namespace Common.UnityUtilities.Coroutines
{
    public class CoroutineTimer
    {
        private readonly CoroutineRunner _coroutineRunner;
        private readonly YieldInstruction _wait;
        private readonly Action _executeAfterDelay;

        public CoroutineTimer(MonoBehaviour monoBehaviour, float duration, Action executeAfterDelay = null)
        {
            if (duration <= 0)
                throw new ArgumentOutOfRangeException(nameof(duration));

            _executeAfterDelay = executeAfterDelay;
            _wait = new WaitForSeconds(duration);
            IsTimeUp = true;

            _coroutineRunner = new CoroutineRunner(monoBehaviour, CountingDownTime);
        }

        public bool IsTimeUp { get; private set; }

        public void Run()
        {
            if (IsTimeUp)
            {
                IsTimeUp = false;
                _coroutineRunner.Run();
            }
        }

        public void Stop()
        {
            _coroutineRunner.Cancel();
            IsTimeUp = true;
        }

        private IEnumerator CountingDownTime()
        {
            yield return _wait;

            Stop();
            _executeAfterDelay?.Invoke();
        }
    }
}
