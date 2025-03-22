using LastBastion.View.Interface;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LastBastion.View
{
    public class ArcherSpawner : UnitSpawner
    {
        [SerializeField] private Archer _prefab;

        public override SpawnableObject CreateObj()
        {
            Archer archer = Instantiate(_prefab, SpawnPosition, Quaternion.identity);

            return archer;
        }
    }
}
