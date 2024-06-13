using Sources.Scripts.PresentationsInterfaces.UI.Images;
using Sources.Scripts.UIFramework.PresentationsInterfaces;

namespace Sources.Scripts.PresentationsInterfaces.Views.Bullets
{
    public interface IBulletUIView : IView
    {
        IImageView Icon { get; }
        bool IsShowed { get; }
    }
}