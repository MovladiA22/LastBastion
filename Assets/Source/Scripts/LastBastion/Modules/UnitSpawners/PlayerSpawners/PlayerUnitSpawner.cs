using Common.UnityUtilities.Behaviors;
using Common.Interfaces;
using UnityEngine;
using System;

namespace LastBastion.UnitSpawners.PlayerSpawners
{
    public abstract class PlayerUnitSpawner : UnitSpawner, ICostable, IAccessLevel, IActivableEvents
    {
        [field: SerializeField, Min(0)] public int AccessLevel { get; private set; }
        [field: SerializeField, Min(0)] public int Price { get; private set; }

        public event Action OnActivated;
        public event Action OnDeactivated;

        public void InvokeActivateEvent() =>
            OnActivated?.Invoke();

        public void InvokeDeactivateEvent() =>
            OnDeactivated?.Invoke();
    }
}
