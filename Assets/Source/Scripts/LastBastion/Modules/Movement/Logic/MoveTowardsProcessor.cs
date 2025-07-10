using System;
using UnityEngine;

namespace LastBastion.Movement
{
    internal class MoveTowardsProcessor
    {
        private readonly float _step;

        public MoveTowardsProcessor(float step)
        {
            if (step <= 0)
                throw new ArgumentOutOfRangeException(nameof(step));

            _step = step;
        }

        public Vector2 GetNextPositionAlongX(Vector2 targetPosition, Vector2 currentPosition) =>
            GetNextPosition(new Vector2(targetPosition.x, currentPosition.y), currentPosition);

        private Vector2 GetNextPosition(Vector2 targetPosition, Vector2 currentPosition) =>
            Vector2.MoveTowards(currentPosition, targetPosition, _step * Time.deltaTime);
    }
}
