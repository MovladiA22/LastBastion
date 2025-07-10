using LastBastion.Units.PlayerUnits;

namespace LastBastion.UnitSpawners.PlayerSpawners
{
    internal class RogueSpawner : GenericPlayerUnitSpawner<Rogue>
    {
        public override bool IsIgnoreTriggerdOpponents => true;
    }
}
