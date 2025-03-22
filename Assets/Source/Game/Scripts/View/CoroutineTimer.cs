using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LastBastion.View
{
    public class CoroutineTimer
    {
        private MonoBehaviour _monoBehaviour;
        private YieldInstruction _wait;

        public CoroutineTimer(MonoBehaviour monoBehaviour, float duration)
        {
            if (duration <= 0)
                throw new ArgumentOutOfRangeException(nameof(duration));

            _monoBehaviour = monoBehaviour ?? throw new ArgumentNullException(nameof(monoBehaviour));
            _wait = new WaitForSeconds(duration);
            IsTimeUp = true;
        }

        public bool IsTimeUp { get; private set; }
        
        public void Run()
        {
            if (IsTimeUp)
            {
                IsTimeUp = false;
                _monoBehaviour.StartCoroutine(CountingDownTime());
            }
        }

        private IEnumerator CountingDownTime()
        {
            yield return _wait;

            IsTimeUp = true;
        }
    }
}
