using Doozy.Runtime.UIManager;
using Doozy.Runtime.UIManager.Components;
using Sources.Scripts.Controllers.Presenters.Shop;
using Sources.Scripts.Presentations.Views.Players.Skins.DecalsType;
using Sources.Scripts.PresentationsInterfaces.Views.Shop;
using Sources.Scripts.UIFramework.Presentations.Images;
using Sources.Scripts.UIFramework.Presentations.Texts;
using UnityEngine;

namespace Sources.Scripts.Presentations.Views.Shop
{
    public class ShopDecalButtonView : PresentableView<ShopDecalButtonPresenter>, IShopDecalButtonView
    {
        [SerializeField] private UIButton _button;
        [SerializeField] private UIText _price;
        [SerializeField] private UIText _freeText;
        [SerializeField] private ImageView _moneyIcon;
        [SerializeField] private ImageView _adImage;
        [SerializeField] private UIButton _buyButton;
        [SerializeField] private DecalType _decal;

        public UIButton Button => _button;
        public UIText PriceText => _price;
        public UIText FreeText => _freeText;
        public ImageView MoneyIcon => _moneyIcon;
        public ImageView AdImage => _adImage;
        public UIButton BuyButton => _buyButton;
        public DecalType DecalType => _decal;
        public bool IsBought { get; private set; }
        
        public void Hide()
        {
            _button.enabled = false;
            _button.SetState(UISelectionState.Disabled);
            _buyButton.enabled = true;
            _buyButton.SetState(UISelectionState.Normal);
        }

        public void Show()
        {
            _button.enabled = true;
            _button.SetState(UISelectionState.Normal);
            _buyButton.enabled = false;
            _buyButton.SetState(UISelectionState.Disabled);
            IsBought = true;
        }
    }
}