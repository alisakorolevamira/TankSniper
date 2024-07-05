﻿using System;
using System.Collections.Generic;
using Sources.Scripts.Domain.Models.Constants;
using Sources.Scripts.Domain.Models.Data.Ids;
using Sources.Scripts.Domain.Models.Gameplay;
using Sources.Scripts.Domain.Models.Inventory;
using Sources.Scripts.Domain.Models.Players;
using Sources.Scripts.Domain.Models.Settings;
using Sources.Scripts.Domain.Models.Shops;
using Sources.Scripts.Domain.Models.Upgrades;
using Sources.Scripts.DomainInterfaces.Models.Payloads;
using Sources.Scripts.Infrastructure.Factories.Views.Gameplay;
using Sources.Scripts.Infrastructure.Factories.Views.Inventory;
using Sources.Scripts.Infrastructure.Factories.Views.MainMenu;
using Sources.Scripts.Infrastructure.Factories.Views.Players;
using Sources.Scripts.Infrastructure.Factories.Views.Settings;
using Sources.Scripts.Infrastructure.Factories.Views.Shops;
using Sources.Scripts.InfrastructureInterfaces.Services.Audio;
using Sources.Scripts.InfrastructureInterfaces.Services.LoadServices;
using Sources.Scripts.InfrastructureInterfaces.Services.Repositories;
using Sources.Scripts.InfrastructureInterfaces.Services.Shop;
using Sources.Scripts.InfrastructureInterfaces.Services.Spawners;
using Sources.Scripts.InfrastructureInterfaces.Services.Tutorials;
using Sources.Scripts.InfrastructureInterfaces.Services.UpgradeServices;
using Sources.Scripts.Presentations.UI.Huds;
using Sources.Scripts.Presentations.Views.Players.Skins.DecalsType;
using Sources.Scripts.Presentations.Views.Players.Skins.MaterialTypes;
using Sources.Scripts.Presentations.Views.Players.Skins.SkinTypes;

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
            ShopViewFactory shopViewFactory,
            ShopPatternButtonViewFactory shopPatternButtonViewFactory,
            ShopDecalButtonViewFactory shopDecalButtonViewFactory,
            WalletUIFactory walletUIFactory,
            InventoryTankButtonViewFactory inventoryTankButtonViewFactory,
            MainMenuViewFactory mainMenuViewFactory,
            IVolumeService volumeService,
            ITutorialService tutorialService,
            IUpgradeService upgradeService,
            ISkinChangerService skinChangerService,
            IInventoryTankSpawnerService inventoryTankSpawnerService)
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
                mainMenuViewFactory,
                volumeService,
                tutorialService,
                inventoryTankSpawnerService,
                skinChangerService,
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

            InventoryGrid grid = new InventoryGrid(ModelId.InventoryGrid);
            _entityRepository.Add(grid);

            PlayerShop playerShop = new PlayerShop(ModelId.PlayerShop);
            _entityRepository.Add(playerShop);

            LevelAvailability levelAvailability = new LevelAvailability(gameLevels.Levels);

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
                savedLevel,
                grid,
                playerShop);
        }

        private Volume CreateVolume()
        {
            //if (_loadService.HasKey(ModelId.Volume))
            //    return _loadService.Load<Volume>(ModelId.Volume);

            Volume volume = new Volume(ModelId.Volume);
            _entityRepository.Add(volume);
            
            return volume;
        }
    }
}