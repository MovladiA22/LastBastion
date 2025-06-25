using LastBastion.CombatSystem;
using LastBastion.Movement;
using UnityEngine;

namespace LastBastion.Units
{
    internal class UnitStopTrigger : MoveStopTrigger
    {
        private KeeperOfTriggerdOpponents _keeperOfTriggerdStoppers;

        private void Awake()
        {
            _keeperOfTriggerdStoppers = new KeeperOfTriggerdOpponents();
        }

        private void OnDisable()
        {
            _keeperOfTriggerdStoppers.RemoveAllOpponents();
        }

        protected override void HandleTriggerEnter(Collider2D collision)
        {
            if (IsNeedingStopper(collision))
            {
                UpdateKeeper(true, collision.GetComponent<IDamageable>());
                base.HandleTriggerEnter(collision);
            }
        }

        protected override void HandleTriggerExit(Collider2D collision)
        {
            if (IsNeedingStopper(collision))
            {
                UpdateKeeper(false, collision.GetComponent<IDamageable>());
                base.HandleTriggerExit(collision);
            }
        }

        protected virtual bool IsNeedingStopper(Collider2D collision) =>
            collision.TryGetComponent<Unit>(out _);

        protected override void InvokeStopEvent(bool isStoped)
        {
            if (isStoped == false && _keeperOfTriggerdStoppers.IsEmpty == false)
                return;

            base.InvokeStopEvent(isStoped);
        }

        private void UpdateKeeper(bool isEntered, IDamageable damageable)
        {
            if (isEntered)
            {
                _keeperOfTriggerdStoppers.AddOpponent(damageable);
                damageable.OnHealthIsOver += OnHandleUnitDeath;
            }
            else
            {
                _keeperOfTriggerdStoppers.RemoveOpponent(damageable);
                damageable.OnHealthIsOver -= OnHandleUnitDeath;
            }
        }

        private void OnHandleUnitDeath(IDamageable damageable)
        {
            UpdateKeeper(false, damageable);
            InvokeStopEvent(false);
        }
    }
}
