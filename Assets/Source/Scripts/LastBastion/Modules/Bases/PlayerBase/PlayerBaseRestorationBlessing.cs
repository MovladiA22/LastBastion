using LastBastion.BlessingSystem;
using LastBastion.BlessingSystem.Blessings;
using UnityEngine;

namespace LastBastion.Bases.PlayerBase
{
    internal class PlayerBaseRestorationBlessing : DivineRestoration
    {
        [SerializeField] private PlayerBase _playerBase;

        public override void Awake()
        {
            base.Awake();

            SetBlessable(_playerBase);
        }
    }
}
