using LastBastion.Units;

namespace LastBastion.UnitSpawners
{
    public class ArcherSpawner : GenericPlayerUnitSpawner<Archer>
    {
        public override bool IsIgnoreTriggerdOpponents => true;
    }
}
