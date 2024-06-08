using System;
using Cysharp.Threading.Tasks;
using Sources.Scripts.Controllers.Presenters.Scenes;
using Sources.Scripts.ControllersInterfaces.Scenes;
using Sources.Scripts.DomainInterfaces.Models.Payloads;
using Sources.Scripts.Infrastructure.Factories.Views.SceneViewFactories.Gameplay;
using Sources.Scripts.InfrastructureInterfaces.Factories.Controllers.Scenes;
using Sources.Scripts.InfrastructureInterfaces.Factories.Views.SceneViewFactories;
using Sources.Scripts.InfrastructureInterfaces.Services.Tutorials;
using Sources.Scripts.InfrastructureInterfaces.Services.Volumes;

namespace Sources.Scripts.Infrastructure.Factories.Controllers.Presenters.Scenes
{
    public class GameplaySceneFactory : ISceneFactory
    {
        //private readonly IUpdateService _updateService;
        //private readonly IInputServiceUpdater _inputServiceUpdater;
        //private readonly ILocalizationService _localizationService;
        //private readonly IGameOverService _gameOverService;
        private readonly IVolumeService _volumeService;
        private readonly LoadGameplaySceneService _loadGameplaySceneService;
        private readonly CreateGameplaySceneService _createGameplaySceneService;
        //private readonly ISaveService _saveService;
        //private readonly ILevelCompletedService _levelCompletedService;
        private readonly ITutorialService _tutorialService;
        //private readonly CustomCollection<IEnemyView> _enemyCollection;
        //private readonly IAudioService _audioService;
        //private readonly IFocusService _focusService;
        //private readonly IAdvertisingService _advertisingService;
        //private readonly CurtainView _curtainView;

        public GameplaySceneFactory(
            //IUpdateService updateService,
            //IInputServiceUpdater inputServiceUpdater,
            //ILocalizationService localizationService,
            //IGameOverService gameOverService,
            IVolumeService volumeService,
            LoadGameplaySceneService loadGameplaySceneService,
            CreateGameplaySceneService createGameplaySceneService,
            //ISaveService saveService,
            //ILevelCompletedService levelCompletedService,
            ITutorialService tutorialService)
            //CustomCollection<IEnemyView> enemyCollection,
            //CurtainView curtainView,
            //IAudioService audioService,
            //IFocusService focusService,
            //IAdvertisingService advertisingService) 
        {
            //_updateService = updateService ?? throw new ArgumentNullException(nameof(updateService));
            //_inputServiceUpdater = inputServiceUpdater ?? throw new ArgumentNullException(nameof(inputServiceUpdater));
            //_localizationService = localizationService ?? throw new ArgumentNullException(nameof(localizationService));
            //_gameOverService = gameOverService ?? throw new ArgumentNullException(nameof(gameOverService));
            _volumeService = volumeService ?? throw new ArgumentNullException(nameof(volumeService));
            _loadGameplaySceneService = loadGameplaySceneService ?? 
                                        throw new ArgumentNullException(nameof(loadGameplaySceneService));
            _createGameplaySceneService = createGameplaySceneService ?? 
                                          throw new ArgumentNullException(nameof(createGameplaySceneService));
            //_saveService = saveService ?? throw new ArgumentNullException(nameof(saveService));
            //_levelCompletedService = levelCompletedService ?? 
              //                       throw new ArgumentNullException(nameof(levelCompletedService));
            _tutorialService = tutorialService ?? throw new ArgumentNullException(nameof(tutorialService));
            //_enemyCollection = enemyCollection ?? throw new ArgumentNullException(nameof(enemyCollection));
            //_audioService = audioService ?? throw new ArgumentNullException(nameof(audioService));
            //_focusService = focusService ?? throw new ArgumentNullException(nameof(focusService));
            //_advertisingService = advertisingService ?? throw new ArgumentNullException(nameof(advertisingService));
            //_curtainView = curtainView ? curtainView : throw new ArgumentNullException(nameof(curtainView));
        }

        public async UniTask<IScene> Create(object payload)
        {
            return new GameplayScene(
                //_updateService,
                //_inputServiceUpdater,
                CreateLoadSceneService(payload),
                //_localizationService,
                //_gameOverService,
                _volumeService,
                //_saveService,
                //_levelCompletedService,
                _tutorialService);
            //_enemyCollection,
            //_curtainView,
            //_audioService,
            //_focusService,
            //_advertisingService);
        }

        private ILoadSceneService CreateLoadSceneService(object payload)
        {
            if (payload == null)
                return _createGameplaySceneService;

            var canLoad = payload is IScenePayload { CanLoad : true };

            if (canLoad == false)
                return _createGameplaySceneService;

            return _loadGameplaySceneService;
        }
    }
}