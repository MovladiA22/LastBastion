using LastBastion.View.Interface;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LastBastion.View
{
    public class VampireSpawner : UnitSpawner
    {
        [SerializeField] private Vampire _prefab;

        public override SpawnableObject CreateObj()
        {
            Vampire vampire = Instantiate(_prefab, SpawnPosition, Quaternion.identity);

            return vampire;
        }
    }
}
