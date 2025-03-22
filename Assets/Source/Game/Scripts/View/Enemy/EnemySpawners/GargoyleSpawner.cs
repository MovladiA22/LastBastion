using LastBastion.View.Interface;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LastBastion.View
{
    public class GargoyleSpawner : UnitSpawner
    {
        [SerializeField] private Gargoyle _prefab;

        public override SpawnableObject CreateObj()
        {
            Gargoyle gargoyle = Instantiate(_prefab, SpawnPosition, Quaternion.identity);

            return gargoyle;
        }
    }
}
