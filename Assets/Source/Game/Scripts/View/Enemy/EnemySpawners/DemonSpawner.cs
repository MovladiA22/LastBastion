using LastBastion.View.Interface;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LastBastion.View
{
    public class DemonSpawner : UnitSpawner
    {
        [SerializeField] private Demon _prefab;

        public override SpawnableObject CreateObj()
        {
            Demon demon = Instantiate(_prefab, SpawnPosition, Quaternion.identity);

            return demon;
        }
    }
}
