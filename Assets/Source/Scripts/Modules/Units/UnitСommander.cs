using System;
using UnityEngine;
using System.Linq;
using System.Collections.Generic;

namespace LastBastion.Units
{
    public class UnitСommander : MonoBehaviour
    {
        [SerializeField] private Transform _target;

        private readonly List<Unit> _units = new();

        public event Action<Unit> OnUnitRemoved;

        public int NumberOfUnits => _units.Count;

        public void OnAddUnit(Unit unit)
        {
            if (unit == null)
                throw new ArgumentNullException(nameof(unit));

            unit.OnDied += OnRemoveUnit;
            _units.Add(unit);
        }

        public void SendUnitsToAttack()
        {
            if (_units.Count > 0)
            {
                foreach (Unit unit in _units)
                {
                    unit.Attack();
                    unit.Move(_target.position);
                }
            }
        }

        public void RecallUnits()
        {
            foreach (Unit unit in _units.ToList())
            {
                unit.HandleDeath();
            }
        }

        private void OnRemoveUnit(Unit unit)
        {
            if (unit == null)
                throw new ArgumentNullException(nameof(unit));

            unit.OnDied -= OnRemoveUnit;
            _units.Remove(unit);

            OnUnitRemoved?.Invoke(unit);
        }
    }
}
