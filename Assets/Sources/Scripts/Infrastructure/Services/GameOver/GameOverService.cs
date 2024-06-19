using System;
using Sources.Scripts.DomainInterfaces.Models.Common;
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
        private ICharacterHealth _characterHealth;
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
            if (_characterHealth == null)
                throw new ArgumentNullException(nameof(_characterHealth));

            _characterHealth.Die += OnCharacterDie;
        }

        public void Exit() =>
            _characterHealth.Die -= OnCharacterDie;

        public void Register(ICharacterHealth characterHealth) =>
            _characterHealth = characterHealth ?? throw new ArgumentNullException(nameof(characterHealth));

        private void OnCharacterDie()
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