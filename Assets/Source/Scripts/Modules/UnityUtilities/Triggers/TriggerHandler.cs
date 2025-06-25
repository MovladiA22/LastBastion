using UnityEngine;

namespace UnityUtilities.Triggers
{
    [RequireComponent(typeof(Collider2D))]
    public abstract class TriggerHandler : MonoBehaviour
    {
        [SerializeField] private Collider2D _ignoreCollider;

        private Collider2D _triggerCollider;

        private void OnEnable()
        {
            if (_triggerCollider == null)
                _triggerCollider = GetComponent<Collider2D>();

            HandleExistingColliders();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision != _ignoreCollider)
                HandleTriggerEnter(collision);
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            HandleTriggerExit(collision);
        }

        private void HandleExistingColliders()
        {
            Collider2D[] colliders = Physics2D.OverlapAreaAll(_triggerCollider.bounds.min, _triggerCollider.bounds.max);

            foreach (Collider2D collider in colliders)
            {
                if (collider != _triggerCollider && collider != _ignoreCollider)
                    HandleTriggerEnter(collider);
            }
        }

        protected abstract void HandleTriggerEnter(Collider2D collision);
        protected abstract void HandleTriggerExit(Collider2D collision);
    }
}
