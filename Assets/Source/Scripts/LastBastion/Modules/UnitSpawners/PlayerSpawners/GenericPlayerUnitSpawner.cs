using LastBastion.UnityUtilities.Spawning;
using LastBastion.Units.PlayerUnits;
using UnityEngine;

namespace LastBastion.UnitSpawners.PlayerSpawners
{
    internal class GenericPlayerUnitSpawner<SpawnablePlayerUnit> : PlayerUnitSpawner where SpawnablePlayerUnit : PlayerUnit
    {
        [SerializeField] private SpawnablePlayerUnit _prefab;

        protected override void Awake()
        {
            base.Awake();

            SpawnZone.SetUnit(_prefab);
        }

        public override SpawnableObject CreateObj() =>
            Instantiate(_prefab, SpawnPosition, Quaternion.identity);
    }
}
