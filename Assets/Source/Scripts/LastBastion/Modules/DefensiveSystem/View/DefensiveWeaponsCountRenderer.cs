using Common.UnityUtilities.Behaviors;
using Common.UI.Output;
using UnityEngine;

namespace LastBastion.DefensiveSystem.View
{
    public class DefensiveWeaponsCountRenderer : VariableIntTextRenderer, IInitializable
    {
        [SerializeField] private DefensiveWeaponsSystem _defensiveSystem;

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
