using System;
using UnityEngine;
using UnityUtilities.Coroutines;

namespace LastBastion.CombatSystem
{
    public abstract class AttackSystem : MonoBehaviour
    {
        [SerializeField] private AttackTrigger _attackTrigger;
        [SerializeField, Min(0)] private int _damageValue;
        [SerializeField, Min(0.01f)] private float _attackCooldown;
        [SerializeField, Min(0.01f)] private float _damageDelay;

        private Damager _damager;
        private KeeperOfTriggerdOpponents _keeperOfTriggerdOpponents;
        private CoroutineTimer _damageDelayTimer;

        public event Action OnAttacked;

        [field: SerializeField] protected AudioSource AttackSound {  get; private set; }
        public IKeeperOpponents KeeperOpponents => _keeperOfTriggerdOpponents;
        protected CoroutineTimer CooldownTimer { get; private set; }
        protected Damager Damager => _damager;

        protected virtual void Awake()
        {
            _damager = new Damager(_damageValue);
            _keeperOfTriggerdOpponents = new KeeperOfTriggerdOpponents();
            CooldownTimer = new CoroutineTimer(this, _attackCooldown);
            _damageDelayTimer = new CoroutineTimer(this, _damageDelay, DelayDamage);

        }

        protected virtual void OnEnable()
        {
            _attackTrigger.OnEntered += _keeperOfTriggerdOpponents.AddOpponent;
            _attackTrigger.OnLeft += _keeperOfTriggerdOpponents.RemoveOpponent;
        }

        protected virtual void OnDisable()
        {
            CooldownTimer.Stop();

            _attackTrigger.OnEntered -= _keeperOfTriggerdOpponents.AddOpponent;
            _attackTrigger.OnLeft -= _keeperOfTriggerdOpponents.RemoveOpponent;

            _keeperOfTriggerdOpponents.RemoveAllOpponents();
        }

        public void TryAttack()
        {
            if (_keeperOfTriggerdOpponents.IsEmpty == false)
                Attack();
        }

        public bool TryGetOpponentTransform(out Transform opponentTransform)
        {
            opponentTransform = null;

            if (_keeperOfTriggerdOpponents.IsEmpty)
                return false;

            if (_keeperOfTriggerdOpponents.GetFirstOpponent() is MonoBehaviour monoBehaviour)
            {
                opponentTransform = monoBehaviour.transform;
                return true;
            }

            return false;
        }

        public void InvokeAttackEvent()
        {
            OnAttacked?.Invoke();
            AttackSound.Play();
            CooldownTimer.Run();
        }

        protected virtual void Attack()
        {
            if (CooldownTimer.IsTimeUp == false)
                return;

            InvokeAttackEvent();

            _damageDelayTimer.Run();
        }

        protected virtual void DelayDamage()
        {
            if (gameObject == null || _keeperOfTriggerdOpponents.GetFirstOpponent() == null)
                return;
        }
    }
}