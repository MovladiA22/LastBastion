using System;
using UnityEngine;

namespace LastBastion.View.Interface
{
    public interface IMovable
    {
        event Action OnMoved;
        event Action OnReached;

        Vector2 CurrentPosition { get; }
        Vector2 TargetPosition { get; }

        void UpdatePosition(Vector2 newPosition);
        void InvokeReachedEvent();
    }
}
