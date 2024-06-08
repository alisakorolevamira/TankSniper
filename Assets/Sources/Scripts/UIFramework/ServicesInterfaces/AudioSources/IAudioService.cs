using Sources.Scripts.ControllersInterfaces.ControllerLifetimes;
using Sources.Scripts.UIFramework.Presentations.AudioSources.Types;

namespace Sources.Scripts.UIFramework.ServicesInterfaces.AudioSources
{
    public interface IAudioService : IEnterable, IExitable
    {
        void Play(AudioSourceId id);
    }
}