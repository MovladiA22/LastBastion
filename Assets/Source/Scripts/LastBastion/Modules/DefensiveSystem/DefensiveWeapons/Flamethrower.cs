using LastBastion.CombatSystem;
using UnityEngine;

namespace LastBastion.DefensiveSystem.DefensiveWeapons
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
