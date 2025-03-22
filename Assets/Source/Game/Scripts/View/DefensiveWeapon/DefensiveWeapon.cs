using LastBastion.View.Interface;
using System;
using UnityEngine;

namespace LastBastion.View
{
    public abstract class DefensiveWeapon : MonoBehaviour
    {
        [SerializeField] private DamagerView _damager;
        [SerializeField] private KeeperOfTriggerdOpponents _keeperOfTriggerdOpponents;
        [SerializeField] private EnemyTrigger _enemyTrigger;

        public event Action OnDetectedEnemy;
        public event Action OnOpponentsAreOver;

        public virtual int ID { get; }

        protected virtual void OnEnable()
        {
            _enemyTrigger.OnEntered += _keeperOfTriggerdOpponents.OnAddOpponent;
            _enemyTrigger.OnLeft += _keeperOfTriggerdOpponents.OnRemoveOpponent;

            _enemyTrigger.OnEntered += InvokeDetectedEvent;
        }

        protected virtual void OnDisable()
        {
            _enemyTrigger.OnEntered -= _keeperOfTriggerdOpponents.OnAddOpponent;
            _enemyTrigger.OnLeft -= _keeperOfTriggerdOpponents.OnRemoveOpponent;

            _enemyTrigger.OnEntered -= InvokeDetectedEvent;
        }

        public void AttackEnemy()
        {
            if (_keeperOfTriggerdOpponents.TryGetOpponent(out IDamageable opponent))
                Attack(opponent);
            else
                OnOpponentsAreOver?.Invoke();
        }

        protected virtual void Attack(IDamageable damageable) =>
            _damager.Attack(damageable);

        private void InvokeDetectedEvent(IDamageable damageable)
        {
            OnDetectedEnemy?.Invoke();
        }
    }
}
