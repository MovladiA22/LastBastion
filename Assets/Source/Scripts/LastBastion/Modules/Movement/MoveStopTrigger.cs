using Common.UnityUtilities.Triggers;
using UnityEngine;
using System;

namespace LastBastion.Movement
{
    public abstract class MoveStopTrigger : TriggerHandler
    {
        public event Action<bool> OnIsStoped;

        protected override void HandleTriggerEnter(Collider2D collision)
        {
            InvokeStopEvent(true);
        }

        protected override void HandleTriggerExit(Collider2D collision)
        {
            InvokeStopEvent(false);
        }

        protected virtual void InvokeStopEvent(bool isStoped) =>
            OnIsStoped?.Invoke(isStoped);
    }
}
