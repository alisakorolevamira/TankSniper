using System;
using Cysharp.Threading.Tasks;
using JetBrains.Annotations;
using Sources.Scripts.ControllersInterfaces.Scenes;
using Sources.Scripts.DomainInterfaces.Models.Payloads;
using Sources.Scripts.InfrastructureInterfaces.Factories.Views.SceneViewFactories;
using Sources.Scripts.InfrastructureInterfaces.Services.Audio;
using Sources.Scripts.InfrastructureInterfaces.Services.Shop;
using Sources.Scripts.InfrastructureInterfaces.Services.Spawners;
using Sources.Scripts.InfrastructureInterfaces.Services.Tutorials;
using Sources.Scripts.InfrastructureInterfaces.Services.Yandex;
using Sources.Scripts.Presentations.UI.Curtain;
using Sources.Scripts.UIFramework.ControllerInterfaces.Buttons;
using Sources.Scripts.UIFramework.ControllerInterfaces.Shop;
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
        private readonly IFocusService _focusService;
        private readonly ITutorialService _tutorialService;
        private readonly ISDKInitializeService _sdkInitializeService;
        private readonly ISkinChangerService _skinChangerService;
        private readonly IButtonSignalController _buttonSignalController;
        private readonly IShopSignalController _shopSignalController;
        private readonly LoadingCurtainView _curtainView;

        public MainMenuScene(
            ILoadSceneService loadSceneService,
            IVolumeService volumeService,
            LoadingCurtainView curtainView,
            IStickyAdService stickyAdService,
            IAudioService audioService,
            ITutorialService tutorialService,
            ISDKInitializeService sdkInitializeService,
            ISkinChangerService skinChangerService,
            IButtonSignalController buttonSignalController,
            IShopSignalController shopSignalController,
            IFocusService focusService)
        {
            _loadSceneService = loadSceneService ?? throw new ArgumentNullException(nameof(loadSceneService));
            _volumeService = volumeService ?? throw new ArgumentNullException(nameof(volumeService));
            _stickyAdService = stickyAdService ?? throw new ArgumentNullException(nameof(stickyAdService));
            _audioService = audioService ?? throw new ArgumentNullException(nameof(audioService));
            _focusService = focusService ?? throw new ArgumentNullException(nameof(focusService));
            _tutorialService = tutorialService ?? throw new ArgumentNullException(nameof(tutorialService));
            _sdkInitializeService = sdkInitializeService ?? throw new ArgumentNullException(nameof(sdkInitializeService));
            _skinChangerService = skinChangerService ?? throw new ArgumentNullException(nameof(skinChangerService));
            _buttonSignalController = buttonSignalController ?? throw new ArgumentNullException(nameof(buttonSignalController));
            _shopSignalController = shopSignalController ?? throw new ArgumentNullException(nameof(shopSignalController));
            _curtainView = curtainView ? curtainView : throw new ArgumentNullException(nameof(curtainView));
        }

        public async void Enter(object payload = null)
        {
            await Initialize(payload as IScenePayload);
            _focusService.Enable();
            _loadSceneService.Load(payload as IScenePayload);
            _volumeService.Enter();
            _audioService.Enter();
            _skinChangerService.Enable();
            _buttonSignalController.Initialize();
            _shopSignalController.Initialize();
            await _curtainView.HideCurtain();
            await GameReady(payload as IScenePayload);
            _tutorialService.Enable();
        }

        public void Exit()
        {
            _focusService.Disable();
            _volumeService.Exit();
            _audioService.Exit();
            _buttonSignalController.Destroy();
            _shopSignalController.Destroy();
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