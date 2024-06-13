using System;
using Sources.Scripts.Controllers.Presenters.Players;
using Sources.Scripts.InfrastructureInterfaces.Services.InputServices;
using Sources.Scripts.PresentationsInterfaces.Views.Players;
using Sources.Scripts.UIFramework.ServicesInterfaces.Forms;

namespace Sources.Scripts.Infrastructure.Factories.Controllers.Presenters.Players
{
    public class AttackerUIPresenterFactory
    {
        private readonly IInputService _inputService;
        private readonly IFormService _formService;

        public AttackerUIPresenterFactory(IInputService inputService, IFormService formService)
        {
            _inputService = inputService ?? throw new ArgumentNullException(nameof(inputService));
            _formService = formService ?? throw new ArgumentNullException(nameof(formService));
        }

        public AttackerUIPresenter Create(IAttackerUIView view)
        {
            return new AttackerUIPresenter(view, _inputService, _formService);
        }
    }
}