using LastBastion.CombatSystem.Interfaces;
using Common.UnityUtilities.Triggers;
using UnityEngine;
using System;

namespace LastBastion.CombatSystem.Triggers
{
    public abstract class AttackTrigger : TriggerHandler
    {
        public event Action<IDamageable> OnEntered;
        public event Action<IDamageable> OnLeft;

        protected override void HandleTriggerEnter(Collider2D collision)
        {
            if (collision.TryGetComponent(out IDamageable damageable))
                OnEntered?.Invoke(damageable);
        }

        protected override void HandleTriggerExit(Collider2D collision)
        {
            if (collision.TryGetComponent(out IDamageable damageable))
                OnLeft?.Invoke(damageable);
        }
    }
}
