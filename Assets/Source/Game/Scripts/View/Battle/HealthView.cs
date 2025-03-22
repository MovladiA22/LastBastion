using LastBastion.Presenter;
using LastBastion.View.Interface;
using System;
using UnityEngine;

namespace LastBastion.View
{
    [RequireComponent(typeof(DamageReaction))]
    internal class HealthView : MonoBehaviour, IHealthView, IDamageable, IHealiable
    {
        [SerializeField, Min(1)] private int _maxValue;

        private HealthPresenter _healthPresenter;
        private DamageReaction _damageReaction;

        public event Action<int> OnValueIncreased;
        public event Action<int> OnValueDecreased;
        public event Action<IDamageable> OnValueIsOver;

        private void Awake()
        {
            _healthPresenter = new HealthPresenter(this, _maxValue);
            _damageReaction = GetComponent<DamageReaction>();
        }

        private void OnEnable()
        {
            _healthPresenter.Enable();
        }

        private void OnDisable()
        {
            _healthPresenter.Disable();
        }

        public void TakeDamage(int amount)
        {
            if (amount < 0)
                throw new ArgumentOutOfRangeException(nameof(amount));

            OnValueDecreased?.Invoke(amount);
            ReactToDamage();
            Debug.Log(gameObject.name + _healthPresenter.CurrentValue);

            if (_healthPresenter.CurrentValue == 0)
                OnValueIsOver?.Invoke(this);
        }

        public void HealFullHealth() =>
            OnValueIncreased?.Invoke(_maxValue);

        public void ReactToDamage() =>
            _damageReaction.ActivateEffect();
    }
}
