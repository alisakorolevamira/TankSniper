using System;
using System.Collections.Generic;
using Sources.Scripts.Domain.Models.Data.Ids;
using Sources.Scripts.Domain.Models.Gameplay;
using Sources.Scripts.Domain.Models.Inventory;
using Sources.Scripts.Domain.Models.Players;
using Sources.Scripts.Domain.Models.Settings;
using Sources.Scripts.Domain.Models.Upgrades;
using Sources.Scripts.DomainInterfaces.Models.Payloads;
using Sources.Scripts.Infrastructure.Factories.Views.Gameplay;
using Sources.Scripts.Infrastructure.Factories.Views.Inventory;
using Sources.Scripts.Infrastructure.Factories.Views.Players;
using Sources.Scripts.Infrastructure.Factories.Views.Settings;
using Sources.Scripts.Infrastructure.Factories.Views.Shop;
using Sources.Scripts.InfrastructureInterfaces.Services.Audio;
using Sources.Scripts.InfrastructureInterfaces.Services.LoadServices;
using Sources.Scripts.InfrastructureInterfaces.Services.Repositories;
using Sources.Scripts.InfrastructureInterfaces.Services.Shop;
using Sources.Scripts.InfrastructureInterfaces.Services.Spawners;
using Sources.Scripts.InfrastructureInterfaces.Services.Tutorials;
using Sources.Scripts.InfrastructureInterfaces.Services.UpgradeServices;
using Sources.Scripts.Presentations.UI.Huds;

namespace Sources.Scripts.Infrastructure.Factories.Views.SceneViewFactories.MainMenu
{
    public class LoadMainMenuSceneService : LoadMainMenuSceneServiceBase
    {
        private readonly ILoadService _loadService;
        private readonly IEntityRepository _entityRepository;
        
        public LoadMainMenuSceneService(
            IEntityRepository entityRepository,
            ILoadService loadService,
            MainMenuHud mainMenuHud,
            LevelAvailabilityViewFactory levelAvailabilityViewFactory,
            VolumeViewFactory volumeViewFactory,
            InventoryGridViewFactory inventoryGridViewFactory,
            SkinChangerViewFactory skinChangerViewFactory,
            ShopViewFactory shopViewFactory,
            ShopPatternButtonViewFactory shopPatternButtonViewFactory,
            ShopDecalButtonViewFactory shopDecalButtonViewFactory,
            WalletUIFactory walletUIFactory,
            InventoryTankButtonViewFactory inventoryTankButtonViewFactory,
            IVolumeService volumeService,
            ITutorialService tutorialService,
            IInventoryTankSpawnerService inventoryTankSpawnerService,
            ISkinChangerService skinChangerService,
            IUpgradeService upgradeService)
            : base(
                mainMenuHud, 
                levelAvailabilityViewFactory,
                volumeViewFactory,
                inventoryGridViewFactory,
                skinChangerViewFactory,
                shopViewFactory,
                shopPatternButtonViewFactory,
                shopDecalButtonViewFactory,
                walletUIFactory,
                inventoryTankButtonViewFactory,
                volumeService, 
                tutorialService,
                inventoryTankSpawnerService,
                skinChangerService,
                upgradeService)
        {
            _loadService = loadService ?? throw new ArgumentNullException(nameof(loadService));
            _entityRepository = entityRepository ?? throw new ArgumentNullException(nameof(entityRepository));
        }

        protected override MainMenuModels LoadModels(IScenePayload scenePayload)
        {
            Tutorial tutorial = _loadService.Load(ModelId.Tutorial) as Tutorial;
            
            Volume volume = _loadService.Load(ModelId.Volume) as Volume;
            
            GameData gameData = _loadService.Load(ModelId.GameData) as GameData;
            
            SavedLevel savedLevel = _loadService.Load(ModelId.SavedLevel) as SavedLevel;

            Upgrader upgrader = _loadService.Load(ModelId.Upgrader) as Upgrader;

            GameLevels gameLevels = _loadService.Load(ModelId.GameLevels) as GameLevels;

            LevelAvailability levelAvailability = new LevelAvailability(gameLevels.Levels);
            
            PlayerWallet playerWallet = _loadService.Load(ModelId.PlayerWallet) as PlayerWallet;

            Player player = new Player(playerWallet);
            
            SkinChanger skinChanger = _loadService.Load(ModelId.SkinChanger) as SkinChanger;

            InventoryGrid inventoryGrid = _loadService.Load(ModelId.InventoryGrid) as InventoryGrid;
            
            return new MainMenuModels(
                volume,
                gameLevels,
                levelAvailability,
                gameData,
                tutorial,
                player,
                upgrader,
                skinChanger,
                savedLevel,
                inventoryGrid);
        }
    }
}