﻿using Doozy.Runtime.UIManager;
using Doozy.Runtime.UIManager.Components;
using Sources.Scripts.Controllers.Presenters.Shops;
using Sources.Scripts.Domain.Models.Shops;
using Sources.Scripts.Presentations.Views.Players.Skins.DecalsType;
using Sources.Scripts.PresentationsInterfaces.Views.Shops;
using Sources.Scripts.UIFramework.Presentations.Images;
using Sources.Scripts.UIFramework.Presentations.Texts;
using UnityEngine;

namespace Sources.Scripts.Presentations.Views.Shops
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
        
        private ShopDecalButton _shopDecalButton;

        public UIButton Button => _button;
        public UIText PriceText => _price;
        public UIText FreeText => _freeText;
        public ImageView MoneyIcon => _moneyIcon;
        public ImageView AdImage => _adImage;
        public UIButton BuyButton => _buyButton;
        public DecalType DecalType => _decal;
        public bool IsBought => _shopDecalButton.IsBought;
        
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
            _shopDecalButton.IsBought = true;
        }
        
        public void Construct(ShopDecalButton button) => 
            _shopDecalButton = button;
    }
}