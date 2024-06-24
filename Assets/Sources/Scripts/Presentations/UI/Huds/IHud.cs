using System.Collections.Generic;
using Sources.Scripts.UIFramework.PresentationsInterfaces.AudioSources;

namespace Sources.Scripts.Presentations.UI.Huds
{
    public interface IHud
    {
        IReadOnlyList<IUIAudioSource> UIAudioSources { get; }
    }
}