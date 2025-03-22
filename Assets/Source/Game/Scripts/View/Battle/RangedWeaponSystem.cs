using LastBastion.View.Interface;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LastBastion.View
{
    public class RangedWeaponSystem : MonoBehaviour
    {
        [SerializeField] private Arrow _arrow;
        [SerializeField] private float _reloadDelay;

        private Vector2 _arrowStartPosition;
        private CoroutineTimer _reloadTimer;

        public event Action<IDamageable> OnHitTarget;
        public event Action OnShooted;

        private void OnEnable()
        {
            _arrow.gameObject.SetActive(false);
            _reloadTimer = new CoroutineTimer(this, _reloadDelay);
            _arrowStartPosition = _arrow.transform.localPosition;

            _arrow.OnReleased += OnRelease;
            _arrow.OnHitTarget += OnHandleHitOnTarget;
        }

        private void OnDisable()
        {
            _arrow.OnReleased -= OnRelease;
            _arrow.OnHitTarget -= OnHandleHitOnTarget;
        }

        public void AttackTarget(Transform target)
        {
            if (_reloadTimer.IsTimeUp == false)
                return;
            else if (target == null)
                throw new ArgumentNullException(nameof(target));

            if(_arrow.TryLaunch(target))
            {
                _reloadTimer.Run();
                OnShooted?.Invoke();
            }
        }

        private void OnRelease(SpawnableObject arrow)
        {
            arrow.gameObject.SetActive(false);
            arrow.transform.localPosition = _arrowStartPosition;

            _reloadTimer.Run();
        }

        private void OnHandleHitOnTarget(IDamageable target) =>
            OnHitTarget?.Invoke(target);
    }
}
