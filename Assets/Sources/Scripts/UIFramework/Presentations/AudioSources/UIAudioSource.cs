using Sources.Scripts.Presentations.Views;
using Sources.Scripts.UIFramework.PresentationsInterfaces.AudioSources;
using UnityEngine;

namespace Sources.Scripts.UIFramework.Presentations.AudioSources
{
    public class UIAudioSource : View, IUIAudioSource
    {
        [SerializeField] private AudioSource _audioSource;

        public void Play() =>
            _audioSource.Play();

        public void SetVolume(int volume) =>
            _audioSource.volume = volume;
    }
}