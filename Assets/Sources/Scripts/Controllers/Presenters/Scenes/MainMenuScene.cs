using System;
using Cysharp.Threading.Tasks;
using Sources.Scripts.ControllersInterfaces.Scenes;
using Sources.Scripts.DomainInterfaces.Models.Payloads;
using Sources.Scripts.InfrastructureInterfaces.Factories.Views.SceneViewFactories;
using Sources.Scripts.InfrastructureInterfaces.Services.Audio;
using Sources.Scripts.InfrastructureInterfaces.Services.Spawners;
using Sources.Scripts.InfrastructureInterfaces.Services.Tutorials;
using Sources.Scripts.InfrastructureInterfaces.Services.Yandex;
using Sources.Scripts.Presentations.UI.Curtain;
using Sources.Scripts.UIFramework.ControllerInterfaces.Buttons;
using Sources.Scripts.UIFramework.ServicesInterfaces.AudioSources;
using Sources.Scripts.UIFramework.ServicesInterfaces.Focus;
using UnityEngine;

namespace Sources.Scripts.Controllers.Presenters.Scenes
{
    public class MainMenuScene : IScene
    {
        private readonly ILoadSceneService _loadSceneService;
        private readonly IVolumeService _volumeService;
        private readonly IStickyAdService _stickyAdService;
        private readonly IAudioService _audioService;
        private readonly IPlayerSpawnerService _playerSpawnerService;
        private readonly IFocusService _focusService;
        private readonly ITutorialService _tutorialService;
        private readonly ISDKInitializeService _sdkInitializeService;
        private readonly IButtonSignalController _buttonSignalController;
        private readonly LoadingCurtainView _curtainView;

        public MainMenuScene(
            ILoadSceneService loadSceneService,
            IVolumeService volumeService,
            LoadingCurtainView curtainView,
            IStickyAdService stickyAdService,
            IAudioService audioService,
            IPlayerSpawnerService playerSpawnerService,
            ITutorialService tutorialService,
            ISDKInitializeService sdkInitializeService,
            IButtonSignalController buttonSignalController,
            IFocusService focusService)
        {
            _loadSceneService = loadSceneService ?? throw new ArgumentNullException(nameof(loadSceneService));
            _volumeService = volumeService ?? throw new ArgumentNullException(nameof(volumeService));
            _stickyAdService = stickyAdService ?? throw new ArgumentNullException(nameof(stickyAdService));
            _audioService = audioService ?? throw new ArgumentNullException(nameof(audioService));
            _playerSpawnerService = playerSpawnerService ?? throw new ArgumentNullException(nameof(playerSpawnerService));
            _focusService = focusService ?? throw new ArgumentNullException(nameof(focusService));
            _tutorialService = tutorialService ?? throw new ArgumentNullException(nameof(tutorialService));
            _sdkInitializeService = sdkInitializeService ?? throw new ArgumentNullException(nameof(sdkInitializeService));
            _buttonSignalController = buttonSignalController ?? throw new ArgumentNullException(nameof(buttonSignalController));
            _curtainView = curtainView ? curtainView : throw new ArgumentNullException(nameof(curtainView));
        }

        public async void Enter(object payload = null)
        {
            await Initialize(payload as IScenePayload);
            _focusService.Enable();
            _loadSceneService.Load(payload as IScenePayload);
            _volumeService.Enter();
            _audioService.Enter();
            _buttonSignalController.Initialize();
            _playerSpawnerService.Enable();
            await _curtainView.HideCurtain();
            await GameReady(payload as IScenePayload);
            _tutorialService.Enable();
        }

        public void Exit()
        {
            _focusService.Disable();
            _playerSpawnerService.Disable();
            _volumeService.Exit();
            _audioService.Exit();
            _buttonSignalController.Destroy();
        }

        public void Update(float deltaTime)
        {
        }

        public void UpdateLate(float deltaTime)
        {
        }

        public void UpdateFixed(float fixedDeltaTime)
        {
        }

        private async UniTask Initialize(IScenePayload payload)
        {
            if (payload.CanFromGameplay)
                return;
            
            _sdkInitializeService.EnableCallbackLogging();
            await _sdkInitializeService.Initialize();
            //можно добавить инициализацию магазина сюда
        }

        private UniTask GameReady(IScenePayload payload)
        {
            if (payload.CanFromGameplay)
                return UniTask.CompletedTask;

            //_stickyAdService.ShowStickyAd();
            _sdkInitializeService.GameReady();

            return UniTask.CompletedTask;
        }
    }
}