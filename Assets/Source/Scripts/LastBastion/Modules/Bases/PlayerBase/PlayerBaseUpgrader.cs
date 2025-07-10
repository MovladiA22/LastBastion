using LastBastion.UpgradeSystem.View;
using UnityEngine;

namespace LastBastion.Bases.PlayerBase
{
    public class PlayerBaseUpgrader : UpgradeButtonsView
    {
        [SerializeField] private PlayerBase _playerBase;

        public override void Init()
        {
            foreach(var upgrader in _playerBase.GetUpgraders())
                AddUpgrader(upgrader);

            base.Init();
        }
    }
}
