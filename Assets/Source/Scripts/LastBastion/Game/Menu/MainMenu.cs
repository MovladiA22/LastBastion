using Common.Audio;
using UnityEngine;
using Common.UI;

namespace LastBastion.Game.Menu
{
    internal class MainMenu : UIMenu
    {
        [SerializeField] private MusicRunner _menuBackground;

        public override void Init()
        {
            base.Init();

            _menuBackground.RunAudio();
        }
    }
}
