using Doozy.Runtime.UIManager;

namespace Sources.Scripts.PresentationsInterfaces.Views.Shop
{
    public interface IShopButtonView
    {
        int Level { get; }
        void Show();
        void Hide();
    }
}