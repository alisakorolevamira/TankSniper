using System;
using JetBrains.Annotations;
using Sources.Scripts.Domain.Models.Gameplay;
using Sources.Scripts.DomainInterfaces.Models.Payloads;
using Sources.Scripts.Infrastructure.Factories.Views.Gameplay;
using Sources.Scripts.Infrastructure.Factories.Views.Inventory;
using Sources.Scripts.Infrastructure.Factories.Views.Players;
using Sources.Scripts.Infrastructure.Factories.Views.Settings;
using Sources.Scripts.Infrastructure.Factories.Views.Shop;
using Sources.Scripts.InfrastructureInterfaces.Factories.Views.SceneViewFactories;
using Sources.Scripts.InfrastructureInterfaces.Services.Audio;
using Sources.Scripts.InfrastructureInterfaces.Services.Shop;
using Sources.Scripts.InfrastructureInterfaces.Services.Spawners;
using Sources.Scripts.InfrastructureInterfaces.Services.Tutorials;
using Sources.Scripts.InfrastructureInterfaces.Services.UpgradeServices;
using Sources.Scripts.Presentations.UI.Huds;
using Sources.Scripts.Presentations.Views.Players;
using Sources.Scripts.Presentations.Views.Players.Skins;

namespace Sources.Scripts.Infrastructure.Factories.Views.SceneViewFactories.MainMenu
{
    public abstract class LoadMainMenuSceneServiceBase : ILoadSceneService
    {
        private readonly MainMenuHud _mainMenuHud;
        private readonly LevelAvailabilityViewFactory _levelAvailabilityViewFactory;
        private readonly VolumeViewFactory _volumeViewFactory;
        private readonly InventoryGridViewFactory _inventoryGridViewFactory;
        private readonly SkinChangerViewFactory _skinChangerViewFactory;
        private readonly ShopViewFactory _shopViewFactory;
        private readonly WalletUIFactory _walletUIFactory;
        private readonly IVolumeService _volumeService;
        private readonly ITutorialService _tutorialService;
        private readonly IInventoryTankSpawnerService _inventoryTankSpawnerService;
        private readonly ISkinChangerService _skinChangerService;
        private readonly IUpgradeService _upgradeService;
        
        protected LoadMainMenuSceneServiceBase(
            MainMenuHud mainMenuHud,
            LevelAvailabilityViewFactory levelAvailabilityViewFactory,
            VolumeViewFactory volumeViewFactory,
            InventoryGridViewFactory inventoryGridViewFactory,
            SkinChangerViewFactory skinChangerViewFactory,
            ShopViewFactory shopViewFactory,
            WalletUIFactory walletUIFactory,
            IVolumeService volumeService,
            ITutorialService tutorialService,
            IInventoryTankSpawnerService inventoryTankSpawnerService,
            ISkinChangerService skinChangerService,
            IUpgradeService upgradeService)
        {
            _mainMenuHud = mainMenuHud ? mainMenuHud : throw new ArgumentNullException(nameof(mainMenuHud));
            _levelAvailabilityViewFactory = levelAvailabilityViewFactory ?? 
                                            throw new ArgumentNullException(nameof(levelAvailabilityViewFactory));
            _volumeViewFactory = volumeViewFactory ?? throw new ArgumentNullException(nameof(volumeViewFactory));
            _inventoryGridViewFactory = inventoryGridViewFactory ??
                                        throw new ArgumentNullException(nameof(inventoryGridViewFactory));
            _skinChangerViewFactory = skinChangerViewFactory ??
                                      throw new ArgumentNullException(nameof(skinChangerViewFactory));
            _shopViewFactory = shopViewFactory ?? throw new ArgumentNullException(nameof(shopViewFactory));
            _walletUIFactory = walletUIFactory ?? throw new ArgumentNullException(nameof(walletUIFactory));
            _volumeService = volumeService ?? throw new ArgumentNullException(nameof(volumeService));
            _tutorialService = tutorialService ?? throw new ArgumentNullException(nameof(tutorialService));
            _skinChangerService = skinChangerService ?? throw new ArgumentNullException(nameof(skinChangerService));
            _inventoryTankSpawnerService = inventoryTankSpawnerService ??
                                           throw new ArgumentNullException(nameof(inventoryTankSpawnerService));
            _upgradeService = upgradeService ?? throw new ArgumentNullException(nameof(upgradeService));
        }
        
        public void Load(IScenePayload scenePayload)
        {
            MainMenuModels models = LoadModels(scenePayload);
            
            SavedLevel savedLevel = models.SavedLevel;
            
            _volumeService.Register(models.Volume);
            _volumeViewFactory.Create(_volumeService, _mainMenuHud.VolumeView);

            foreach (SkinChangerView skinChangerView in _mainMenuHud.SkinChangerViews) 
                _skinChangerViewFactory.Create(models.SkinChanger, skinChangerView);
            
            foreach (WalletUI wallet in _mainMenuHud.WalletsUI) 
                _walletUIFactory.Create(models.Player.PlayerWallet, wallet);
            
            _upgradeService.Register(models.Upgrader, models.SkinChanger);
            
            _levelAvailabilityViewFactory.Create(models.LevelAvailability, _mainMenuHud.LevelAvailabilityView);
            
            _inventoryGridViewFactory.Create(_mainMenuHud.InventoryGridView, models.InventoryGrid);
            _inventoryTankSpawnerService.AddSlots(_mainMenuHud.InventoryGridView.Slots);
            
            _tutorialService.Construct(models.Tutorial);
            
            _skinChangerService.Construct(models.SkinChanger);

            _shopViewFactory.Create(_mainMenuHud.ShopView, models.Upgrader);
        }
        
        protected abstract MainMenuModels LoadModels(IScenePayload scenePayload);
    }
}