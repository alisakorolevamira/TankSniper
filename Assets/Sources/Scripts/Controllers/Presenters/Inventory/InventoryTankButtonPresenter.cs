using System;
using Sources.Scripts.Domain.Models.Constants;
using Sources.Scripts.Domain.Models.Players;
using Sources.Scripts.Domain.Models.Upgrades;
using Sources.Scripts.InfrastructureInterfaces.Services.Spawners;
using Sources.Scripts.InfrastructureInterfaces.Services.Yandex;
using Sources.Scripts.PresentationsInterfaces.Views.Inventory;

namespace Sources.Scripts.Controllers.Presenters.Inventory
{
    public class InventoryTankButtonPresenter : PresenterBase
    {
        private readonly IInventoryTankButtonView _tankButtonView;
        private readonly IInventoryTankSpawnerService _spawnerService;
        private readonly IRewardedAdService _rewardedAdService;
        private readonly PlayerWallet _playerWallet;
        private readonly Upgrader _upgrader;
        private readonly string _free = "FREE";

        private int _price => _upgrader.CurrentLevel * PlayerConst.RewardIndex;

        public InventoryTankButtonPresenter(
            IInventoryTankButtonView tankButtonView,
            IInventoryTankSpawnerService spawnerService,
            IRewardedAdService rewardedAdService,
            PlayerWallet playerWallet,
            Upgrader upgrader)
        {
            _tankButtonView = tankButtonView ?? throw new ArgumentNullException(nameof(tankButtonView));
            _spawnerService = spawnerService ?? throw new ArgumentNullException(nameof(spawnerService));
            _rewardedAdService = rewardedAdService ?? throw new ArgumentNullException(nameof(rewardedAdService));
            _playerWallet = playerWallet ?? throw new ArgumentNullException(nameof(playerWallet));
            _upgrader = upgrader ?? throw new ArgumentNullException(nameof(upgrader));
        }

        public override void Enable()
        {
            _tankButtonView.Button.onClickEvent.AddListener(OnButtonClick);
            SetPriceText();
            
        }

        public override void Disable()
        {
            _tankButtonView.Button.onClickEvent.RemoveListener(OnButtonClick);
        }

        private void OnButtonClick()
        {
            if (_playerWallet.TryRemoveMoney(_price))
            {
                _spawnerService.Spawn(InventoryTankConst.DefaultTankLevel);
                SetPriceText();
                return;
            }
            
            _rewardedAdService.ShowRewardedAd();
        }

        private void SetPriceText()
        {
            if (_playerWallet.Money >= _price)
            {
                _tankButtonView.FreeText.SetText(string.Empty);
                _tankButtonView.PriceText.SetText(_price.ToString());
                _tankButtonView.AdImage.HideImage();
                _tankButtonView.MoneyIcon.ShowImage();
            }

            else
            {
                _tankButtonView.PriceText.SetText(string.Empty);
                _tankButtonView.FreeText.SetText(_free);
                _tankButtonView.MoneyIcon.HideImage();
                _tankButtonView.AdImage.ShowImage();
            }
        }
    }
}