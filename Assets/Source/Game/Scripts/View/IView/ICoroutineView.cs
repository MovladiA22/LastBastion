using System;

namespace LastBastion.View.Interface
{
    public interface ICoroutineView
    {
        event Action OnStarted;
        event Action OnStopped;
    }
}
