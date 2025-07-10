using Common.UnityUtilities.Behaviors;
using Common.Interfaces;
using UnityEngine;
using System;

namespace LastBastion.BlessingSystem
{
    public abstract class Blessing : MonoBehaviour, IActivable, IIndexable, ICostable, IAccessLevel
    {
        public event Action<ICostable> OnActivatedForPay;
        public event Action OnDeactivated;

        [field : SerializeField, Min(0)] public int Price { get; private set; }
        [field: SerializeField, Min(0)] public int AccessLevel { get; private set; }

        public bool IsActivated { get; private set; }
        public int Index { get; private set; }

        public virtual void Activate()
        {
            if (IsActivated)
                return;

            IsActivated = true;

            OnActivatedForPay?.Invoke(this);
        }

        public virtual void Deactivate()
        {
            if (IsActivated == false)
                return;

            IsActivated = false;

            OnDeactivated?.Invoke();
        }

        public void SetIndex(int index)
        {
            if (index < 0)
                throw new ArgumentOutOfRangeException(nameof(index));

            Index = index;
        }
    }
}
