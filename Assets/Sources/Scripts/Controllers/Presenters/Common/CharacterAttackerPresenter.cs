using System;
using System.Threading;
using Sources.Scripts.Domain.Models.Common;
using Sources.Scripts.InfrastructureInterfaces.Services.InputServices;
using Sources.Scripts.InfrastructureInterfaces.Services.UpdateServices;

namespace Sources.Scripts.Controllers.Presenters.Common
{
    public class CharacterAttackerPresenter : PresenterBase
    {
        private readonly CharacterAttacker _characterAttacker;
        private readonly IInputService _inputService;
        private readonly IUpdateRegister _updateRegister;

        private CancellationTokenSource _cancellationTokenSource;

        public CharacterAttackerPresenter(
            CharacterAttacker characterAttacker,
            IInputService inputService,
            IUpdateRegister updateRegister)
        {
            _characterAttacker = characterAttacker ?? throw new ArgumentNullException(nameof(characterAttacker));
            _inputService = inputService ?? throw new ArgumentNullException(nameof(inputService));
            _updateRegister = updateRegister ?? throw new ArgumentNullException(nameof(updateRegister));
        }

        public override void Enable()
        {
            _cancellationTokenSource = new CancellationTokenSource();
            _updateRegister.Register(OnUpdate);
        }

        public override void Disable()
        {
            _cancellationTokenSource.Cancel();
            _updateRegister.UnRegister(OnUpdate);
        }

        private void OnUpdate(float deltaTime)
        {
            
        }
    }
}