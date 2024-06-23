using Sources.Scripts.Presentations.Views.Common;
using Sources.Scripts.Presentations.Views.Players;

namespace Sources.Scripts.PresentationsInterfaces.Views.Players
{
    public interface IPlayerView : IView
    {
        CharacterHealthView PlayerHealthView { get; }
        PlayerAttackerView PlayerAttackerView { get; }
    }
}