using System;
using Sources.Scripts.UIFramework.Domain.Commands;
using Sources.Scripts.UIFramework.InfrastructureInterfaces.Commands.Buttons;
using Sources.Scripts.UIFramework.PresentationsInterfaces.Buttons;
using Sources.Scripts.UIFramework.ServicesInterfaces.Forms;

namespace Sources.Scripts.UIFramework.Infrastructure.Commands.Buttons
{
    public class HideFormCommand : IButtonCommand
    {
        private readonly IFormService _formService;

        public HideFormCommand(IFormService formService)
        {
            _formService = formService ?? throw new ArgumentNullException(nameof(formService));
        }

        public ButtonCommandId Id => ButtonCommandId.HideForm;
        
        public void Handle(IUIButton uiButton) =>
            _formService.Hide(uiButton.FormId);
    }
}