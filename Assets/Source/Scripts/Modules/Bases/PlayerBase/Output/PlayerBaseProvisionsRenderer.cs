using Common.Interfaces;
using Common.UI.View;
using UnityEngine;

namespace LastBastion.Bases
{
    public class PlayerBaseProvisionsRenderer : VariableIntTextRenderer, IInitializable
    {
        [SerializeField] private PlayerBase _playerBase;

        public void Init()
        {
            SetVariable(_playerBase.Provisions);
        }
    }
}
