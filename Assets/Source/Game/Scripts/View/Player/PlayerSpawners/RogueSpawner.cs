using LastBastion.View.Interface;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LastBastion.View
{
    public class RogueSpawner : UnitSpawner
    {
        [SerializeField] private Rogue _prefab;

        public override SpawnableObject CreateObj()
        {
            Rogue rogue = Instantiate(_prefab, SpawnPosition, Quaternion.identity);

            return rogue;
        }
    }
}
