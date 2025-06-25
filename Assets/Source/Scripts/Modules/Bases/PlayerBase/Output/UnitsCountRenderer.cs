using Common.Interfaces;
using Common.UI.View;
using UnityEngine;

namespace LastBastion.Bases
{
    public class UnitsCountRenderer : VariableIntTextRenderer, IInitializable
    {
        [SerializeField] private PlayerGarrison _playerGarrison;

        public void Init()
        {
            SetVariable(_playerGarrison.Level);
        }

        public override void Render(string text)
        {
            text += "/" + _playerGarrison.Level.MaxValue;

            base.Render(text);
        }
    }
}
