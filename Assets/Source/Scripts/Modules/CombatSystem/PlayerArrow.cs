using UnityEngine;

namespace LastBastion.CombatSystem
{
    public class PlayerArrow : PlayerProjectile
    {
        private Quaternion _startRotation;

        protected override void Awake()
        {
            base.Awake();

            _startRotation = transform.rotation;
        }

        public override void InvokeReleaseEvent()
        {
            transform.rotation = _startRotation;

            base.InvokeReleaseEvent();
        }

        protected override void ShootAtTarget(Vector2 vectorToTarget)
        {
            base.ShootAtTarget(vectorToTarget);

            transform.right = vectorToTarget.normalized;
            transform.rotation *= _startRotation;
        }
    }
}
