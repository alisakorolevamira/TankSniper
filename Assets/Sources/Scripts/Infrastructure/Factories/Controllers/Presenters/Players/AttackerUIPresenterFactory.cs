using System;
using Sources.Scripts.Controllers.Presenters.Players;
using Sources.Scripts.InfrastructureInterfaces.Services.InputServices;
using Sources.Scripts.InfrastructureInterfaces.Services.LevelCompleted;
using Sources.Scripts.PresentationsInterfaces.Views.Players;

namespace Sources.Scripts.Infrastructure.Factories.Controllers.Presenters.Players
{
    public class AttackerUIPresenterFactory
    {
        private readonly IInputService _inputService;
        private readonly ILevelCompletedService _levelCompletedService;

        public AttackerUIPresenterFactory(IInputService inputService, ILevelCompletedService levelCompletedService)
        {
            _inputService = inputService ?? throw new ArgumentNullException(nameof(inputService));
            _levelCompletedService = levelCompletedService ?? throw new ArgumentNullException(nameof(levelCompletedService));
        }

        public AttackerUIPresenter Create(IAttackerUIView view)
        {
            return new AttackerUIPresenter(view, _inputService, _levelCompletedService);
        }
    }
}