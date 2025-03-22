using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LastBastion.View
{
    public class UnitСommander : MonoBehaviour
    {
        [SerializeField] private CoroutineView _moveCoroutine;

        private List<Unit> _units = new();

        protected virtual Transform Target { get; }

        private void Awake()
        {
            _moveCoroutine.CreateCoroutine(SendUnitsToAttack());
        }

        public void OnAddUnit(Unit unit)
        {
            if (unit == null)
                throw new ArgumentNullException(nameof(unit));

            unit.OnDied += OnRemoveUnit;

            unit.TransferTarget(Target);
            _units.Add(unit);

            if (_units.Count == 1)
                _moveCoroutine.Run();
        }

        private void OnRemoveUnit(Unit unit)
        {
            if (unit == null)
                throw new ArgumentNullException(nameof(unit));

            unit.OnDied -= OnRemoveUnit;
            _units.Remove(unit);

            if (_units.Count == 0)
                _moveCoroutine.Cancel();
        }

        private IEnumerator SendUnitsToAttack()
        {
            while (_units.Count > 0)
            {
                foreach (var unit in _units)
                {
                    unit.TryMove();
                    unit.TryAttack();
                }

                yield return null;
            }
        }
    }
}
