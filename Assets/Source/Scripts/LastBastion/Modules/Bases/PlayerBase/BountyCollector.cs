using LastBastion.Units.EnemyUnits;
using Common.VariableSystem;
using LastBastion.Units;
using UnityEngine;
using System;

namespace LastBastion.Bases.PlayerBase
{
    internal class BountyCollector : MonoBehaviour
    {
        [SerializeField] private UnitСommander _enemyUnitCommandor;

        private VariableIntObject _money;

        private void OnEnable()
        {
            _enemyUnitCommandor.OnUnitRemoved += TransferBounty;
        }

        public void SetMoney(VariableIntObject money) =>
            _money = money ?? throw new ArgumentNullException(nameof(money));

        private void TransferBounty(Unit unit)
        {
            if (unit is EnemyUnit enemyUnit)
                _money.Increase(enemyUnit.BountyGold);
        }
    }
}
