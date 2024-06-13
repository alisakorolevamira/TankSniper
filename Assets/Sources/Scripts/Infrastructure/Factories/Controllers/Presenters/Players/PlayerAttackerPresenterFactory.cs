using System;
using Sources.Scripts.Controllers.Presenters.Players;
using Sources.Scripts.Domain.Models.Players;
using Sources.Scripts.InfrastructureInterfaces.Services.InputServices;
using Sources.Scripts.InfrastructureInterfaces.Services.Players;

namespace Sources.Scripts.Infrastructure.Factories.Controllers.Presenters.Players
{
    public class PlayerAttackerPresenterFactory
    {
        private readonly IInputService _inputService;
        private readonly IPlayerAttackService _playerAttackService;

        public PlayerAttackerPresenterFactory(IInputService inputService, IPlayerAttackService playerAttackService)
        {
            _inputService = inputService ?? throw new ArgumentNullException(nameof(inputService));
            _playerAttackService = playerAttackService ?? throw new ArgumentNullException(nameof(playerAttackService));
        }

        public PlayerAttackerPresenter Create(PlayerAttacker playerAttacker)
        {
            return new PlayerAttackerPresenter(playerAttacker, _playerAttackService, _inputService);
        }
    }
}