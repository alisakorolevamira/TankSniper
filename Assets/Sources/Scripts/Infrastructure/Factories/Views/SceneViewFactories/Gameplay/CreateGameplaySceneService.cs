﻿using System;
using System.Collections.Generic;
using Sources.Scripts.Domain.Models.Common;
using Sources.Scripts.Domain.Models.Constants;
using Sources.Scripts.Domain.Models.Data.Ids;
using Sources.Scripts.Domain.Models.Gameplay;
using Sources.Scripts.Domain.Models.Players;
using Sources.Scripts.Domain.Models.Settings;
using Sources.Scripts.Domain.Models.Spawners;
using Sources.Scripts.Domain.Models.Upgrades;
using Sources.Scripts.Domain.Models.Weapons;
using Sources.Scripts.DomainInterfaces.Models.Payloads;
using Sources.Scripts.Infrastructure.Factories.Views.Cameras;
using Sources.Scripts.Infrastructure.Factories.Views.Gameplay;
using Sources.Scripts.Infrastructure.Factories.Views.Players;
using Sources.Scripts.Infrastructure.Factories.Views.Settings;
using Sources.Scripts.Infrastructure.Factories.Views.Spawners;
using Sources.Scripts.Infrastructure.Factories.Views.Weapons;
using Sources.Scripts.InfrastructureInterfaces.Services.Audio;
using Sources.Scripts.InfrastructureInterfaces.Services.Cameras;
using Sources.Scripts.InfrastructureInterfaces.Services.GameOver;
using Sources.Scripts.InfrastructureInterfaces.Services.LevelCompleted;
using Sources.Scripts.InfrastructureInterfaces.Services.LoadServices;
using Sources.Scripts.InfrastructureInterfaces.Services.Repositories;
using Sources.Scripts.InfrastructureInterfaces.Services.Saves;
using Sources.Scripts.InfrastructureInterfaces.Services.Shop;
using Sources.Scripts.Presentations.UI.Huds;
using Sources.Scripts.Presentations.Views.Players.Skins.DecalsType;
using Sources.Scripts.Presentations.Views.Players.Skins.MaterialTypes;
using Sources.Scripts.Presentations.Views.Players.Skins.SkinTypes;
using Sources.Scripts.Presentations.Views.RootGameObjects;

namespace Sources.Scripts.Infrastructure.Factories.Views.SceneViewFactories.Gameplay
{
    public class CreateGameplaySceneService : LoadGameplaySceneServiceBase
    {
        private readonly ILoadService _loadService;
        private readonly IEntityRepository _entityRepository;

        public CreateGameplaySceneService(
            GameplayHud gameplayHud,
            GameplayRootGameObject gameplayRootGameObject,
            IEntityRepository entityRepository,
            PlayerViewFactory playerViewFactory,
            EnemySpawnerViewFactory enemySpawnerViewFactory,
            KilledEnemiesCounterViewFactory killedEnemiesCounterViewFactory,
            ReloadWeaponViewFactory reloadWeaponViewFactory,
            CameraViewFactory cameraViewFactory,
            VolumeViewFactory volumeViewFactory,
            RewardViewFactory rewardViewFactory,
            SkinChangerViewFactory skinChangerViewFactory,
            IGameOverService gameOverService,
            ICameraService cameraService,
            IVolumeService volumeService,
            ISaveService saveService,
            ILoadService loadService,
            ISkinChangerService skinChangerService,
            ILevelCompletedService levelCompletedService)
            //IAdvertisingService advertisingService,
            : base(
                gameplayHud,
                gameplayRootGameObject,
                playerViewFactory,
                enemySpawnerViewFactory,
                killedEnemiesCounterViewFactory,
                reloadWeaponViewFactory,
                cameraViewFactory,
                volumeViewFactory,
                rewardViewFactory,
                skinChangerViewFactory,
                gameOverService,
                cameraService,
                volumeService,
                saveService,
                skinChangerService,
                levelCompletedService)
                //advertisingService,
        {
            _loadService = loadService;
            _entityRepository = entityRepository ?? throw new ArgumentNullException(nameof(entityRepository));
        }

        protected override GameModels LoadModels(IScenePayload scenePayload)
        {
            Volume volume = CreateVolume();

            //Level level = CreateLevel(scenePayload.SceneId);

            GameLevels gameLevels = CreateGamelevels();
            Level level = gameLevels.Levels.Find(level => level.Id == scenePayload.SceneId);

            SavedLevel savedLevel = new SavedLevel(ModelId.SavedLevel, scenePayload.SceneId);
            _entityRepository.Add(savedLevel);

            PlayerWallet playerWallet = new PlayerWallet(PlayerConst.DefaultMoney, ModelId.PlayerWallet);
            _entityRepository.Add(playerWallet);

            KilledEnemiesCounter killedEnemiesCounter = new KilledEnemiesCounter();

            EnemySpawner enemySpawner = new EnemySpawner();
            
            CharacterHealth characterHealth = new CharacterHealth();

            Weapon weapon = new Weapon(PlayerConst.Damage);

            Upgrader upgrader = new Upgrader(PlayerConst.DefaultLevel, ModelId.Upgrader);
            _entityRepository.Add(upgrader);

            SkinChanger skinChanger =
                new SkinChanger(SkinType.First, MaterialType.Default, DecalType.Default, ModelId.SkinChanger);
            _entityRepository.Add(skinChanger);
            
            PlayerAttacker playerAttacker = new PlayerAttacker(weapon); //переделать
            
            GameplayPlayer player = new GameplayPlayer(playerWallet, characterHealth, playerAttacker, weapon);

            return new GameModels(
                characterHealth,
                playerWallet,
                playerAttacker,
                volume,
                level,
                player,
                killedEnemiesCounter,
                enemySpawner,
                upgrader,
                skinChanger,
                savedLevel);
        }

        private Volume CreateVolume()
        {
            if (_loadService.HasKey(ModelId.Volume))
                return _loadService.Load<Volume>(ModelId.Volume);

            Volume volume = new Volume(VolumeConst.BaseAudioValue, ModelId.Volume);
            _entityRepository.Add(volume);

            return volume;
        }

       // private Level CreateLevel(string sceneId)
       // {
       //     if (_loadService.HasKey(sceneId))
       //         return _loadService.Load<Level>(sceneId);
       //     
       //     Level level = new Level(sceneId, false);
       //     _entityRepository.Add(level);
//
       //     return level;
       // }

        private GameLevels CreateGamelevels()
        {
            if (_loadService.HasKey(ModelId.GameLevels))
                return _loadService.Load<GameLevels>(ModelId.GameLevels);
            
            GameLevels gameLevels = new GameLevels(ModelId.GameLevels, new List<Level>()
            {
                new (ModelId.FirstLevel, false),
                new (ModelId.SecondLevel, false),
                new (ModelId.ThirdLevel, false),
                new (ModelId.FourthLevel, false),
                new (ModelId.FifthLevel, false),
                new (ModelId.SixthLevel, false),
            });
            
            _entityRepository.Add(gameLevels);

            return gameLevels;
        }
    }
}