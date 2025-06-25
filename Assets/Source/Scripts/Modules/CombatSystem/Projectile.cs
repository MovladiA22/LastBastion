using LastBastion.Spawning;
using System.Collections;
using UnityEngine;
using System;

namespace LastBastion.CombatSystem
{
    [RequireComponent(typeof(Rigidbody2D), typeof(SpriteRenderer))]
    public class Projectile : SpawnableObject
    {
        [SerializeField] private float _shootForce;
        [SerializeField] private float _shootDelayTime;

        private SpriteRenderer _spriteRenderer;
        private YieldInstruction _wait;
        private bool _wasShot = false;

        public event Action<IDamageable> OnHitTarget;

        protected Rigidbody2D Rigidbody { get; private set; }

        protected virtual void Awake()
        {
            Rigidbody = GetComponent<Rigidbody2D>();
            _spriteRenderer = GetComponent<SpriteRenderer>();

            _spriteRenderer.enabled = false;
            _wait = new WaitForSeconds(_shootDelayTime);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            FixHit(collision);
        }

        public override void InvokeReleaseEvent()
        {
            _spriteRenderer.enabled = false;
            Rigidbody.velocity = Vector2.zero;
            _wasShot = false;

            base.InvokeReleaseEvent();
        }

        public bool TryLaunch(Transform target)
        {
            if (_wasShot)
                return false;
            else if (target == null)
                throw new ArgumentNullException(nameof(target));

            Vector2 vectorToTarget = target.position - transform.position;

            if (HasObstacleBetween(vectorToTarget))
                return false;

            StartCoroutine(ShootWithDelay(vectorToTarget));
            _wasShot = true;

            return true;
        }

        protected virtual void FixHit(Collision2D collision)
        {
            if (collision.gameObject.TryGetComponent(out IDamageable damageable))
            {
                OnHitTarget?.Invoke(damageable);
                InvokeReleaseEvent();
            }
        }

        protected virtual bool HaveObstaclesBeenFound(RaycastHit2D[] hits) =>
            false;

        protected virtual void ShootAtTarget(Vector2 vectorToTarget) =>
            Rigidbody.velocity = vectorToTarget.normalized * _shootForce;

        private bool HasObstacleBetween(Vector2 vectorToTarget)
        {
            RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, vectorToTarget.normalized, vectorToTarget.magnitude);

            if (hits.Length == 0)
                return false;

            return HaveObstaclesBeenFound(hits);
        }

        private IEnumerator ShootWithDelay(Vector2 vectorToTarget)
        {
            yield return _wait;

            _spriteRenderer.enabled = true;
            ShootAtTarget(vectorToTarget);
        }
    }
}
