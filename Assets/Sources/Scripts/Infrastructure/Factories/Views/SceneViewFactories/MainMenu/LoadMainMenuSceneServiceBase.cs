using System;
using Sources.Scripts.Domain.Models.Gameplay;
using Sources.Scripts.DomainInterfaces.Models.Payloads;
using Sources.Scripts.Infrastructure.Factories.Views.Gameplay;
using Sources.Scripts.Infrastructure.Factories.Views.Inventory;
using Sources.Scripts.Infrastructure.Factories.Views.MainMenu;
using Sources.Scripts.Infrastructure.Factories.Views.Players;
using Sources.Scripts.Infrastructure.Factories.Views.Settings;
using Sources.Scripts.Infrastructure.Factories.Views.Shops;
using Sources.Scripts.Infrastructure.Factories.Views.Stickman;
using Sources.Scripts.InfrastructureInterfaces.Factories.Views.SceneViewFactories;
using Sources.Scripts.InfrastructureInterfaces.Services.Audio;
using Sources.Scripts.InfrastructureInterfaces.Services.Shop;
using Sources.Scripts.InfrastructureInterfaces.Services.Spawners;
using Sources.Scripts.InfrastructureInterfaces.Services.Tutorials;
using Sources.Scripts.InfrastructureInterfaces.Services.UpgradeServices;
using Sources.Scripts.Presentations.UI.Huds;
using Sources.Scripts.Presentations.Views.Gameplay;
using Sources.Scripts.Presentations.Views.Players;
using Sources.Scripts.Presentations.Views.Players.Skins;
using Sources.Scripts.Presentations.Views.Shops;
using Sources.Scripts.Presentations.Views.Stickman;

namespace Sources.Scripts.Infrastructure.Factories.Views.SceneViewFactories.MainMenu
{
    public abstract class LoadMainMenuSceneServiceBase : ILoadSceneService
    {
        private readonly MainMenuHud _mainMenuHud;
        private readonly LevelAvailabilityViewFactory _levelAvailabilityViewFactory;
        private readonly VolumeViewFactory _volumeViewFactory;
        private readonly InventoryGridViewFactory _inventoryGridViewFactory;
        private readonly SkinChangerViewFactory _skinChangerViewFactory;
        private readonly StickmanChangerViewFactory _sticmanChangerViewFactory;
        private readonly ShopViewFactory _shopViewFactory;
        private readonly ShopPatternButtonViewFactory _shopPatternButtonViewFactory;
        private readonly ShopDecalButtonViewFactory _shopDecalButtonViewFactory;
        private readonly WalletUIFactory _walletUIFactory;
        private readonly InventoryTankButtonViewFactory _inventoryTankButtonViewFactory;
        private readonly MainMenuViewFactory _mainMenuViewFactory;
        private readonly IVolumeService _volumeService;
        private readonly ITutorialService _tutorialService;
        private readonly IInventoryTankSpawnerService _inventoryTankSpawnerService;
        private readonly ISkinChangerService _skinChangerService;
        private readonly IStickmanChangerService _stickmanChangerService;
        private readonly IUpgradeService _upgradeService;
        
        protected LoadMainMenuSceneServiceBase(
            MainMenuHud mainMenuHud,
            LevelAvailabilityViewFactory levelAvailabilityViewFactory,
            VolumeViewFactory volumeViewFactory,
            InventoryGridViewFactory inventoryGridViewFactory,
            SkinChangerViewFactory skinChangerViewFactory,
            StickmanChangerViewFactory sticmanChangerViewFactory,
            ShopViewFactory shopViewFactory,
            ShopPatternButtonViewFactory shopPatternButtonViewFactory,
            ShopDecalButtonViewFactory shopDecalButtonViewFactory,
            WalletUIFactory walletUIFactory,
            InventoryTankButtonViewFactory inventoryTankButtonViewFactory,
            MainMenuViewFactory mainMenuViewFactory,
            IVolumeService volumeService,
            ITutorialService tutorialService,
            IInventoryTankSpawnerService inventoryTankSpawnerService,
            ISkinChangerService skinChangerService,
            IStickmanChangerService stickmanChangerService,
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
            _sticmanChangerViewFactory = sticmanChangerViewFactory ??
                                         throw new ArgumentNullException(nameof(sticmanChangerViewFactory));
            _shopViewFactory = shopViewFactory ?? throw new ArgumentNullException(nameof(shopViewFactory));
            _shopPatternButtonViewFactory = shopPatternButtonViewFactory ??
                                            throw new ArgumentNullException(nameof(shopPatternButtonViewFactory));
            _shopDecalButtonViewFactory = shopDecalButtonViewFactory ??
                                          throw new ArgumentNullException(nameof(shopDecalButtonViewFactory));
            _walletUIFactory = walletUIFactory ?? throw new ArgumentNullException(nameof(walletUIFactory));
            _inventoryTankButtonViewFactory = inventoryTankButtonViewFactory ??
                                              throw new ArgumentNullException(nameof(inventoryTankButtonViewFactory));
            _mainMenuViewFactory = mainMenuViewFactory ?? throw new ArgumentNullException(nameof(mainMenuViewFactory));
            _volumeService = volumeService ?? throw new ArgumentNullException(nameof(volumeService));
            _tutorialService = tutorialService ?? throw new ArgumentNullException(nameof(tutorialService));
            _skinChangerService = skinChangerService ?? throw new ArgumentNullException(nameof(skinChangerService));
            _stickmanChangerService = stickmanChangerService ??
                                      throw new ArgumentNullException(nameof(stickmanChangerService));
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

            foreach (StickmanChangerView stickmanChangerView in _mainMenuHud.StickmanChangerViews)
                _sticmanChangerViewFactory.Create(models.StickmanChanger, stickmanChangerView);
            
            foreach (WalletUI wallet in _mainMenuHud.WalletsUI) 
                _walletUIFactory.Create(models.Player.PlayerWallet, wallet);
            
            _upgradeService.Register(models.Upgrader, models.SkinChanger);
            
            _inventoryGridViewFactory.Create(_mainMenuHud.InventoryGridView, models.InventoryGrid);
            _inventoryTankSpawnerService.AddSlots(_mainMenuHud.InventoryGridView.Slots);
            _inventoryTankButtonViewFactory.Create(
                _mainMenuHud.AddTankButtonView,
                models.Player.PlayerWallet,
                models.Upgrader);
            
            _tutorialService.Construct(models.Tutorial);
            
            _skinChangerService.Construct(models.SkinChanger);
            
            _stickmanChangerService.Construct(models.StickmanChanger);

            _shopViewFactory.Create(_mainMenuHud.ShopView, models.Upgrader, models.StickmanChanger, models.Shop);

            _mainMenuViewFactory.Create(_mainMenuHud.MainMenuView, models.MainMenuAppearance);

            foreach (ShopPatternButtonView patternButton in _mainMenuHud.ShopView.PatternButtons)
                _shopPatternButtonViewFactory.Create(patternButton, models.Player.PlayerWallet);

            foreach (ShopDecalButtonView decalButton in _mainMenuHud.ShopView.DecalButtons) 
                _shopDecalButtonViewFactory.Create(decalButton, models.Player.PlayerWallet);

            foreach (LevelAvailabilityView view in _mainMenuHud.LevelAvailabilityViews) 
                _levelAvailabilityViewFactory.Create(models.LevelAvailability, view);
            
        }
        
        protected abstract MainMenuModels LoadModels(IScenePayload scenePayload);
    }
}