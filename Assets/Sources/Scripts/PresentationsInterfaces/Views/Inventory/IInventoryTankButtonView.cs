using Doozy.Runtime.UIManager.Components;
using Sources.Scripts.UIFramework.Presentations.Images;
using Sources.Scripts.UIFramework.Presentations.Texts;

namespace Sources.Scripts.PresentationsInterfaces.Views.Inventory
{
    public interface IInventoryTankButtonView
    {
        public UIButton Button { get; }
        public UIText PriceText { get; }
        public UIText FreeText { get; }
        public ImageView MoneyIcon { get; }
        public ImageView AdImage { get; }
    }
}