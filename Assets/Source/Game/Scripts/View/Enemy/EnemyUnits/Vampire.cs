using LastBastion.View.Interface;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LastBastion.View
{
    public class Vampire : Unit, IEnemy
    {
        private bool _isReachedTarget = false;

        protected override void OnDisable()
        {
            base.OnDisable();

            _isReachedTarget = false;
        }

        public override void TryMove()
        {
            if (_isReachedTarget == false)
                OnHandleUnitCollision(false);

                base.TryMove();
        }

        protected override void Attack(IDamageable opponent)
        {
            if (_isReachedTarget)
                base.Attack(opponent);
        }

        protected override void OnHandleTargetReached()
        {
            _isReachedTarget = true;

            base.OnHandleTargetReached();
        }
    }
}
