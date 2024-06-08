using Sources.Scripts.UIFramework.Presentations.AudioSources.Types;

namespace Sources.Scripts.UIFramework.PresentationsInterfaces.AudioSources
{
    public interface IUIAudioSource
    {
        AudioSourceId AudioSourceId { get; }

        void Play();

        void SetVolume(int volume);
    }
}