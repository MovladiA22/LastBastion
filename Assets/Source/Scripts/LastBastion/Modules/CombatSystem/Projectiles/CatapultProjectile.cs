using UnityEngine;

namespace LastBastion.CombatSystem.Projectiles
{
    internal class CatapultProjectile : PlayerProjectile
    {
        [SerializeField] private AudioSource _collisionSound;

        protected override void Awake()
        {
            base.Awake();

            Rigidbody.isKinematic = true;
        }

        public override void InvokeReleaseEvent()
        {
            base.InvokeReleaseEvent();

            Rigidbody.isKinematic = true;
        }

        protected override void ShootAtTarget(Vector2 vectorToTarget)
        {
            Rigidbody.isKinematic = false;

            base.ShootAtTarget(vectorToTarget);
        }

        protected override void FixHit(Collision2D collision)
        {
            _collisionSound.Play();

            base.FixHit(collision);
        }
    }
}
