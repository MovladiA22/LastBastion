using Common.UI.View;
using UnityEngine;

namespace LastBastion.Bases
{
    public class BlessingsCountRenderer : VariableIntTextRenderer
    {
        [SerializeField] private Church _church;

        public void Init() =>
            SetVariable(_church.Level);

        public override void Render(string text)
        {
            text += "/" + _church.Level.MaxValue;

            base.Render(text);
        }
    }
}
