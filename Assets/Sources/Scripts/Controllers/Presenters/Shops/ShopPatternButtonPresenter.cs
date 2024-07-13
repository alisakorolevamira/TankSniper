using System;
using Doozy.Runtime.UIManager;
using Sources.Scripts.Domain.Models.Constants;
using Sources.Scripts.Domain.Models.Players;
using Sources.Scripts.InfrastructureInterfaces.Services.LoadServices;
using Sources.Scripts.InfrastructureInterfaces.Services.Shop;
using Sources.Scripts.InfrastructureInterfaces.Services.Yandex;
using Sources.Scripts.PresentationsInterfaces.Views.Shops;

namespace Sources.Scripts.Controllers.Presenters.Shops
{
    public class ShopPatternButtonPresenter : PresenterBase
    {
        private readonly IShopPatternButtonView _view;
        private readonly IStickyAdService _stickyAdService;
        private readonly ISkinChangerService _skinChangerService;
        private readonly ILoadService _loadService;
        private readonly PlayerWallet _playerWallet;

        public ShopPatternButtonPresenter(
            IShopPatternButtonView view,
            IStickyAdService stickyAdService,
            ISkinChangerService skinChangerService,
            ILoadService loadService,
            PlayerWallet playerWallet)
        {
            _view = view ?? throw new ArgumentNullException(nameof(view));
            _stickyAdService = stickyAdService ?? throw new ArgumentNullException(nameof(stickyAdService));
            _skinChangerService = skinChangerService ?? throw new ArgumentNullException(nameof(skinChangerService));
            _loadService = loadService ?? throw new ArgumentNullException(nameof(loadService));
            _playerWallet = playerWallet ?? throw new ArgumentNullException(nameof(playerWallet));
        }

        public override void Enable()
        {
            _view.Button.onClickEvent.AddListener(SetMaterial);

            if (_view.IsBought)
            {
                _view.Show();
                return;
            }

            _view.Hide();
            SetPriceText();

            _view.BuyButton.onClickEvent.AddListener(OnBuyButtonClick);
        }

        public override void Disable()
        {
            _view.BuyButton.onClickEvent.RemoveListener(OnBuyButtonClick);
            _view.Button.onClickEvent.RemoveListener(SetMaterial);
        }

        private void OnBuyButtonClick()
        {
            if (_playerWallet.TryRemoveMoney(ShopConst.Price) == false)
                _stickyAdService.ShowStickyAd();

            _view.Show();
            _view.Button.SetState(UISelectionState.Pressed);
            SetMaterial();
        }

        private void SetMaterial()
        {
            _skinChangerService.ChangeMaterial(_view.MaterialType);
            _loadService.SaveAll();
        }

        private void SetPriceText()
        {
            if (_playerWallet.Money >= ShopConst.Price)
            {
                _view.FreeText.Hide();
                _view.PriceText.SetText(ShopConst.Price.ToString());
                _view.AdImage.HideImage();
                _view.MoneyIcon.ShowImage();
            }

            else
            {
                _view.PriceText.SetText(string.Empty);
                _view.FreeText.Show();
                _view.MoneyIcon.HideImage();
                _view.AdImage.ShowImage();
            }
        }
    }
}