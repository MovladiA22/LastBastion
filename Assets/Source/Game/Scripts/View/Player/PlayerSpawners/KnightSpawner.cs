using LastBastion.View.Interface;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LastBastion.View
{
    public class KnightSpawner : UnitSpawner
    {
        [SerializeField] private Knight _prefab;

        public override SpawnableObject CreateObj()
        {
            Knight knight = Instantiate(_prefab, SpawnPosition, Quaternion.identity);

            return knight;
        }
    }
}
