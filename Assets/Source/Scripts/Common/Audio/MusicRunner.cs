using UnityEngine;

namespace Common.Audio
{
    public class MusicRunner : MonoBehaviour
    {
        [SerializeField] private AudioSource _audioSource;

        private bool _isPlaying = false;

        public void RunAudio()
        {
            if (_isPlaying)
                return;

            _audioSource.Play();
            _isPlaying = true;
        }

        public void StopAudio()
        {
            if (_isPlaying == false)
                return;

            _audioSource.Stop();
            _isPlaying = false;
        }
    }
}
