using LastBastion.CombatSystem;
using UnityEngine;

namespace LastBastion.DefensiveSystem.DefensiveWeapons
{
    internal class Ballista : DefensiveWeapon
    {
        private Quaternion _startRotation;

        protected override void OnEnable()
        {
            base.OnEnable();

            _startRotation = transform.rotation;
        }

        public override void Attack()
        {
            if (AttackSystem.TryGetOpponentTransform(out Transform opponentTransform))
            {
                Vector2 direction = (opponentTransform.position - transform.position).normalized;
                transform.right = direction;
                transform.rotation *= _startRotation;
            }

            base.Attack();
        }
    }
}
