using Sources.Scripts.PresentationsInterfaces.UI.Images;

namespace Sources.Scripts.PresentationsInterfaces.Views.Lightnings
{
    public interface ILightningView : IView
    {
        IImageView Icon { get; }
        bool IsShowed { get; }
    }
}