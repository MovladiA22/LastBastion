using LastBastion.View.Interface;
using UnityEngine;

namespace LastBastion.View
{
    internal class SerfSoldierSpawner : UnitSpawner
    {
        [SerializeField] private SerfSoldier _prefab;

        public override SpawnableObject CreateObj()
        {
            SerfSoldier serfSoldier = Instantiate(_prefab, SpawnPosition, Quaternion.identity);

            return serfSoldier;
        }
    }
}
