using Common.UI.Output;

namespace LastBastion.UpgradeSystem.View
{
    internal class UpgradedLevelRenderer : VariableIntTextRenderer
    {
        const string LevelUpgradedText = "Уровень: ";

        public override void Render(string text)
        {
            base.Render(LevelUpgradedText + text);
        }
    }
}
