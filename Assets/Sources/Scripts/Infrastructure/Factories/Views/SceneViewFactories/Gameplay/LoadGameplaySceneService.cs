using System;
using System.Collections.Generic;
using Sources.Scripts.Domain.Models.Data.Ids;
using Sources.Scripts.Domain.Models.Gameplay;
using Sources.Scripts.Domain.Models.Players;
using Sources.Scripts.Domain.Models.Settings;
using Sources.Scripts.Domain.Models.Upgrades;
using Sources.Scripts.DomainInterfaces.Models.Payloads;
using Sources.Scripts.Infrastructure.Factories.Views.Cameras;
using Sources.Scripts.Infrastructure.Factories.Views.Gameplay;
using Sources.Scripts.Infrastructure.Factories.Views.Settings;
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
    public class LoadGameplaySceneService : LoadGameplaySceneServiceBase
    {
        private readonly ILoadService _loadService;
        private readonly IEntityRepository _entityRepository;
        
        public LoadGameplaySceneService(
            GameplayHud gameplayHud, 
            UICollectorFactory uiCollectorFactory, 
            //CharacterViewFactory characterViewFactory, 
            ILoadService loadService, 
            IEntityRepository entityRepository, 
            RootGameObject rootGameObject, 
            //EnemySpawnViewFactory enemySpawnViewFactory, 
            //ItemSpawnerViewFactory itemSpawnerViewFactory, 
            //CustomCollection<Upgrader> upgradeCollection, 
            KilledEnemiesCounterViewFactory killedEnemiesCounterViewFactory, 
            //BackgroundMusicViewFactory backgroundMusicViewFactory, 
            IGameOverService gameOverService, 
            CameraViewFactory cameraViewFactory, 
            ICameraService cameraService, 
            VolumeViewFactory volumeViewFactory, 
            IVolumeService volumeService,
            ISaveService saveService,
            ILevelCompletedService levelCompletedService,
            ITutorialService tutorialService,
            //IAdvertisingService advertisingService,
            IFormService formService) 
            : base(
                gameplayHud, 
                uiCollectorFactory, 
                //characterViewFactory, 
                //bearViewFactory, 
                //upgradeUiFactory, 
                rootGameObject, 
                //enemySpawnViewFactory, 
                //itemSpawnerViewFactory,
                //upgradeCollection, 
                killedEnemiesCounterViewFactory, 
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
            _loadService = loadService ?? throw new ArgumentNullException(nameof(loadService));
            _entityRepository = entityRepository ?? throw new ArgumentNullException(nameof(entityRepository));
        }

        protected override GameModels LoadModels(IScenePayload scenePayload)
        {
            _loadService.LoadAll();
            
            Volume volume = _entityRepository.Get<Volume>(ModelId.Volume);

            Level level = _entityRepository.Get<Level>(scenePayload.SceneId);
            
            CurrentLevel currentLevel = _entityRepository.Get<CurrentLevel>(ModelId.CurrentLevel);
            
            PlayerWallet playerWallet = _entityRepository.Get<PlayerWallet>(ModelId.PlayerWallet);

            //UpgradeController upgradeController = new UpgradeController();
//
            KilledEnemiesCounter killedEnemiesCounter = new KilledEnemiesCounter();
            //EnemySpawner enemySpawner = _entityRepository.Get<EnemySpawner>(ModelId.GameplayEnemySpawner);
//
            //ScoreCounter scoreCounter = _entityRepository.Get<ScoreCounter>(ModelId.ScoreCounter);
            //
            //MiniGun miniGun = new MiniGun(miniGunAttackUpgrader, WeaponConst.AttackCooldown);
//
            PlayerHealth playerHealth = new PlayerHealth();

            //Character character = new Character(
            //    playerWallet,
            //    characterHealth,
            //    new CharacterMovement(),
            //    new CharacterAttacker(miniGun),
            //    miniGun,
            //    new SawLauncherAbility(sawLauncherAbilityUpgrader),
            //    new List<SawLauncher>()
            //    {
            //        new SawLauncher(sawLauncherUpgrader),
            //        new SawLauncher(sawLauncherUpgrader),
            //        new SawLauncher(sawLauncherUpgrader),
            //        new SawLauncher(sawLauncherUpgrader),
            //    });



            return new GameModels(
                playerHealth,
                playerWallet,
                volume,
                level,
                killedEnemiesCounter,
                currentLevel);
        }
    }
}