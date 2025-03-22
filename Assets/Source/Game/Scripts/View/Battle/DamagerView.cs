using LastBastion.Presenter;
using LastBastion.View.Interface;
using System;
using System.Collections;
using UnityEngine;

namespace LastBastion.View
{
    internal class DamagerView : MonoBehaviour, IDamager
    {
        [SerializeField, Min(1)] private int _damage;
        [SerializeField, Min(0.01f)] private float _damageDelay = 0.4f;

        private DamagerPresenter _damagerPresenter;
        private bool _isAttacking = false;
        private YieldInstruction _wait;

        public event Action<IDamageable> OnAttacked;

        private void Awake()
        {
            _damagerPresenter = new DamagerPresenter(this, _damage);
            _wait = new WaitForSeconds(_damageDelay);
        }

        private void OnEnable()
        {
            _damagerPresenter.Enable();

            _isAttacking = false;
        }

        private void OnDisable()
        {
            _damagerPresenter.Disable();
        }

        public void Attack(IDamageable damageable)
        {
            if (_isAttacking)
                return;

            _isAttacking = true;

            StartCoroutine(DelayDamage(damageable));
        }

        private IEnumerator DelayDamage(IDamageable damageable)
        {
            yield return _wait;

            OnAttacked?.Invoke(damageable);
            _isAttacking = false;
        }
    }
}
