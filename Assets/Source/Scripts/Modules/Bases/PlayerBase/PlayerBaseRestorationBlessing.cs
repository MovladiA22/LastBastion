using LastBastion.BlessingSystem;
using UnityEngine;

namespace LastBastion.Bases
{
    internal class PlayerBaseRestorationBlessing : DivineRestoration
    {
        [SerializeField] private PlayerBase _playerBase;

        public override void Init()
        {
            base.Init();

            SetBlessable(_playerBase);
        }
    }
}
