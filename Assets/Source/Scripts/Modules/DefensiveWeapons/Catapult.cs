using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace LastBastion.DefensiveWeapons
{
    internal class Catapult : DefensiveWeapon
    {
        [SerializeField] private Animator _animator;

        private readonly int _attack = Animator.StringToHash(nameof(_attack));

        protected override void OnEnable()
        {
            base.OnEnable();

            AttackSystem.OnAttacked += OnActivateAttackAnim;
        }

        protected override void OnDisable()
        {
            base.OnDisable();

            AttackSystem.OnAttacked -= OnActivateAttackAnim;
        }

        private void OnActivateAttackAnim() =>
            _animator.SetTrigger(_attack);
    }
}
