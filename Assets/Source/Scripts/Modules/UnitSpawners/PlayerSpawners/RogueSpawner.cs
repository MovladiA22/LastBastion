using LastBastion.Units;

namespace LastBastion.UnitSpawners
{
    public class RogueSpawner : GenericPlayerUnitSpawner<Rogue>
    {
        public override bool IsIgnoreTriggerdOpponents => true;
    }
}
