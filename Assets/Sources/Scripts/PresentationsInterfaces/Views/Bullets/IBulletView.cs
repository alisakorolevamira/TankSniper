using Sources.Scripts.PresentationsInterfaces.UI.Images;

namespace Sources.Scripts.PresentationsInterfaces.Views.Bullets
{
    public interface IBulletView : IView
    {
        IImageView Icon { get; }
        bool IsShowed { get; }
    }
}