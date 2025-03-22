using LastBastion.View.Interface;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

namespace LastBastion.View
{
    internal class Ballista : DefensiveWeapon
    {
        [SerializeField] private RangedWeaponSystem _rangedWeaponSystem;

        private readonly int _id = 2222;
        private Quaternion _startRotation;

        public override int ID => _id;

        private void Awake()
        {
            _startRotation = transform.rotation;
        }

        protected override void OnEnable()
        {
            base.OnEnable();

            _rangedWeaponSystem.OnHitTarget += base.Attack;
        }

        protected override void OnDisable()
        {
            base.OnDisable();

            _rangedWeaponSystem.OnHitTarget -= base.Attack;
        }

        protected override void Attack(IDamageable damageable)
        {
            var target = damageable as MonoBehaviour ?? throw new ArgumentNullException(nameof(damageable));

            Vector2 direction = (target.transform.position - transform.position).normalized;
            transform.right = direction;
            transform.rotation *= _startRotation;

            _rangedWeaponSystem.AttackTarget(target.transform);
        }
    }
}
