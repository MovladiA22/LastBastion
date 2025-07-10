using UnityEngine;

namespace Common.UnityUtilities.Behaviors
{
    public abstract class ManagedBehavior : MonoBehaviour, IActivable, IInitializable
    {
        public bool IsActivated { get; private set; }

        public abstract void Init();

        public virtual void Activate()
        {
            if (IsActivated)
                return;

            IsActivated = true;
        }

        public virtual void Deactivate()
        {
            if (IsActivated == false)
                return;

            IsActivated = false;
        }
    }
}
