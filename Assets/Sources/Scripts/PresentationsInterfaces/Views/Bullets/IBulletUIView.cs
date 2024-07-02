using Sources.Scripts.UIFramework.PresentationsInterfaces;
using Sources.Scripts.UIFramework.PresentationsInterfaces.Images;

namespace Sources.Scripts.PresentationsInterfaces.Views.Bullets
{
    public interface IBulletUIView : IView
    {
        IImageView Icon { get; }
        bool IsShowed { get; }
    }
}