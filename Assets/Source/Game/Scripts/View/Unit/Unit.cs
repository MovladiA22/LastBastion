using UnityEngine;
using System;
using LastBastion.View.Interface;
using System.Collections;

namespace LastBastion.View
{
    [RequireComponent(typeof(HealthView))]
    [RequireComponent(typeof(TargetMoverView))]
    public abstract class Unit : SpawnableObject
    {
        [SerializeField] private DamagerView _damager;
        [SerializeField] private KeeperOfTriggerdOpponents _keeperOfTriggerdOpponents;
        [SerializeField] private AttackTrigger _attackTrigger;
        [SerializeField] private UnitTrigger _unitTrigger;
        [SerializeField] private float _attackCooldown;

        private HealthView _health;
        private TargetMoverView _mover;
        private bool _isCollided = false;
        private bool _isReadyAttack = true;
        private YieldInstruction _wait;

        public event Action<bool> OnIsMoved;
        public event Action OnAttacked;
        public event Action<Unit> OnDied;

        protected bool AreAnyOpponents {  get; private set; } = false;
        public IDamager Damager => _damager;

        protected virtual void Awake()
        {
            _health = GetComponent<HealthView>();
            _mover = GetComponent<TargetMoverView>();

            _wait = new WaitForSeconds(_attackCooldown);
        }

        protected virtual void OnEnable()
        {
            _health.HealFullHealth();

            _health.OnValueIsOver += OnDie;
            _mover.OnReached += OnHandleTargetReached;

            _attackTrigger.OnEntered += _keeperOfTriggerdOpponents.OnAddOpponent;
            _attackTrigger.OnLeft += _keeperOfTriggerdOpponents.OnRemoveOpponent;
            _unitTrigger.OnTriggerd += OnHandleUnitCollision;
        }

        protected virtual void OnDisable()
        {
            _health.OnValueIsOver -= OnDie;
            _mover.OnReached -= OnHandleTargetReached;

            _attackTrigger.OnEntered -= _keeperOfTriggerdOpponents.OnAddOpponent;
            _attackTrigger.OnLeft -= _keeperOfTriggerdOpponents.OnRemoveOpponent;
            _unitTrigger.OnTriggerd -= OnHandleUnitCollision;
        }

        public virtual void TryMove()
        {
            if (_isCollided == false)
                _mover.Move();
        }

        public void TryAttack()
        {
            if (_keeperOfTriggerdOpponents.TryGetOpponent(out IDamageable opponent))
            {
                Attack(opponent);
                AreAnyOpponents = true;
            }
            else
            {
                AreAnyOpponents = false;
            }
        }

        public void TransferTarget(Transform target)
        {
            if (target == null)
                throw new ArgumentNullException(nameof(target));

            _mover.SetTarget(target);
        }

        protected virtual void Attack(IDamageable opponent)
        {
            if (_isReadyAttack == false)
                return;

            InvokeAttackedEvent();
            _damager.Attack(opponent);
            _isReadyAttack = false;

            StartCoroutine(RestoreAttackAbility());
        }

        protected virtual void OnHandleTargetReached() =>
            OnIsMoved?.Invoke(false);

        protected void InvokeAttackedEvent() =>
            OnAttacked?.Invoke();

        protected void OnHandleUnitCollision(bool isCollided)
        {
            _isCollided = isCollided;
            OnIsMoved?.Invoke(!isCollided);
        }

        private void OnDie(IDamageable damageable)
        {
            OnDied?.Invoke(this);
            InvokeReleaseEvent();
        }

        private IEnumerator RestoreAttackAbility()
        {
            yield return _wait;

            _isReadyAttack = true;
        }
    }
}
