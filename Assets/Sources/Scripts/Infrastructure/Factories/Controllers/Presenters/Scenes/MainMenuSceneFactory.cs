using System;
using Cysharp.Threading.Tasks;
using JetBrains.Annotations;
using Sources.Scripts.Controllers.Presenters.Scenes;
using Sources.Scripts.ControllersInterfaces.Scenes;
using Sources.Scripts.Domain.Models.Data.Ids;
using Sources.Scripts.Infrastructure.Factories.Views.SceneViewFactories.MainMenu;
using Sources.Scripts.InfrastructureInterfaces.Factories.Controllers.Scenes;
using Sources.Scripts.InfrastructureInterfaces.Factories.Views.SceneViewFactories;
using Sources.Scripts.InfrastructureInterfaces.Services.Audio;
using Sources.Scripts.InfrastructureInterfaces.Services.LoadServices;
using Sources.Scripts.InfrastructureInterfaces.Services.Spawners;
using Sources.Scripts.InfrastructureInterfaces.Services.Tutorials;
using Sources.Scripts.InfrastructureInterfaces.Services.Yandex;
using Sources.Scripts.Presentations.UI.Curtain;
using Sources.Scripts.UIFramework.ControllerInterfaces.Signals;
using Sources.Scripts.UIFramework.ServicesInterfaces.AudioSources;
using Sources.Scripts.UIFramework.ServicesInterfaces.Focus;

namespace Sources.Scripts.Infrastructure.Factories.Controllers.Presenters.Scenes
{
    public class MainMenuSceneFactory : ISceneFactory
    {
        private readonly CreateMainMenuSceneService _createMainMenuSceneService;
        private readonly LoadMainMenuSceneService _loadMainMenuSceneService;
        private readonly IVolumeService _volumeService;
        private readonly ILoadService _loadService;
        private readonly IStickyAdService _stickyAdService;
        private readonly IAudioService _audioService;
        private readonly IPlayerSpawnerService _playerSpawnerService;
        private readonly IFocusService _focusService;
        private readonly ITutorialService _tutorialService;
        private readonly ISDKInitializeService _sdkInitializeService;
        private readonly ISignalController _signalController;
        private readonly LoadingCurtainView _curtainView;

        public MainMenuSceneFactory(
            CreateMainMenuSceneService createMainMenuSceneService,
            LoadMainMenuSceneService loadMainMenuSceneService,
            IVolumeService volumeService,
            ILoadService loadService,
            LoadingCurtainView curtainView,
            IStickyAdService stickyAdService,
            IAudioService audioService,
            IPlayerSpawnerService playerSpawnerService,
            ITutorialService tutorialService,
            ISDKInitializeService sdkInitializeService,
            ISignalController signalController,
            IFocusService focusService)
        {
            _createMainMenuSceneService = createMainMenuSceneService ?? 
                                          throw new ArgumentNullException(nameof(createMainMenuSceneService));
            _loadMainMenuSceneService = loadMainMenuSceneService ?? 
                                        throw new ArgumentNullException(nameof(loadMainMenuSceneService));
            _volumeService = volumeService ?? throw new ArgumentNullException(nameof(volumeService));
            _loadService = loadService ?? throw new ArgumentNullException(nameof(loadService));
            _stickyAdService = stickyAdService ?? throw new ArgumentNullException(nameof(stickyAdService));
            _audioService = audioService ?? throw new ArgumentNullException(nameof(audioService));
            _playerSpawnerService = playerSpawnerService ?? throw new ArgumentNullException(nameof(playerSpawnerService));
            _tutorialService = tutorialService ?? throw new ArgumentNullException(nameof(tutorialService));
            _sdkInitializeService = sdkInitializeService ?? throw new ArgumentNullException(nameof(sdkInitializeService));
            _signalController = signalController ?? throw new ArgumentNullException(nameof(signalController));
            _focusService = focusService ?? throw new ArgumentNullException(nameof(focusService));
            _curtainView = curtainView ? curtainView : throw new ArgumentNullException(nameof(curtainView));
        }
        
        public async UniTask<IScene> Create(object payload)
        {
            return new MainMenuScene(
                CreateLoadSceneService(payload),
                _volumeService,
                _curtainView,
                _stickyAdService,
                _audioService,
                _playerSpawnerService,
                _tutorialService,
                _sdkInitializeService,
                _signalController,
                _focusService);
        }
        
        private ILoadSceneService CreateLoadSceneService(object payload)
        {
            if (_loadService.HasKey(ModelId.GameData) == false)
                return _createMainMenuSceneService;

            return _loadMainMenuSceneService;
        }
    }
}