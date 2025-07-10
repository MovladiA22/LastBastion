using Common.UI.Output;
using UnityEngine.UI;
using UnityEngine;

namespace LastBastion.Game.View
{
    internal class CurrentLevelRenderer : TextRenderer
    {
        private const int LevelIndexlOffset = 1;

        [SerializeField] private LevelLauncher _levelLauncher;
        [SerializeField] private Sprite[] _levelSprites;
        [SerializeField] private Image _image;

        public void RenderLevel()
        {
            Render(_levelLauncher.CurrentLevel.ToString());

            for (int i = 0; i < _levelSprites.Length; i++)
            {
                if (i + LevelIndexlOffset == _levelLauncher.CurrentLevel)
                    _image.sprite = _levelSprites[i];
            }
        }
    }
}
