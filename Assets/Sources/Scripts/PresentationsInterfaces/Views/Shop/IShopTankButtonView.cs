using Doozy.Runtime.UIManager;

namespace Sources.Scripts.PresentationsInterfaces.Views.Shop
{
    public interface IShopTankButtonView
    {
        int Level { get; }
        void Show();
        void Hide();
    }
}