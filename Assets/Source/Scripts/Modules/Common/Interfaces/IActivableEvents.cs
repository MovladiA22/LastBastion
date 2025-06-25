using System;

namespace Common.Interfaces
{
    public interface IActivableEvents
    {
        event Action OnActivated;
        event Action OnDeactivated;
        
        void InvokeActivateEvent();
        void InvokeDeactivateEvent();
    }
}
