using Doozy.Runtime.UIManager.Components;
using Sources.Scripts.Presentations.Views.Players.Skins.MaterialTypes;
using Sources.Scripts.UIFramework.Presentations.Images;
using Sources.Scripts.UIFramework.Presentations.Texts;

namespace Sources.Scripts.PresentationsInterfaces.Views.Shops
{
    public interface IShopPatternButtonView
    {
        public UIButton Button { get; }
        public UIButton BuyButton { get; }
        public UIText PriceText { get; }
        public UIText FreeText { get; }
        public ImageView MoneyIcon { get; }
        public ImageView AdImage { get; }
        public MaterialType MaterialType { get; }
        public bool IsBought { get; }

        void Show();
        void Hide();
    }
}