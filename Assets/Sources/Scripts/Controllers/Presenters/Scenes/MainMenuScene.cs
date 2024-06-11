using System;
using Cysharp.Threading.Tasks;
using Sources.Scripts.ControllersInterfaces.Scenes;
using Sources.Scripts.DomainInterfaces.Models.Payloads;
using Sources.Scripts.InfrastructureInterfaces.Factories.Views.SceneViewFactories;
using Sources.Scripts.InfrastructureInterfaces.Services.Audio;
using Sources.Scripts.InfrastructureInterfaces.Services.Tutorials;
using Sources.Scripts.Presentations.UI.Curtain;
using Sources.Scripts.UIFramework.ServicesInterfaces.AudioSources;
using Sources.Scripts.UIFramework.ServicesInterfaces.Focus;

namespace Sources.Scripts.Controllers.Presenters.Scenes
{
    public class MainMenuScene : IScene
    {
        private readonly ILoadSceneService _loadSceneService;
        private readonly IVolumeService _volumeService;
        //private readonly IStickyService _stickyService;
        private readonly IAudioService _audioService;
        //private readonly IFocusService _focusService;
        private readonly ITutorialService _tutorialService;
        private readonly LoadingCurtainView _curtainView;

        public MainMenuScene(
            ILoadSceneService loadSceneService,
            IVolumeService volumeService,
            LoadingCurtainView curtainView,
            //IStickyService stickyService,
            IAudioService audioService,
            ITutorialService tutorialService)
            //IFocusService focusService)
        {
            _loadSceneService = loadSceneService ?? throw new ArgumentNullException(nameof(loadSceneService));
            _volumeService = volumeService ?? throw new ArgumentNullException(nameof(volumeService));
            //_stickyService = stickyService ?? throw new ArgumentNullException(nameof(stickyService));
            _audioService = audioService ?? throw new ArgumentNullException(nameof(audioService));
            //_focusService = focusService ?? throw new ArgumentNullException(nameof(focusService));
            _tutorialService = tutorialService ?? throw new ArgumentNullException(nameof(tutorialService));
            _curtainView = curtainView ? curtainView : throw new ArgumentNullException(nameof(curtainView));
        }

        public async void Enter(object payload = null)
        {
            await Initialize(payload as IScenePayload);
            //_focusService.Enable();
            _loadSceneService.Load(payload as IScenePayload);
            _volumeService.Enter();
            _audioService.Enter();
            await _curtainView.HideCurtain();
            await GameReady(payload as IScenePayload);
            _tutorialService.Enable();
        }

        public void Exit()
        {
            //_focusService.Disable();
            _volumeService.Exit();
            _audioService.Exit();
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
            //можно добавить инициализацию магазина сюда
        }

        private UniTask GameReady(IScenePayload payload)
        {
            if (payload.CanFromGameplay)
                return UniTask.CompletedTask;

            //_stickyService.ShowSticky();

            return UniTask.CompletedTask;
        }
    }
}