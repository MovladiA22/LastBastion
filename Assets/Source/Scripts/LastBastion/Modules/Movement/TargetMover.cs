using UnityEngine;

namespace LastBastion.Movement
{
    public class TargetMover : MonoBehaviour
    {
        [SerializeField, Min(0.01f)] private float _speed;

        private MoveTowardsProcessor _moveTowardsProcessor;

        private void Awake()
        {
            _moveTowardsProcessor = new MoveTowardsProcessor(_speed);
        }

        public void UpdatePositon(Vector2 targetPosition) =>
            transform.position = _moveTowardsProcessor.GetNextPositionAlongX(targetPosition, transform.position);
    }
}
