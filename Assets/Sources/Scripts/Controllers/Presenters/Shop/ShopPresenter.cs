using System;
using System.Linq;
using Sources.Scripts.Domain.Models.Upgrades;
using Sources.Scripts.InfrastructureInterfaces.Services.UpgradeServices;
using Sources.Scripts.PresentationsInterfaces.Views.Shop;

namespace Sources.Scripts.Controllers.Presenters.Shop
{
    public class ShopPresenter : PresenterBase
    {
        private readonly IShopView _shopView;
        private readonly IUpgradeService _upgradeService;
        private readonly Upgrader _upgrader;

        public ShopPresenter(IShopView view, IUpgradeService upgradeService, Upgrader upgrader)
        {
            _shopView = view ?? throw new ArgumentNullException(nameof(view));
            _upgradeService = upgradeService ?? throw new ArgumentNullException(nameof(upgradeService));
            _upgrader = upgrader ?? throw new ArgumentNullException(nameof(upgrader));
        }

        public override void Enable()
        {
            _upgradeService.LevelChanged += ShowTankButton;
            HideAllButtons();
            ShowAvailableButtons();
        }

        public override void Disable()
        {
            _upgradeService.LevelChanged -= ShowTankButton;
        }

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
    }
}