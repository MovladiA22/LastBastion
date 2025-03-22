using LastBastion.View.Interface;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LastBastion.View
{
    internal class EnemyBase : Base, IEnemy
    {
        [field: SerializeField] public float SpawnDelay {  get; private set; }

        public void Spawn()
        {
            SpawnUnit(Random.Range(0, SpawnerCount));
        }
    }
}
