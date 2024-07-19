using System;
using System.Linq;
using Sources.Scripts.Domain.Models.Shops;
using Sources.Scripts.Domain.Models.Stickman;
using Sources.Scripts.Domain.Models.Upgrades;
using Sources.Scripts.InfrastructureInterfaces.Services.Shop;
using Sources.Scripts.InfrastructureInterfaces.Services.UpgradeServices;
using Sources.Scripts.Presentations.Views.Shops;
using Sources.Scripts.PresentationsInterfaces.Views.Shops;

namespace Sources.Scripts.Controllers.Presenters.Shops
{
    public class ShopPresenter : PresenterBase
    {
        private readonly IShopView _shopView;
        private readonly IUpgradeService _upgradeService;
        private readonly IStickmanChangerService _stickmanChangerService;
        private readonly Upgrader _upgrader;
        private readonly StickmanChanger _stickmanChanger;
        private readonly PlayerShop _playerShop;

        public ShopPresenter(IShopView view,
            IUpgradeService upgradeService,
            Upgrader upgrader,
            StickmanChanger stickmanChanger,
            PlayerShop playerShop,
            IStickmanChangerService stickmanChangerService)
        {
            _shopView = view ?? throw new ArgumentNullException(nameof(view));
            _upgradeService = upgradeService ?? throw new ArgumentNullException(nameof(upgradeService));
            _upgrader = upgrader ?? throw new ArgumentNullException(nameof(upgrader));
            _stickmanChanger = stickmanChanger ?? throw new ArgumentNullException(nameof(stickmanChanger));
            _playerShop = playerShop ?? throw new ArgumentNullException(nameof(playerShop));
            _stickmanChangerService = stickmanChangerService ??
                                      throw new ArgumentNullException(nameof(stickmanChangerService));
        }

        public override void Enable()
        {
            _upgradeService.LevelChanged += ShowTankButton;
            _stickmanChangerService.StickmanOpened += ShowStickmanButton;
            
            HideAllButtons();
            ShowAvailableButtons();
            Fill();
        }

        public override void Disable()
        {
            _upgradeService.LevelChanged -= ShowTankButton;
            _stickmanChangerService.StickmanOpened -= ShowStickmanButton;
        }

        private void ShowTankButton(int level)
        {
            IShopTankButtonView tankButtonView =
                _shopView.TankButtons.FirstOrDefault(button => button.Level == level);

            tankButtonView?.Show();
        }

        private void ShowStickmanButton(int level)
        {
            IShopStickmanButtonView shopStickmanButtonView =
                _shopView.StickmanButtons.FirstOrDefault(button => button.Level == level);
            
            shopStickmanButtonView?.Show();
        }

        private void ShowAvailableButtons()
        {
            for (int i = 1; i <= _upgrader.CurrentLevel; i++)
            {
                IShopTankButtonView tankButtonView = _shopView.TankButtons.First(button => button.Level == i);

                tankButtonView.Show();
            }

            if (_stickmanChanger.Level == 0)
                return;
            
            for (int i = 1; i <= _stickmanChanger.Level; i++)
            {
                IShopStickmanButtonView shopStickmanButtonView =
                    _shopView.StickmanButtons.First(button => button.Level == i);
                
                shopStickmanButtonView.Show();
            }
        }

        private void HideAllButtons()
        {
            foreach (IShopTankButtonView buttonView in _shopView.TankButtons) 
                buttonView.Hide();

            foreach (IShopStickmanButtonView buttonView in _shopView.StickmanButtons) 
                buttonView.Hide();
        }

        private void Fill()
        {
            foreach (ShopPatternButtonView buttonView in _shopView.PatternButtons)
            {
                ShopPatternButton button =
                    _playerShop.PatternButtons.First(x => x.MaterialType== buttonView.MaterialType);
                buttonView.Construct(button);
            }
            
            foreach (ShopDecalButtonView buttonView in _shopView.DecalButtons)
            {
                ShopDecalButton button =
                    _playerShop.DecalButtons.First(x => x.DecalType== buttonView.DecalType);
                buttonView.Construct(button);
            }
        }
    }
}