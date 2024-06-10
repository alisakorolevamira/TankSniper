using System;
using Sources.Scripts.Controllers.Presenters.Common;
using Sources.Scripts.Domain.Models.Common;
using Sources.Scripts.InfrastructureInterfaces.Services.InputServices;
using Sources.Scripts.InfrastructureInterfaces.Services.UpdateServices;

namespace Sources.Scripts.Infrastructure.Factories.Controllers.Presenters.Common
{
    public class CharacterAttackerPresenterFactory
    {
        private readonly IInputService _inputService;
        private readonly IUpdateRegister _updateRegister;

        public CharacterAttackerPresenterFactory(
            IInputService inputService,
            IUpdateRegister updateRegister)
        {
            _inputService = inputService ?? throw new ArgumentNullException(nameof(inputService));
            _updateRegister = updateRegister ?? throw new ArgumentNullException(nameof(updateRegister));
        }

        public CharacterAttackerPresenter Create(
            CharacterAttacker characterAttacker)
        {
            return new CharacterAttackerPresenter(
                characterAttacker, _inputService, _updateRegister);
        }
    }
}