using System;
using UnityEngine;
using Common.Input;
using LastBastion.Movement;
using LastBastion.Spawning;
using LastBastion.CombatSystem;

namespace LastBastion.Units
{
    [RequireComponent(typeof(TargetMover), typeof(DamageReaction))]
    public abstract class Unit : SpawnableObject, IMovable, IAttacker, IDamageable, IClickable
    {
        [SerializeField] private int _healthValue;
        [SerializeField] private UnitStopTrigger _moveStopTrigger;

        private Health _health;
        private TargetMover _mover;
        private DamageReaction _damageReaction;
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
            _damageReaction = GetComponent<DamageReaction>();
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
            ReactToDamage();

            _health.Decrease(amount);
            Debug.Log(gameObject.name + ": " + _health.CurrentValue);
            if (_health.CurrentValue == 0)
                HandleDeath();
        }

        public void ReactToDamage() =>
            _damageReaction.ActivateEffect();

        public override void InvokeReleaseEvent()
        {
            _health.ReplenishFullValue();

            base.InvokeReleaseEvent();
        }

        public void HandleDeath()
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
