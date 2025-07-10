using System;
using UnityEngine;
using LastBastion.Movement;
using LastBastion.CombatSystem;
using LastBastion.Units.Triggers;
using Common.UnityUtilities.Input;
using LastBastion.CombatSystem.Logic;
using LastBastion.CombatSystem.Interfaces;
using LastBastion.UnityUtilities.Spawning;

namespace LastBastion.Units
{
    [RequireComponent(typeof(TargetMover))]
    public abstract class Unit : SpawnableObject, IMovable, IAttacker, IDamageable, IClickable
    {
        [SerializeField, Min(1)] private int _healthValue;
        [SerializeField] private UnitStopTrigger _moveStopTrigger;
        [SerializeField] private DamageReaction _damageReaction;

        private Health _health;
        private TargetMover _mover;
        private bool _isAbleToMove = true;

        public event Action OnAttacked;
        public event Action<Unit> OnDied;
        public event Action<bool> OnIsMoved;
        public event Action<IDamageable> OnHealthIsOver;

        [field: SerializeField] protected virtual AttackSystem AttackSystem { get; private set; }

        protected virtual void Awake()
        {
            _health = new Health(_healthValue);
            _mover = GetComponent<TargetMover>();
        }

        protected virtual void OnEnable()
        {
            _moveStopTrigger.OnIsStoped += OnHandleUnitStopping;
            AttackSystem.OnAttacked += InvokeAttackedEvent;
        }

        protected virtual void OnDisable()
        {
            _moveStopTrigger.OnIsStoped -= OnHandleUnitStopping;
            AttackSystem.OnAttacked -= InvokeAttackedEvent;
        }

        public virtual void Move(Vector2 targetPositon)
        {
            if (_isAbleToMove)
                _mover.UpdatePositon(targetPositon);
        }

        public virtual void Attack()
        {
            if (_isAbleToMove == false)
                AttackSystem.TryAttack();
        }

        public virtual void TakeDamage(int amount)
        {
            _damageReaction.ActivateEffect();

            _health.Decrease(amount);

            if (_health.CurrentValue == 0)
                Die();
        }

        public override void InvokeReleaseEvent()
        {
            _health.ReplenishFullValue();

            base.InvokeReleaseEvent();
        }

        public void Die()
        {
            InvokeReleaseEvent();

            OnHealthIsOver?.Invoke(this);
            OnDied?.Invoke(this);
        }

        protected void InvokeAttackedEvent() =>
            OnAttacked?.Invoke();

        protected void OnHandleUnitStopping(bool isStoped)
        {
            _isAbleToMove = isStoped == false;
            OnIsMoved?.Invoke(_isAbleToMove);
        }
    }
}
