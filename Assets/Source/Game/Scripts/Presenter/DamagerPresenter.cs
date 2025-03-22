using LastBastion.Model;
using LastBastion.View.Interface;
using System;
using UnityEngine;

namespace LastBastion.Presenter
{
    public class DamagerPresenter
    {
        private readonly Damager _damager;
        private readonly IDamager _damagerView;

        public DamagerPresenter(IDamager damagerView, int damage)
        {
            _damagerView = damagerView ?? throw new ArgumentNullException(nameof(damagerView));
            _damager = new Damager(damage);
        }

        public void Enable()
        {
            _damagerView.OnAttacked += OnAttack;
        }

        public void Disable()
        {
            _damagerView.OnAttacked -= OnAttack;
        }

        private void OnAttack(IDamageable damageable)
        {
            if (damageable == null)
                throw new ArgumentNullException(nameof(damageable));

            damageable.TakeDamage(_damager.Damage);
        }
    }
}
