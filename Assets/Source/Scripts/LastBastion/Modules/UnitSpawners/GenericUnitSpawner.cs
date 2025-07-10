using LastBastion.UnityUtilities.Spawning;
using LastBastion.Units;
using UnityEngine;

namespace LastBastion.UnitSpawners
{
    public class GenericUnitSpawner<SpawnableUnit> : UnitSpawner where SpawnableUnit : Unit
    {
        [SerializeField] private SpawnableUnit _prefab;

        protected override void Awake()
        {
            base.Awake();

            SpawnZone.SetUnit(_prefab);
        }

        public override SpawnableObject CreateObj() =>
            Instantiate(_prefab, SpawnPosition, Quaternion.identity);
    }
}
