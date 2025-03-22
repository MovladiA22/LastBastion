using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LastBastion.View
{
    public class UnitTrigger : MonoBehaviour
    {
        public event Action<bool> OnTriggerd;

        protected virtual void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent<Unit>(out Unit unit))
                OnTriggerd?.Invoke(true);
        }

        protected virtual void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.TryGetComponent<Unit>(out Unit unit))
                OnTriggerd?.Invoke(false);
        }
    }
}
