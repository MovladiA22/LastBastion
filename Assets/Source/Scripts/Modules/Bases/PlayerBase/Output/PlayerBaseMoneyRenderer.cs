using Common.Interfaces;
using Common.UI.View;
using UnityEngine;

namespace LastBastion.Bases
{
    public class PlayerBaseMoneyRenderer : VariableIntTextRenderer, IInitializable
    {
        [SerializeField] private PlayerBase _playerBase;

        public void Init()
        {
            SetVariable(_playerBase.Money);
        }
    }
}
