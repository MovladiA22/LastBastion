using LastBastion.View.Interface;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LastBastion.View
{
    public class ZombieSpawner : UnitSpawner
    {
        [SerializeField] private Zombie _prefab;

        public override SpawnableObject CreateObj()
        {
            Zombie zombie = Instantiate(_prefab, SpawnPosition, Quaternion.identity);

            return zombie;
        }
    }
}
