using System;
using System.Threading;
using Sources.Scripts.Domain.Models.Players;
using Sources.Scripts.InfrastructureInterfaces.Services.InputServices;
using Sources.Scripts.InfrastructureInterfaces.Services.Players;

namespace Sources.Scripts.Controllers.Presenters.Players
{
    public class PlayerAttackerPresenter : PresenterBase
    {
        private readonly PlayerAttacker _playerAttacker;
        private readonly IPlayerAttackService _attackService;
        private readonly IInputService _inputService;

        private CancellationTokenSource _cancellationTokenSource;

        public PlayerAttackerPresenter(
            PlayerAttacker playerAttacker,
            IPlayerAttackService attackService,
            IInputService inputService)
        {
            _playerAttacker = playerAttacker ?? throw new ArgumentNullException(nameof(playerAttacker));
            _attackService = attackService ?? throw new ArgumentNullException(nameof(attackService));
            _inputService = inputService ?? throw new ArgumentNullException(nameof(inputService));
        }

        public override void Enable() => 
            _inputService.AttackInputReceived += OnAttackInputReceived;

        public override void Disable() => 
            _inputService.AttackInputReceived -= OnAttackInputReceived;

        private void OnAttackInputReceived()
        {
            _attackService.Attack();
            _playerAttacker.Attack();
        }
    }
}