using Sources.Scripts.UIFramework.PresentationsInterfaces.AudioSources;

namespace Sources.Scripts.Presentations.UI.Huds
{
    public interface IHud
    {
        IUIAudioSource UIAudioSource { get; }
    }
}