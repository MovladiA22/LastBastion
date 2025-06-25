using LastBastion.CombatSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace LastBastion.DefensiveWeapons
{
    internal class Flamethrower : DefensiveWeapon
    {
        [SerializeField] private ParticleSystem _particleSystem;

        protected override void OnEnable()
        {
            base.OnEnable();

            AttackSystem.OnAttacked += OnActivateEffect;
        }

        protected override void OnDisable()
        {
            base.OnDisable();

            AttackSystem.OnAttacked -= OnActivateEffect;
        }

        private void OnActivateEffect() =>
            _particleSystem.Play();
    }
}
