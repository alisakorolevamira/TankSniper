using System;
using JetBrains.Annotations;
using Sources.Scripts.Controllers.Presenters.Inventory;
using Sources.Scripts.Domain.Models.Players;
using Sources.Scripts.Domain.Models.Upgrades;
using Sources.Scripts.InfrastructureInterfaces.Services.Spawners;
using Sources.Scripts.InfrastructureInterfaces.Services.Yandex;
using Sources.Scripts.PresentationsInterfaces.Views.Inventory;

namespace Sources.Scripts.Infrastructure.Factories.Controllers.Presenters.Inventory
{
    public class InventoryTankButtonPresenterFactory
    {
        private readonly IInventoryTankSpawnerService _spawnerService;
        private readonly IRewardedAdService _rewardedAdService;

        public InventoryTankButtonPresenterFactory(
            IInventoryTankSpawnerService spawnerService,
            IRewardedAdService rewardedAdService)
        {
            _spawnerService = spawnerService ?? throw new ArgumentNullException(nameof(spawnerService));
            _rewardedAdService = rewardedAdService ?? throw new ArgumentNullException(nameof(rewardedAdService));
        }
        
        public InventoryTankButtonPresenter Create(
            IInventoryTankButtonView view,
            PlayerWallet playerWallet,
            Upgrader upgrader) => 
            new (view, _spawnerService, _rewardedAdService, playerWallet, upgrader);
    }
}