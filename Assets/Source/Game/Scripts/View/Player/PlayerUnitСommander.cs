using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LastBastion.View
{
    public class PlayerUnitСommander : UnitСommander
    {
        [SerializeField] private Transform _target;

        protected override Transform Target => _target;
    }
}
