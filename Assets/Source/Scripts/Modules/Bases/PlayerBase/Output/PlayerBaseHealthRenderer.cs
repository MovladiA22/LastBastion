using Common.UI.View;
using UnityEngine;

namespace LastBastion.Bases
{
    public class PlayerBaseHealthRenderer : VariableIntTextRenderer
    {
        [SerializeField] private PlayerBase _playerBase;

        public void Init()
        {
            SetVariable(_playerBase.IHealth);
        }
    }
}
