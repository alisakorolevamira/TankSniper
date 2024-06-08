using Sources.Scripts.Presentations.Views;
using Sources.Scripts.UIFramework.Presentations.AudioSources.Types;
using Sources.Scripts.UIFramework.PresentationsInterfaces.AudioSources;
using UnityEngine;

namespace Sources.Scripts.UIFramework.Presentations.AudioSources
{
    public class UIAudioSource : View, IUIAudioSource
    {
        [SerializeField] private AudioSourceId _audioSourceId;

        private AudioSource _audioSource;

        public AudioSourceId AudioSourceId => _audioSourceId;

        private void Awake() =>
            _audioSource = GetComponent<AudioSource>();

        public void Play() =>
            _audioSource.Play();

        public void SetVolume(int volume) =>
            _audioSource.volume = volume;
    }
}