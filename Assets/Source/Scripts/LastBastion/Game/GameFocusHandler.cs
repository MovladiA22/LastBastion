using LastBastion.Game.UI;
using UnityEngine.Audio;
using UnityEngine;

namespace LastBastion.Game
{
    internal class GameFocusHandler : MonoBehaviour
    {
        [SerializeField] private AudioMixerGroup _masterMixer;
        [SerializeField] private LevelLauncher _levelLauncher;
        [SerializeField] private PausePanel _pausePanel;

        private float _mixerDefaultVolume;

        private void OnApplicationFocus(bool hasFocus)
        {
            if (hasFocus == false)
            {
                ToggleMute(true);

                if (_levelLauncher.IsLevelActivate && _pausePanel.IsPaused == false)
                    _pausePanel.ClickOnButton();
            }
            else
            {
                ToggleMute(false);
            }
        }

        private void ToggleMute(bool isEnabled)
        {
            float _muteValue = -80f;

            if (isEnabled)
            {
                if (_masterMixer.audioMixer.GetFloat(_masterMixer.name, out float value))
                    _mixerDefaultVolume = value;

                _masterMixer.audioMixer.SetFloat(_masterMixer.name, _muteValue);
            }
            else
            {
                _masterMixer.audioMixer.SetFloat(_masterMixer.name, _mixerDefaultVolume);
            }
        }
    }
}
