using LastBastion.CombatSystem.Interfaces;
using LastBastion.CombatSystem;
using Common.Interfaces;
using UnityEngine;
using System;

namespace LastBastion.DefensiveSystem
{
    public abstract class DefensiveWeapon : MonoBehaviour, IAttacker, IIndexable, ICostable, IAccessLevel
    {
        public event Action OnEnabled;
        public event Action OnDisabled;

        [field: SerializeField, Min(0)] public int Price {  get; private set; }
        [field: SerializeField, Min(0)] public int AccessLevel { get; private set; }
        [field: SerializeField] protected AttackSystem AttackSystem { get; private set; }

        public int Index { get; private set; }
        public bool IsActivated { get; private set; } = false;

        protected virtual void OnEnable()
        {
            IsActivated = true;
            OnEnabled?.Invoke();
        }

        protected virtual void OnDisable()
        {
            IsActivated = false;
            OnDisabled?.Invoke();
        }

        public void SetIndex(int index)
        {
            if (index < 0)
                throw new ArgumentOutOfRangeException(nameof(index));

            Index = index;
        }

        public virtual void Attack()
        {
            AttackSystem.TryAttack();
        }
    }
}
