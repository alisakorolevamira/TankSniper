using Doozy.Runtime.UIManager.Components;
using Sources.Scripts.Presentations.Views.Players.Skins.DecalsType;
using Sources.Scripts.UIFramework.Presentations.Images;
using Sources.Scripts.UIFramework.Presentations.Texts;
using UnityEngine;

namespace Sources.Scripts.PresentationsInterfaces.Views.Shop
{
    public interface IShopDecalButtonView
    {
        public UIButton Button { get; }
        public UIButton BuyButton { get; }
        public UIText PriceText { get; }
        public UIText FreeText { get; }
        public ImageView MoneyIcon { get; }
        public ImageView AdImage { get; }
        public DecalType DecalType { get; }
        public bool IsBought { get; }

        void Show();
        void Hide();
    }
}