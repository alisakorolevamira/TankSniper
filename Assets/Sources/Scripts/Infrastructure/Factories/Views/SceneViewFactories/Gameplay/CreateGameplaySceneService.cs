﻿using System;
using System.Collections.Generic;
using Sources.Scripts.Domain.Models.Data;
using Sources.Scripts.Domain.Models.Data.Ids;
using Sources.Scripts.Domain.Models.Gameplay;
using Sources.Scripts.Domain.Models.Players;
using Sources.Scripts.Domain.Models.Settings;
using Sources.Scripts.Domain.Models.Upgrades;
using Sources.Scripts.DomainInterfaces.Models.Payloads;
using Sources.Scripts.Infrastructure.Factories.Views.Cameras;
using Sources.Scripts.Infrastructure.Factories.Views.Settings;
using Sources.Scripts.InfrastructureInterfaces.Factories.Domain.Data;
using Sources.Scripts.InfrastructureInterfaces.Services.Cameras;
using Sources.Scripts.InfrastructureInterfaces.Services.LoadServices;
using Sources.Scripts.InfrastructureInterfaces.Services.Repositories;
using Sources.Scripts.InfrastructureInterfaces.Services.Tutorials;
using Sources.Scripts.InfrastructureInterfaces.Services.Volumes;
using Sources.Scripts.Presentations.Views.RootGameObjects;
using Sources.Scripts.UIFramework.Infrastructure.Factories.Services.Collectors;
using Sources.Scripts.UIFramework.ServicesInterfaces.Forms;
using UnityEngine.TextCore.Text;

namespace Sources.Scripts.Infrastructure.Factories.Views.SceneViewFactories.Gameplay
{
    public class CreateGameplaySceneService : LoadGameplaySceneServiceBase
    {
        private readonly ILoadService _loadService;
        private readonly IEntityRepository _entityRepository;
        private readonly IUpgradeDtoMapper _upgradeDtoMapper;
        //private readonly IEnemySpawnerDtoMapper _enemySpawnerDtoMapper;

        public CreateGameplaySceneService(
            //GameplayHud gameplayHud,
            UICollectorFactory uiCollectorFactory,
            //CharacterViewFactory characterViewFactory,
            ILoadService loadService,
            IEntityRepository entityRepository,
            RootGameObject rootGameObject,
            //EnemySpawnViewFactory enemySpawnViewFactory,
            //ItemSpawnerViewFactory itemSpawnerViewFactory,
            IUpgradeDtoMapper upgradeDtoMapper,
            //CustomCollection<Upgrader> upgradeCollection,
            //KillEnemyCounterViewFactory killEnemyCounterViewFactory,
            //BackgroundMusicViewFactory backgroundMusicViewFactory,
            //IGameOverService gameOverService,
            CameraViewFactory cameraViewFactory,
            ICameraService cameraService,
            VolumeViewFactory volumeViewFactory,
            IVolumeService volumeService,
            //ISaveService saveService,
            //ILevelCompletedService levelCompletedService,
            ITutorialService tutorialService,
            //IEnemySpawnerDtoMapper enemySpawnerDtoMapper,
            //IAdvertisingService advertisingService,
            IFormService formService)
            : base(
                //gameplayHud,
                uiCollectorFactory,
                //characterViewFactory,
                rootGameObject,
                //enemySpawnViewFactory,
                //itemSpawnerViewFactory,
                //upgradeCollection,
                //killEnemyCounterViewFactory,
                //backgroundMusicViewFactory,
                //gameOverService,
                cameraViewFactory,
                cameraService,
                volumeViewFactory,
                volumeService,
                //saveService,
                //levelCompletedService,
                //tutorialService,
                //advertisingService,
                formService)
        {
            _loadService = loadService;
            _entityRepository = entityRepository ?? throw new ArgumentNullException(nameof(entityRepository));
            _upgradeDtoMapper = upgradeDtoMapper ?? throw new ArgumentNullException(nameof(upgradeDtoMapper));
        }

        protected override GameModels LoadModels(IScenePayload scenePayload)
        {
            Volume volume = CreateVolume();

            Level level = CreateLevel(scenePayload.SceneId);

            CurrentLevel currentLevel = new CurrentLevel(
                ModelId.CurrentLevel, scenePayload.SceneId);
            _entityRepository.Add(currentLevel);

            PlayerWallet playerWallet = new PlayerWallet(0, ModelId.PlayerWallet);
            _entityRepository.Add(playerWallet);

            //KillEnemyCounter killEnemyCounter = new KillEnemyCounter(ModelId.KillEnemyCounter, 0);
            //_entityRepository.Add(killEnemyCounter);

            //EnemySpawner enemySpawner = CreateEnemySpawner(scenePayload.SceneId);
            
            //CharacterHealth characterHealth = new CharacterHealth(characterHealthUpgrader);
            //Character character = new Character(
            //    playerWallet,
            //    characterHealth,
            //    new CharacterMovement(),
            //    new CharacterAttacker(minigun),
            //    minigun,
            //    new SawLauncherAbility(sawLauncherAbilityUpgrader),
            //    new List<SawLauncher>()
            //    {
            //        new SawLauncher(sawLauncherUpgrader),
            //        new SawLauncher(sawLauncherUpgrader),
            //        new SawLauncher(sawLauncherUpgrader),
            //        new SawLauncher(sawLauncherUpgrader),
            //    });

            return new GameModels(
                playerWallet,
                volume,
                level,
                currentLevel);
        }

        //private ScoreCounter CreateScoreCounter()
        //{
        //    
        //    if (_loadService.HasKey(ModelId.ScoreCounter))
        //        return _loadService.Load<ScoreCounter>(ModelId.ScoreCounter);
//
        //    ScoreCounter scoreCounter = new ScoreCounter(0, ModelId.ScoreCounter);
        //    _entityRepository.Add(scoreCounter);
        //    
        //    return scoreCounter;
        //}

        //private Upgrader CreateUpgrader(string id)
        //{
        //    UpgradeDto upgradeDto = _upgradeDtoMapper.MapIdToDto(id);
        //    Upgrader upgrader = _upgradeDtoMapper.MapDtoToModel(upgradeDto);
        //    _entityRepository.Add(upgrader);
        //    _upgradeCollection.Add(upgrader);
//
        //    return upgrader;
        //}

        //private EnemySpawner CreateEnemySpawner(string sceneId)
        //{
        //    EnemySpawnerDto enemySpawnerDto = _enemySpawnerDtoMapper.MapIdToDto(sceneId);
        //    EnemySpawner enemySpawner = _enemySpawnerDtoMapper.MapDtoToModel(enemySpawnerDto);
        //    _entityRepository.Add(enemySpawner);
//
        //    return enemySpawner;
        //}

        //private Tutorial CreateTutorial() перенести в мейн меню
        //{
        //    if (_loadService.HasKey(ModelId.Tutorial))
        //        return _loadService.Load<Tutorial>(ModelId.Tutorial);
//
        //    Tutorial tutorial = new Tutorial();
        //    _entityRepository.Add(tutorial);
//
        //    return tutorial;
        //}

        private Volume CreateVolume()
        {
            if (_loadService.HasKey(ModelId.Volume))
                return _loadService.Load<Volume>(ModelId.Volume);

            Volume volume = new Volume();
            _entityRepository.Add(volume);

            return volume;
        }

        private Level CreateLevel(string sceneId)
        {
            if (_loadService.HasKey(sceneId))
                return _loadService.Load<Level>(sceneId);
            
            Level level = new Level(sceneId, false);
            _entityRepository.Add(level);

            return level;
        }
    }
}