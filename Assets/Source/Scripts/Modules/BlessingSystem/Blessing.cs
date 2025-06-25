using Common.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LastBastion.BlessingSystem
{
    public abstract class Blessing : ManagedBehavior, IIndexable, ICostable, IInitializable, IAccessLevel
    {
        public event Action<ICostable> OnActivatedForPay;
        public event Action OnDeactivated;

        [field : SerializeField, Min(0)] public int Price { get; private set; }
        [field: SerializeField, Min(0)] public int AccessLevel { get; private set; }

        public int Index { get; private set; }

        public override void Activate()
        {
            base.Activate();

            OnActivatedForPay?.Invoke(this);
        }

        public override void Deactivate()
        {
            base.Deactivate();

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
