using UnityEngine;

namespace LastBastion.DefensiveSystem.DefensiveWeapons
{
    internal class Catapult : DefensiveWeapon
    {
        private readonly int _attack = Animator.StringToHash(nameof(_attack));

        [SerializeField] private Animator _animator;

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
