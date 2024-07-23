using Sources.Scripts.ControllersInterfaces.ControllerLifetimes;

namespace Sources.Scripts.UIFramework.ServicesInterfaces.AudioSources
{
    public interface IAudioService : IEnterable, IExitable
    {
        void Play();
    }
}