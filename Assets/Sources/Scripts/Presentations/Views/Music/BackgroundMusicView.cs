using Sources.Scripts.Controllers.Presenters.Music;
using Sources.Scripts.PresentationsInterfaces.Views.Music;
using UnityEngine;

namespace Sources.Scripts.Presentations.Views.Music
{
    public class BackgroundMusicView : PresentableView<BackgroundMusicPresenter>, IBackgroundMusicView
    {
        [SerializeField] private AudioSourceView _backgroundAudioSourceView;

        public IAudioSourceView BackgroundMusicAudioSource => _backgroundAudioSourceView;
    }
}