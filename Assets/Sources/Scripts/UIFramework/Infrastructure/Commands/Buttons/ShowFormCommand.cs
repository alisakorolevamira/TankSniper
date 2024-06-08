using System;
using Sources.Scripts.UIFramework.Domain.Commands;
using Sources.Scripts.UIFramework.InfrastructureInterfaces.Commands.Buttons;
using Sources.Scripts.UIFramework.PresentationsInterfaces.Buttons;
using Sources.Scripts.UIFramework.ServicesInterfaces.Forms;

namespace Sources.Scripts.UIFramework.Infrastructure.Commands.Buttons
{
    public class ShowFormCommand : IButtonCommand
    {
        private readonly IFormService _formService;

        public ShowFormCommand(IFormService formService)
        {
            _formService = formService ?? throw new ArgumentNullException(nameof(formService));
        }

        public ButtonCommandId Id => ButtonCommandId.ShowForm;

        public void Handle(IUIButton uiButton) =>
            _formService.Show(uiButton.FormId);
    }
}