using System;
using Cysharp.Threading.Tasks;
using Sources.Scripts.ControllersInterfaces.Scenes;
using Sources.Scripts.DomainInterfaces.Models.Payloads;
using Sources.Scripts.InfrastructureInterfaces.Factories.Views.SceneViewFactories;
using Sources.Scripts.InfrastructureInterfaces.Services.Audio;
using Sources.Scripts.InfrastructureInterfaces.Services.Shop;
using Sources.Scripts.InfrastructureInterfaces.Services.Tutorials;
using Sources.Scripts.InfrastructureInterfaces.Services.Yandex;
using Sources.Scripts.Presentations.UI.Curtain;
using Sources.Scripts.UIFramework.ControllerInterfaces.Buttons;
using Sources.Scripts.UIFramework.ControllerInterfaces.Shop;
using Sources.Scripts.UIFramework.ServicesInterfaces.AudioSources;
using Sources.Scripts.UIFramework.ServicesInterfaces.Focus;

namespace Sources.Scripts.Controllers.Presenters.Scenes
{
    public class MainMenuScene : IScene
    {
        private readonly ILoadSceneService _loadSceneService;
        private readonly IVolumeService _volumeService;
        private readonly IInterstitialAdService interstitialAdService;
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
            IInterstitialAdService interstitialAdService,
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
            this.interstitialAdService = interstitialAdService ?? throw new ArgumentNullException(nameof(interstitialAdService));
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
            _shopSignalController.Initialize();
            _buttonSignalController.Initialize();
            _volumeService.Enter();
            //_audioService.Enter();
            _skinChangerService.Enable();
            await _curtainView.HideCurtain();
            _tutorialService.Enable();
            await GameReady(payload as IScenePayload);
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
        }

        private UniTask GameReady(IScenePayload payload)
        {
            if (payload.CanFromGameplay)
                return UniTask.CompletedTask;
            
            _sdkInitializeService.GameReady();

            return UniTask.CompletedTask;
        }
    }
}