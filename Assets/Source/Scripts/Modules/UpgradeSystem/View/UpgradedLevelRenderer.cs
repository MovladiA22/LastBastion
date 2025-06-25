using Common.UI.View;

namespace LastBastion.UpgradeSystem
{
    public class UpgradedLevelRenderer : VariableIntTextRenderer
    {
        const string LevelUpgradedText = "Уровень: ";

        public override void Render(string text)
        {
            base.Render(LevelUpgradedText + text);
        }
    }
}
