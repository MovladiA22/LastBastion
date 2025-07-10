using System.Collections.Generic;
using LastBastion.Units;
using UnityEngine;
using System;

namespace LastBastion.UnitSpawners
{
    internal class UnitSpawnZone : MonoBehaviour, IUnitSpawnZone
    {
        private readonly Stack<Type> _unitTypes = new();
        private readonly List<Unit> _units = new();

        public event Action OnEntered;
        public event Action OnExited;

        public bool IsFree => _units.Count == 0;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out Unit unit))
            {
                if (TryGetUnit(unit))
                {
                    _units.Add(unit);
                    unit.OnDied += RemoveUnit;
                    OnEntered?.Invoke();
                }
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out Unit unit))
            {
                if (TryGetUnit(unit))
                {
                    _units.Remove(unit);
                    unit.OnDied -= RemoveUnit;

                    if (IsFree)
                        OnExited?.Invoke();
                }
            }
        }

        public void SetUnit(Unit unit)
        {
            if (unit == null)
                throw new ArgumentNullException(nameof(unit));

            _unitTypes.Push(unit.GetType());
        }

        private bool TryGetUnit(Unit unit)
        {
            if (_unitTypes == null || _unitTypes.Count == 0)
                throw new ArgumentNullException(nameof(_unitTypes));

            foreach (var unitType in _unitTypes)
            {
                if (unit.TryGetComponent(unitType, out _))
                    return true;
            }

            return false;
        }

        private void RemoveUnit(Unit unit) =>
            _units.Remove(unit);
    }
}