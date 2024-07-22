using System;
using Doozy.Runtime.Signals;
using Sources.Scripts.DomainInterfaces.Models.Common;
using Sources.Scripts.InfrastructureInterfaces.Services.GameOver;
using Sources.Scripts.InfrastructureInterfaces.Services.Yandex;

namespace Sources.Scripts.Infrastructure.Services.GameOver
{
    public class GameOverService : IGameOverService
    {
        private readonly IStickyAdService _stickyAdService;
        private ICharacterHealth _characterHealth;
        private bool _isGameOver;

        public GameOverService(IStickyAdService stickyAdService)
        {
            _stickyAdService = stickyAdService ?? throw new ArgumentNullException(nameof(stickyAdService));
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
            Signal.Send(StreamId.Gameplay.GameOver);
            _stickyAdService.ShowStickyAd();
        }
    }
}