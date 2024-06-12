using System;
using JetBrains.Annotations;
using Sources.Scripts.Controllers.Presenters.Players;
using Sources.Scripts.Domain.Models.Players;
using Sources.Scripts.InfrastructureInterfaces.Services.InputServices;
using Sources.Scripts.InfrastructureInterfaces.Services.Players;
using Sources.Scripts.PresentationsInterfaces.Views.Players;
using Sources.Scripts.UIFramework.ServicesInterfaces.Forms;

namespace Sources.Scripts.Infrastructure.Factories.Controllers.Presenters.Players
{
    public class PlayerAttackerPresenterFactory
    {
        private readonly IInputService _inputService;
        private readonly IFormService _formService;
        private readonly IPlayerAttackService _playerAttackService;

        public PlayerAttackerPresenterFactory(
            IInputService inputService,
            IFormService formService,
            IPlayerAttackService playerAttackService)
        {
            _inputService = inputService ?? throw new ArgumentNullException(nameof(inputService));
            _formService = formService ?? throw new ArgumentNullException(nameof(formService));
            _playerAttackService = playerAttackService ?? throw new ArgumentNullException(nameof(playerAttackService));
        }

        public PlayerAttackerPresenter Create(PlayerAttacker playerAttacker, IPlayerAttackerView view)
        {
            return new PlayerAttackerPresenter(
                playerAttacker, view, _playerAttackService, _inputService, _formService);
        }
    }
}