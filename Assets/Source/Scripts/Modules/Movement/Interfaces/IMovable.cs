using System;
using UnityEngine;

namespace LastBastion.Movement
{
    public interface IMovable
    {
        event Action<bool> OnIsMoved;

        void Move(Vector2 newPosition);
    }
}
