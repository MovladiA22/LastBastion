using LastBastion.View.Interface;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LastBastion.View
{
    public class WearwolfSpawner : UnitSpawner
    {
        [SerializeField] private Wearwolf _prefab;

        public override SpawnableObject CreateObj()
        {
            Wearwolf wearwolf = Instantiate(_prefab, SpawnPosition, Quaternion.identity);

            return wearwolf;
        }
    }
}
