using LastBastion.Units;

namespace LastBastion.UnitSpawners
{
    public class GargoyleSpawner : GenericUnitSpawner<Gargoyle>
    {
        public override bool IsIgnoreTriggerdOpponents => true;
    }
}
