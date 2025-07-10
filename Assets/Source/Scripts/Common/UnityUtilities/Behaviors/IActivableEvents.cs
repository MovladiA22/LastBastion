using System;

namespace Common.UnityUtilities.Behaviors
{
    public interface IActivableEvents
    {
        event Action OnActivated;
        event Action OnDeactivated;
        
        void InvokeActivateEvent();
        void InvokeDeactivateEvent();
    }
}
