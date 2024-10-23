using System;
using Sources.Scripts.Domain.Models.Data.Ids;
using Sources.Scripts.Domain.Models.Gameplay;
using Sources.Scripts.Domain.Models.Inventory;
using Sources.Scripts.Domain.Models.Players;
using Sources.Scripts.Domain.Models.Settings;
using Sources.Scripts.Domain.Models.Shops;
using Sources.Scripts.Domain.Models.Stickman;
using Sources.Scripts.Domain.Models.Upgrades;
using Sources.Scripts.DomainInterfaces.Models.Payloads;
using Sources.Scripts.Infrastructure.Factories.Views.Gameplay;
using Sources.Scripts.Infrastructure.Factories.Views.Inventory;
using Sources.Scripts.Infrastructure.Factories.Views.MainMenu;
using Sources.Scripts.Infrastructure.Factories.Views.Music;
using Sources.Scripts.Infrastructure.Factories.Views.Players;
using Sources.Scripts.Infrastructure.Factories.Views.Settings;
using Sources.Scripts.Infrastructure.Factories.Views.Shops;
using Sources.Scripts.Infrastructure.Factories.Views.Stickman;
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
    public class CreateMainMenuSceneService : LoadMainMenuSceneServiceBase
    {
        private readonly ILoadService _loadService;
        private readonly IEntityRepository _entityRepository;
        
        public CreateMainMenuSceneService(
            ILoadService loadService,
            IEntityRepository entityRepository,
            MainMenuHud mainMenuHud,
            LevelAvailabilityViewFactory levelAvailabilityViewFactory,
            VolumeViewFactory volumeViewFactory,
            InventoryGridViewFactory inventoryGridViewFactory,
            SkinChangerViewFactory skinChangerViewFactory,
            StickmanChangerViewFactory stickmanChangerViewFactory,
            ShopViewFactory shopViewFactory,
            ShopPatternButtonViewFactory shopPatternButtonViewFactory,
            ShopDecalButtonViewFactory shopDecalButtonViewFactory,
            WalletUIFactory walletUIFactory,
            InventoryTankButtonViewFactory inventoryTankButtonViewFactory,
            MainMenuViewFactory mainMenuViewFactory,
            BackgroundMusicViewFactory backgroundMusicViewFactory,
            IVolumeService volumeService,
            ITutorialService tutorialService,
            IUpgradeService upgradeService,
            ISkinChangerService skinChangerService,
            IStickmanChangerService stickmanChangerService,
            IInventoryTankSpawnerService inventoryTankSpawnerService)
            : base(
                mainMenuHud,
                levelAvailabilityViewFactory,
                volumeViewFactory,
                inventoryGridViewFactory,
                skinChangerViewFactory,
                stickmanChangerViewFactory,
                shopViewFactory,
                shopPatternButtonViewFactory,
                shopDecalButtonViewFactory,
                walletUIFactory,
                inventoryTankButtonViewFactory,
                mainMenuViewFactory,
                backgroundMusicViewFactory,
                volumeService,
                tutorialService,
                inventoryTankSpawnerService,
                skinChangerService,
                stickmanChangerService,
                upgradeService)
        {
            _loadService = loadService ?? throw new ArgumentNullException(nameof(loadService));
            _entityRepository = entityRepository;
        }

        protected override MainMenuModels LoadModels(IScenePayload scenePayload)
        {
            MainMenuAppearance mainMenu = new MainMenuAppearance(ModelId.MainMenuAppearance);
            _entityRepository.Add(mainMenu);
            
            Tutorial tutorial = new Tutorial(ModelId.Tutorial);
            _entityRepository.Add(tutorial);

            Volume volume = new Volume(ModelId.Volume);
            _entityRepository.Add(volume);
            
            GameData gameData = new GameData(ModelId.GameData);
            _entityRepository.Add(gameData);
            
            SavedLevel savedLevel = new SavedLevel(ModelId.SavedLevel);
            _entityRepository.Add(savedLevel);

            Upgrader upgrader = new Upgrader(ModelId.Upgrader);
            _entityRepository.Add(upgrader);

            GameLevels gameLevels = new GameLevels(ModelId.GameLevels);
           _entityRepository.Add(gameLevels);
            
            PlayerWallet playerWallet = new PlayerWallet(ModelId.PlayerWallet);
            _entityRepository.Add(playerWallet);
            
            Player player = new Player(playerWallet);

            SkinChanger skinChanger = new SkinChanger(ModelId.SkinChanger);
            _entityRepository.Add(skinChanger);

            StickmanChanger stickmanChanger = new StickmanChanger(ModelId.StickmanChanger);
            _entityRepository.Add(stickmanChanger);

            InventoryGrid grid = new InventoryGrid(ModelId.InventoryGrid);
            _entityRepository.Add(grid);

            PlayerShop playerShop = new PlayerShop(ModelId.PlayerShop);
            _entityRepository.Add(playerShop);

            LevelAvailability levelAvailability = new LevelAvailability(gameLevels.Levels, mainMenu.Index);

            _loadService.SaveAll();

            return new MainMenuModels(
                mainMenu,
                volume,
                gameLevels,
                levelAvailability,
                gameData,
                tutorial,
                player,
                upgrader,
                skinChanger,
                stickmanChanger,
                savedLevel,
                grid,
                playerShop);
        }
    }
}