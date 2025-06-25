using Common.Audio;
using UnityEngine;

namespace LastBastion.Game
{
    internal class GameRunnerView : UIMenu
    {
        [SerializeField] private MusicRunner _menuBackground;

        public override void Init()
        {
            base.Init();

            _menuBackground.RunAudio();
        }
    }
}
