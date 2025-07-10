using Common.UnityUtilities.Behaviors;
using Common.UI.Output;
using UnityEngine;

namespace LastBastion.Bases.PlayerBase.Output
{
    public class PlayerUnitsCountRenderer : VariableIntTextRenderer, IInitializable
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
