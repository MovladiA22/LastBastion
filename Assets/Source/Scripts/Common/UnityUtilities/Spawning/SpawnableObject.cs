using System;
using UnityEngine;

namespace LastBastion.UnityUtilities.Spawning
{
    public abstract class SpawnableObject : MonoBehaviour
    {
        public event Action<SpawnableObject> OnReleased;

        public virtual void InvokeReleaseEvent()
        {
            OnReleased?.Invoke(this);
        }
    }
}
