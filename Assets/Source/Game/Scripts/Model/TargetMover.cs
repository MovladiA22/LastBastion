using System;
using UnityEngine;

namespace LastBastion.Model
{
    public class TargetMover
    {
        private readonly float _speed;
        private readonly float _sqrStoppingDistance;

        public TargetMover(float speed, float stoppingDistance)
        {
            if (speed <= 0)
                throw new ArgumentOutOfRangeException(nameof(speed));

            _speed = speed;
            _sqrStoppingDistance = stoppingDistance * stoppingDistance;
        }

        public Vector2 MoveToTarget(Vector2 targetPosition, Vector2 currentPosition) =>
            Vector2.MoveTowards(currentPosition, targetPosition, _speed * Time.deltaTime);

        public bool IsReachedTarget(Vector2 targetPosition, Vector2 currentPosition) =>
            (targetPosition - currentPosition).sqrMagnitude <= _sqrStoppingDistance;
    }
}
