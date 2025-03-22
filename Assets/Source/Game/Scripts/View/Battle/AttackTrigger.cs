using LastBastion.View.Interface;
using System;
using UnityEngine;

namespace LastBastion.View
{
    public abstract class AttackTrigger : MonoBehaviour
    {
        public event Action<IDamageable> OnEntered;
        public event Action<IDamageable> OnLeft;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out IDamageable damageable) && IsRightDamageable(collision))
                OnEntered?.Invoke(damageable);
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out IDamageable damageable) && IsRightDamageable(collision))
                OnLeft?.Invoke(damageable);
        }

        protected virtual bool IsRightDamageable(Collider2D collision)
        {
            return false;
        }
    }
}
