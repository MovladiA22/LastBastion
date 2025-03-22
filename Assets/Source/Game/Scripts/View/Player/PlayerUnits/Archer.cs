using LastBastion.View.Interface;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

namespace LastBastion.View
{
    public class Archer : Unit, IPlayer
    {
        [SerializeField] private RangedWeaponSystem _rangedWeaponSystem;

        protected override void OnEnable()
        {
            base.OnEnable();

            _rangedWeaponSystem.OnHitTarget += Damager.Attack;
            _rangedWeaponSystem.OnShooted += InvokeAttackedEvent;
        }

        protected override void OnDisable()
        {
            base.OnDisable();

            _rangedWeaponSystem.OnHitTarget -= Damager.Attack;
            _rangedWeaponSystem.OnShooted -= InvokeAttackedEvent;
        }

        public override void TryMove()
        {
            if (AreAnyOpponents)
                OnHandleUnitCollision(AreAnyOpponents);

            base.TryMove();
        }

        protected override void Attack(IDamageable opponent)
        {
            var target = opponent as MonoBehaviour ?? throw new ArgumentNullException(nameof(opponent));

            _rangedWeaponSystem.AttackTarget(target.transform);
        }
    }
}
