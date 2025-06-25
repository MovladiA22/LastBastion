using Common.Interfaces;
using Common.UI.View;
using UnityEngine;

namespace LastBastion.Bases
{
    public class DefensiveWeaponsCountRenderer : VariableIntTextRenderer, IInitializable
    {
        [SerializeField] private DefensiveSystem _defensiveSystem;

        public void Init()
        {
            SetVariable(_defensiveSystem.Level);
        }

        public override void Render(string text)
        {
            text += "/" + _defensiveSystem.Level.MaxValue;

            base.Render(text);
        }
    }
}
