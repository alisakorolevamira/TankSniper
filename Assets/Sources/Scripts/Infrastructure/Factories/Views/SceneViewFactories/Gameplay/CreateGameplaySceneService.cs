using System;
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
using Sources.Scripts.InfrastructureInterfaces.Factories.Domain.Data;
using Sources.Scripts.InfrastructureInterfaces.Services.Audio;
using Sources.Scripts.InfrastructureInterfaces.Services.Cameras;
using Sources.Scripts.InfrastructureInterfaces.Services.GameOver;
using Sources.Scripts.InfrastructureInterfaces.Services.LevelCompleted;
using Sources.Scripts.InfrastructureInterfaces.Services.LoadServices;
using Sources.Scripts.InfrastructureInterfaces.Services.Repositories;
using Sources.Scripts.InfrastructureInterfaces.Services.Saves;
using Sources.Scripts.InfrastructureInterfaces.Services.Tutorials;
using Sources.Scripts.Presentations.UI.Huds;
using Sources.Scripts.Presentations.Views.RootGameObjects;
using Sources.Scripts.UIFramework.Infrastructure.Factories.Services.Collectors;
using Sources.Scripts.UIFramework.ServicesInterfaces.Forms;

namespace Sources.Scripts.Infrastructure.Factories.Views.SceneViewFactories.Gameplay
{
    public class CreateGameplaySceneService : LoadGameplaySceneServiceBase
    {
        private readonly ILoadService _loadService;
        private readonly IEntityRepository _entityRepository;
        //private readonly IUpgradeDtoMapper _upgradeDtoMapper;
        //private readonly IEnemySpawnerDtoMapper _enemySpawnerDtoMapper;

        public CreateGameplaySceneService(
            GameplayHud gameplayHud,
            UICollectorFactory uiCollectorFactory,
            PlayerViewFactory playerViewFactory,
            PlayerAttackerViewFactory playerAttackerViewFactory,
            ILoadService loadService,
            IEntityRepository entityRepository,
            GameplayRootGameObject gameplayRootGameObject,
            EnemySpawnerViewFactory enemySpawnerViewFactory,
            //IUpgradeDtoMapper upgradeDtoMapper,
            //CustomCollection<Upgrader> upgradeCollection,
            KilledEnemiesCounterViewFactory killedEnemiesCounterViewFactory,
            ReloadWeaponViewFactory reloadWeaponViewFactory,
            IGameOverService gameOverService,
            CameraViewFactory cameraViewFactory,
            ICameraService cameraService,
            VolumeViewFactory volumeViewFactory,
            IVolumeService volumeService,
            ISaveService saveService,
            ILevelCompletedService levelCompletedService,
            //IEnemySpawnerDtoMapper enemySpawnerDtoMapper,
            //IAdvertisingService advertisingService,
            IFormService formService)
            : base(
                gameplayHud,
                uiCollectorFactory,
                playerViewFactory,
                playerAttackerViewFactory,
                gameplayRootGameObject,
                enemySpawnerViewFactory,
                //upgradeCollection,
                killedEnemiesCounterViewFactory,
                reloadWeaponViewFactory,
                //backgroundMusicViewFactory,
                gameOverService,
                cameraViewFactory,
                cameraService,
                volumeViewFactory,
                volumeService,
                saveService,
                levelCompletedService,
                //advertisingService,
                formService)
        {
            _loadService = loadService;
            _entityRepository = entityRepository ?? throw new ArgumentNullException(nameof(entityRepository));
            //_upgradeDtoMapper = upgradeDtoMapper ?? throw new ArgumentNullException(nameof(upgradeDtoMapper));
        }

        protected override GameModels LoadModels(IScenePayload scenePayload)
        {
            Volume volume = CreateVolume();

            Level level = CreateLevel(scenePayload.SceneId);

            SavedLevel savedLevel = new SavedLevel(
                ModelId.SavedLevel, scenePayload.SceneId);
            _entityRepository.Add(savedLevel);

            PlayerWallet playerWallet = new PlayerWallet(0, ModelId.PlayerWallet);
            _entityRepository.Add(playerWallet);

            KilledEnemiesCounter killedEnemiesCounter = new KilledEnemiesCounter();

            EnemySpawner enemySpawner = new EnemySpawner();
            
            CharacterHealth characterHealth = new CharacterHealth();

            Weapon weapon = new Weapon(PlayerConst.Damage);

            Upgrader upgrader = new Upgrader(1, ModelId.Upgrader);
            
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
                savedLevel);
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

        private EnemySpawner CreateEnemySpawner(string sceneId)
        {
            //EnemySpawnerDto enemySpawnerDto = _enemySpawnerDtoMapper.MapIdToDto(sceneId);
            //EnemySpawner enemySpawner = _enemySpawnerDtoMapper.MapDtoToModel(enemySpawnerDto);
            //_entityRepository.Add(enemySpawner);
            EnemySpawner enemySpawner = new();

            return enemySpawner;
        }

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

            Volume volume = new Volume(VolumeConst.BaseAudioValue, ModelId.Volume);
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