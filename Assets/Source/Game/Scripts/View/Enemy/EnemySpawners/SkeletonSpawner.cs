using LastBastion.View.Interface;
using UnityEngine;

namespace LastBastion.View
{
    internal class SkeletonSpawner : UnitSpawner
    {
        [SerializeField] private Skeleton _prefab;

        public override SpawnableObject CreateObj()
        {
            Skeleton skeleton = Instantiate(_prefab, SpawnPosition, Quaternion.identity);

            return skeleton;
        }
    }
}
