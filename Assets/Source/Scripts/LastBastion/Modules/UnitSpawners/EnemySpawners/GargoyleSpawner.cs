using LastBastion.Units.EnemyUnits;

namespace LastBastion.UnitSpawners.EnemySpawners
{
    internal class GargoyleSpawner : GenericUnitSpawner<Gargoyle>
    {
        public override bool IsIgnoreTriggerdOpponents => true;
    }
}
