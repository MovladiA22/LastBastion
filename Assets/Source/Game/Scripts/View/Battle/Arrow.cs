using LastBastion.View.Interface;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LastBastion.View
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Arrow : SpawnableObject
    {
        [SerializeField] private float _shootForce;
        [SerializeField] private float _shootDelayTime;

        private Rigidbody2D _rigidbody;
        private Quaternion _startRotation;
        private bool _wasShot = false;
        private YieldInstruction _wait;

        public event Action<IDamageable> OnHitTarget;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _wait = new WaitForSeconds(_shootDelayTime);
            _startRotation = transform.rotation;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.TryGetComponent<IEnemy>(out IEnemy enemy))
            {
                if (collision.gameObject.TryGetComponent(out IDamageable damageable))
                {
                    OnHitTarget?.Invoke(damageable);
                    InvokeReleaseEvent();
                }
            }
        }

        public override void InvokeReleaseEvent()
        {
            base.InvokeReleaseEvent();

            transform.rotation = _startRotation;
            _rigidbody.velocity = Vector2.zero;
            _wasShot = false;
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

            gameObject.SetActive(true);
            StartCoroutine(ShootWithDelay(vectorToTarget));
            _wasShot = true;

            return true;
        }

        private void ShootAtTarget(Vector2 vectorToTarget)
        {
            _rigidbody.velocity = vectorToTarget.normalized * _shootForce;

            transform.right = vectorToTarget.normalized;
            transform.rotation *= _startRotation;
        }

        private bool HasObstacleBetween(Vector2 vectorToTarget)
        {
            RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, vectorToTarget.normalized, vectorToTarget.magnitude);

            if (hits.Length == 0)
                return false;

            foreach (RaycastHit2D hit in hits)
            {
                if (hit.collider.TryGetComponent<IPlayer>(out _) &&
                    hit.collider.TryGetComponent<PlayerBase>(out _) == false &&
                    hit.collider.TryGetComponent<Archer>(out _) == false)
                    return true;
            }

            return false;
        }

        private IEnumerator ShootWithDelay(Vector2 vectorToTarget)
        {
            yield return _wait;

            ShootAtTarget(vectorToTarget);
        }
    }
}
