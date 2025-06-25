using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LastBastion.CombatSystem
{
    public interface IKeeperOpponents
    {
        IDamageable GetFirstOpponent();
        IReadOnlyList<IDamageable> GetAllOpponents();
    }
}
