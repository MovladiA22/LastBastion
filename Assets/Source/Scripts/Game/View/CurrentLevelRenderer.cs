using Common.Interfaces;
using Common.UI.View;
using UnityEngine.UI;
using UnityEngine;

namespace LastBastion.Game
{
    internal class CurrentLevelRenderer : TextRenderer, IInitializable
    {
        private const int LevelIndexlOffset = 1;

        [SerializeField] private LevelLauncher _levelLauncher;
        [SerializeField] private Image _image;
        [SerializeField] private Sprite _firstLevelSprite;
        [SerializeField] private Sprite _secondLevelSprite;
        [SerializeField] private Sprite _thirdLevelSprite;

        private Sprite[] sprites;

        public void Init()
        {
            sprites = new Sprite[] { _firstLevelSprite, _secondLevelSprite, _thirdLevelSprite };
        }

        public void RenderLevel()
        {
            Render(_levelLauncher.CurrentLevel.ToString());

            for (int i = 0; i < sprites.Length; i++)
            {
                if (i + LevelIndexlOffset == _levelLauncher.CurrentLevel)
                    _image.sprite = sprites[i];
            }
        }
    }
}
