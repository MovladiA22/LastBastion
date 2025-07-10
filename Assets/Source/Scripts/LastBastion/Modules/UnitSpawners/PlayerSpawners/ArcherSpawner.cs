using LastBastion.Units.PlayerUnits;

namespace LastBastion.UnitSpawners.PlayerSpawners
{
    internal class ArcherSpawner : GenericPlayerUnitSpawner<Archer>
    {
        public override bool IsIgnoreTriggerdOpponents => true;
    }
}
