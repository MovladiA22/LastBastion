using LastBastion.Units;

namespace LastBastion.Bases
{
    public class EnemyGarrison : BaseGarrison
    {
        private int _currentSpawnerIndex;
        private int _firstSpawnerUsageCount;

        public override void Activate()
        {
            base.Activate();

            foreach (var spawner in UnitSpawners)
                spawner.OnSpawned += SwitchSpawner;

            _currentSpawnerIndex = 0;
            _firstSpawnerUsageCount = 0;

            SwitchSpawner(default);
        }

        public override void Deactivate()
        {
            base.Deactivate();

            foreach (var spawner in UnitSpawners)
                spawner.OnSpawned -= SwitchSpawner;
        }

        public override void Work()
        {
            base.Work();

            SpawningUnits();
        }

        protected override void OnHandleUnitRemove(Unit unit) =>
            SpawningUnits();

        private void SpawningUnits()
        {
            SpawnUnit(UnitSpawners[_currentSpawnerIndex].Index);
        }

        private void SwitchSpawner(Unit unit)
        {
            if (_currentSpawnerIndex == 0 && _firstSpawnerUsageCount == 0)
            {
                _firstSpawnerUsageCount++;
            }
            else
            {
                _currentSpawnerIndex++;
                _firstSpawnerUsageCount = 0;
            }

            if (_currentSpawnerIndex >= UnitSpawners.Count)
                _currentSpawnerIndex = 0;
        }
    }
}
