using System;
using System.Linq;
using Sources.Scripts.Domain.Models.Shops;
using Sources.Scripts.Domain.Models.Upgrades;
using Sources.Scripts.InfrastructureInterfaces.Services.UpgradeServices;
using Sources.Scripts.Presentations.Views.Shops;
using Sources.Scripts.PresentationsInterfaces.Views.Shops;

namespace Sources.Scripts.Controllers.Presenters.Shops
{
    public class ShopPresenter : PresenterBase
    {
        private readonly IShopView _shopView;
        private readonly IUpgradeService _upgradeService;
        private readonly Upgrader _upgrader;
        private readonly PlayerShop _playerShop;

        public ShopPresenter(IShopView view, IUpgradeService upgradeService, Upgrader upgrader, PlayerShop playerShop)
        {
            _shopView = view ?? throw new ArgumentNullException(nameof(view));
            _upgradeService = upgradeService ?? throw new ArgumentNullException(nameof(upgradeService));
            _upgrader = upgrader ?? throw new ArgumentNullException(nameof(upgrader));
            _playerShop = playerShop ?? throw new ArgumentNullException(nameof(playerShop));
        }

        public override void Enable()
        {
            _upgradeService.LevelChanged += ShowTankButton;
            HideAllButtons();
            ShowAvailableButtons();
            Fill();
        }

        public override void Disable() => 
            _upgradeService.LevelChanged -= ShowTankButton;

        private void ShowTankButton(int level)
        {
            IShopTankButtonView tankButtonView = _shopView.TankButtons.FirstOrDefault(x => x.Level == level);

            tankButtonView?.Show();
        }

        private void ShowAvailableButtons()
        {
            for (int i = 1; i <= _upgrader.CurrentLevel; i++)
            {
                IShopTankButtonView tankButtonView = _shopView.TankButtons.First(x => x.Level == i);
                tankButtonView.Show();
            }
        }

        private void HideAllButtons()
        {
            foreach (IShopTankButtonView buttonView in _shopView.TankButtons) 
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