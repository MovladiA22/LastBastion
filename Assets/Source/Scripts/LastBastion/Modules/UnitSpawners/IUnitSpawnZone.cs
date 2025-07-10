using LastBastion.Units;
using System;

namespace LastBastion.UnitSpawners
{
    public interface IUnitSpawnZone
    {
        event Action OnEntered;
        event Action OnExited;

        bool IsFree { get; }

        void SetUnit(Unit unit);
    }
}
