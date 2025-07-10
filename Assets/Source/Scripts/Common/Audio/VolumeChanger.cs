using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine;

namespace Common.Audio
{
    internal class VolumeChanger : MonoBehaviour
    {
        [SerializeField] private AudioMixerGroup _mixer;
        [SerializeField] private Slider _volumeSlider;
        [SerializeField] private Toggle _muteToggle;
        [SerializeField] private AudioSource _clickSound;

        private void OnEnable()
        {
            _volumeSlider.onValueChanged.AddListener(ChangeVolume);
            _muteToggle.onValueChanged.AddListener(ToggleMute);
        }

        private void Start()
        {
            _volumeSlider.value = _volumeSlider.maxValue;
        }

        private void OnDisable()
        {
            _volumeSlider.onValueChanged.RemoveListener(ChangeVolume);
            _muteToggle.onValueChanged.RemoveListener(ToggleMute);
        }

        private void ToggleMute(bool isEnabled)
        {
            _clickSound.Play();

            if (isEnabled)
                _volumeSlider.value = _volumeSlider.minValue;
            else
                _volumeSlider.value = _volumeSlider.maxValue;
        }

        private void ChangeVolume(float volume)
        {
            float _multiplier = 20f;

            if (volume == _volumeSlider.minValue && _muteToggle.isOn == false)
                _muteToggle.isOn = true;
            else if (volume > _volumeSlider.minValue && _muteToggle.isOn)
                _muteToggle.isOn = false;

            if (_mixer.audioMixer.GetFloat(_mixer.name, out float value))
            {
                if (value == _volumeSlider.minValue)
                    volume = -80f;
                else
                    volume = Mathf.Log10(volume) * _multiplier;

                _mixer.audioMixer.SetFloat(_mixer.name, volume);
            }
        }
    }
}
