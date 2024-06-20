﻿using System;
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
using Sources.Scripts.Presentations.UI.Huds;
using Sources.Scripts.Presentations.Views.Players;
using Sources.Scripts.UIFramework.Infrastructure.Factories.Services.Collectors;
using Sources.Scripts.UIFramework.Presentations.Views.Types;
using Sources.Scripts.UIFramework.ServicesInterfaces.Forms;

namespace Sources.Scripts.Infrastructure.Factories.Views.SceneViewFactories.MainMenu
{
    public abstract class LoadMainMenuSceneServiceBase : ILoadSceneService
    {
        private readonly MainMenuHud _mainMenuHud;
        private readonly LevelAvailabilityViewFactory _levelAvailabilityViewFactory;
        private readonly VolumeViewFactory _volumeViewFactory;
        private readonly InventoryGridViewFactory _inventoryGridViewFactory;
        private readonly IVolumeService _volumeService;
        private readonly UICollectorFactory _uiCollectorFactory;
        private readonly IFormService _formService;
        private readonly ITutorialService _tutorialService;
        private readonly IInventoryTankSpawnerService _inventoryTankSpawnerService;
        private readonly MainMenuPlayerViewFactory _playerViewFactory;
        
        protected LoadMainMenuSceneServiceBase(
            MainMenuHud mainMenuHud,
            LevelAvailabilityViewFactory levelAvailabilityViewFactory,
            VolumeViewFactory volumeViewFactory,
            InventoryGridViewFactory inventoryGridViewFactory,
            IVolumeService volumeService,
            UICollectorFactory uiCollectorFactory,
            IFormService formService,
            ITutorialService tutorialService,
            IInventoryTankSpawnerService inventoryTankSpawnerService,
            MainMenuPlayerViewFactory playerViewFactory)
        {
            _mainMenuHud = mainMenuHud ? mainMenuHud : throw new ArgumentNullException(nameof(mainMenuHud));
            _levelAvailabilityViewFactory = levelAvailabilityViewFactory ?? 
                                            throw new ArgumentNullException(nameof(levelAvailabilityViewFactory));
            _volumeViewFactory = volumeViewFactory ?? throw new ArgumentNullException(nameof(volumeViewFactory));
            _inventoryGridViewFactory = inventoryGridViewFactory ??
                                        throw new ArgumentNullException(nameof(inventoryGridViewFactory));
            _volumeService = volumeService ?? throw new ArgumentNullException(nameof(volumeService));
            _uiCollectorFactory = uiCollectorFactory ?? throw new ArgumentNullException(nameof(uiCollectorFactory));
            _tutorialService = tutorialService ?? throw new ArgumentNullException(nameof(tutorialService));
            _inventoryTankSpawnerService = inventoryTankSpawnerService ??
                                           throw new ArgumentNullException(nameof(inventoryTankSpawnerService));
            _playerViewFactory = playerViewFactory ?? throw new ArgumentNullException(nameof(playerViewFactory));
            _formService = formService ?? throw new ArgumentNullException(nameof(formService));
        }
        
        public void Load(IScenePayload scenePayload)
        {
            MainMenuModels models = LoadModels(scenePayload);
            
            SavedLevel savedLevel = models.SavedLevel;
            
            _volumeViewFactory.Create(models.Volume, _mainMenuHud.VolumeView);
            _volumeService.Register(models.Volume);
            
            PlayerView playerView = _playerViewFactory.Create(models.Player);
            
            _levelAvailabilityViewFactory.Create(models.LevelAvailability, _mainMenuHud.LevelAvailabilityView);
            
            _inventoryGridViewFactory.Create(_mainMenuHud.InventoryGridView, models.InventoryGrid);
            _inventoryTankSpawnerService.AddSlots(_mainMenuHud.InventoryGridView.Slots);
            
            _uiCollectorFactory.Create();
            _tutorialService.Construct(models.Tutorial, savedLevel);
            _formService.Show(FormId.Hud);
        }
        
        protected abstract MainMenuModels LoadModels(IScenePayload scenePayload);
    }
}