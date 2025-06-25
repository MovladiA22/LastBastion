using LastBastion.Spawning;
using LastBastion.Units;
using UnityEngine;

namespace LastBastion.UnitSpawners
{
    public class GenericPlayerUnitSpawner<SpawnablePlayerUnit> : PlayerUnitSpawner where SpawnablePlayerUnit : PlayerUnit
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
