using System;
using JetBrains.Annotations;
using Sources.Scripts.Domain.Models.Gameplay;
using Sources.Scripts.DomainInterfaces.Models.Payloads;
using Sources.Scripts.Infrastructure.Factories.Views.Gameplay;
using Sources.Scripts.Infrastructure.Factories.Views.Inventory;
using Sources.Scripts.Infrastructure.Factories.Views.Players;
using Sources.Scripts.Infrastructure.Factories.Views.Settings;
using Sources.Scripts.InfrastructureInterfaces.Factories.Views.SceneViewFactories;
using Sources.Scripts.InfrastructureInterfaces.Services.Audio;
using Sources.Scripts.InfrastructureInterfaces.Services.Spawners;
using Sources.Scripts.InfrastructureInterfaces.Services.Tutorials;
using Sources.Scripts.InfrastructureInterfaces.Services.UpgradeServices;
using Sources.Scripts.Presentations.UI.Huds;
using Sources.Scripts.Presentations.Views.Players;
using Sources.Scripts.PresentationsInterfaces.Views.Players;

namespace Sources.Scripts.Infrastructure.Factories.Views.SceneViewFactories.MainMenu
{
    public abstract class LoadMainMenuSceneServiceBase : ILoadSceneService
    {
        private readonly MainMenuHud _mainMenuHud;
        private readonly LevelAvailabilityViewFactory _levelAvailabilityViewFactory;
        private readonly VolumeViewFactory _volumeViewFactory;
        private readonly InventoryGridViewFactory _inventoryGridViewFactory;
        private readonly WalletUIFactory _walletUIFactory;
        private readonly IVolumeService _volumeService;
        private readonly ITutorialService _tutorialService;
        private readonly IPlayerSpawnerService _playerSpawnerService;
        private readonly IInventoryTankSpawnerService _inventoryTankSpawnerService;
        private readonly IUpgradeService _upgradeService;
        private readonly MainMenuPlayerViewFactory _playerViewFactory;
        
        protected LoadMainMenuSceneServiceBase(
            MainMenuHud mainMenuHud,
            LevelAvailabilityViewFactory levelAvailabilityViewFactory,
            VolumeViewFactory volumeViewFactory,
            InventoryGridViewFactory inventoryGridViewFactory,
            WalletUIFactory walletUIFactory,
            IVolumeService volumeService,
            ITutorialService tutorialService,
            IPlayerSpawnerService playerSpawnerService,
            IInventoryTankSpawnerService inventoryTankSpawnerService,
            IUpgradeService upgradeService,
            MainMenuPlayerViewFactory playerViewFactory)
        {
            _mainMenuHud = mainMenuHud ? mainMenuHud : throw new ArgumentNullException(nameof(mainMenuHud));
            _levelAvailabilityViewFactory = levelAvailabilityViewFactory ?? 
                                            throw new ArgumentNullException(nameof(levelAvailabilityViewFactory));
            _volumeViewFactory = volumeViewFactory ?? throw new ArgumentNullException(nameof(volumeViewFactory));
            _inventoryGridViewFactory = inventoryGridViewFactory ??
                                        throw new ArgumentNullException(nameof(inventoryGridViewFactory));
            _walletUIFactory = walletUIFactory ?? throw new ArgumentNullException(nameof(walletUIFactory));
            _volumeService = volumeService ?? throw new ArgumentNullException(nameof(volumeService));
            _tutorialService = tutorialService ?? throw new ArgumentNullException(nameof(tutorialService));
            _playerSpawnerService = playerSpawnerService ?? throw new ArgumentNullException(nameof(playerSpawnerService));
            _inventoryTankSpawnerService = inventoryTankSpawnerService ??
                                           throw new ArgumentNullException(nameof(inventoryTankSpawnerService));
            _upgradeService = upgradeService ?? throw new ArgumentNullException(nameof(upgradeService));
            _playerViewFactory = playerViewFactory ?? throw new ArgumentNullException(nameof(playerViewFactory));
        }
        
        public void Load(IScenePayload scenePayload)
        {
            MainMenuModels models = LoadModels(scenePayload);
            
            SavedLevel savedLevel = models.SavedLevel;
            
            _volumeService.Register(models.Volume);
            _volumeViewFactory.Create(_volumeService, _mainMenuHud.VolumeView);
            
            //PlayerView playerView = _playerViewFactory.Create(models.Player);
            IPlayerView playerView = _playerSpawnerService.Spawn(models.Player, models.Upgrader.CurrentLevel);
            
            foreach (WalletUI wallet in _mainMenuHud.WalletsUI) 
                _walletUIFactory.Create(models.Player.PlayerWallet, wallet);
            
            _upgradeService.Register(models.Upgrader);
            
            _levelAvailabilityViewFactory.Create(models.LevelAvailability, _mainMenuHud.LevelAvailabilityView);
            
            _inventoryGridViewFactory.Create(_mainMenuHud.InventoryGridView, models.InventoryGrid);
            _inventoryTankSpawnerService.AddSlots(_mainMenuHud.InventoryGridView.Slots);
            
            _tutorialService.Construct(models.Tutorial);
        }
        
        protected abstract MainMenuModels LoadModels(IScenePayload scenePayload);
    }
}