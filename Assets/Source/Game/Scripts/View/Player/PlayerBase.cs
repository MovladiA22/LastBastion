using LastBastion.View.Interface;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LastBastion.View
{
    internal class PlayerBase : Base, IPlayer
    {
        [SerializeField] private DefensiveWeaponActivator _defensiveWeaponActivator;

        private void Start()
        {
            _defensiveWeaponActivator.Activate(2222);
        }

        protected override bool IsSpawnNeeded(int spawnerIndex)
        {
            int rogueSpawnerIndex = 3;

            return spawnerIndex == rogueSpawnerIndex;
        }
    }
}
