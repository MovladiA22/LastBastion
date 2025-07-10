using LastBastion.CombatSystem.Projectiles;
using LastBastion.CombatSystem.Triggers;
using UnityEngine;

namespace LastBastion.CombatSystem
{
    public class RangedWeaponSystem : AttackSystem
    {
        [SerializeField] private Projectile _projectile;
        [SerializeField] private ProjectileOutOfBoundsTrigger _outOfBoundsTrigger;

        private Vector2 _arrowStartPosition;

        protected override void Awake()
        {
            base.Awake();

            _outOfBoundsTrigger.SetProjectile(_projectile);
        }

        protected override void OnEnable()
        {
            base.OnEnable();

            _arrowStartPosition = _projectile.transform.localPosition;

            _projectile.OnHitTarget += Damager.DealDamage;
        }

        protected override void OnDisable()
        {
            base.OnDisable();

            _projectile.OnHitTarget -= Damager.DealDamage;
        }

        protected override void Attack()
        {
            if (CooldownTimer.IsTimeUp == false)
                return;

            _projectile.InvokeReleaseEvent();
            _projectile.transform.localPosition = _arrowStartPosition;

            if (TryGetOpponentTransform(out Transform opponentTransform))
            {
                if (_projectile.TryLaunch(opponentTransform))
                    HandleAttack();
            }
        }
    }
}
