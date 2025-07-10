using Common.UI.Output;
using UnityEngine;

namespace LastBastion.BlessingSystem.View
{
    public class BlessingsCountRenderer : VariableIntTextRenderer
    {
        [SerializeField] private BlessingActivator _blessingActivator;

        public void Init() =>
            SetVariable(_blessingActivator.Level);

        public override void Render(string text)
        {
            text += "/" + _blessingActivator.Level.MaxValue;

            base.Render(text);
        }
    }
}
