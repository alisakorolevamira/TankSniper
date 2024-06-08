using System;
using Sources.Scripts.DomainInterfaces.Models.Players;
using Sources.Scripts.InfrastructureInterfaces.Services.GameOver;
using Sources.Scripts.InfrastructureInterfaces.Services.LoadServices;
using Sources.Scripts.UIFramework.Presentations.Views.Types;
using Sources.Scripts.UIFramework.ServicesInterfaces.Forms;

namespace Sources.Scripts.Infrastructure.Services.GameOver
{
    public class GameOverService : IGameOverService
    {
        private readonly IFormService _formService;
        private readonly ILoadService _loadService;
        //private readonly IInterstitialAdService _interstitialAdService;
        private IPlayerHealth _playerHealth;
        private bool _isGameOver;

        public GameOverService(
            IFormService formService,
            ILoadService loadService)
            //IInterstitialAdService interstitialAdService)
        {
            _formService = formService ?? throw new ArgumentNullException(nameof(formService));
            _loadService = loadService ?? throw new ArgumentNullException(nameof(loadService));
            //_interstitialAdService = interstitialAdService ?? 
            //                         throw new ArgumentNullException(nameof(interstitialAdService));
        }

        public void Enter(object payload = null)
        {
            if (_playerHealth == null)
                throw new ArgumentNullException(nameof(_playerHealth));

            _playerHealth.PlayerDie += OnPlayerDie;
        }

        public void Exit() =>
            _playerHealth.PlayerDie -= OnPlayerDie;

        public void Register(IPlayerHealth playerHealth) =>
            _playerHealth = playerHealth ?? throw new ArgumentNullException(nameof(playerHealth));

        private void OnPlayerDie()
        {
            if (_isGameOver)
                return;
            
            _isGameOver = true;
            _loadService.ClearAll();
            _formService.Show(FormId.GameOver);
            //_interstitialAdService.ShowInterstitial();
        }
    }
}