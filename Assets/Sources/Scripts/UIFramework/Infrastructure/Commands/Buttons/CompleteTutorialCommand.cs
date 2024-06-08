using System;
using Sources.Scripts.InfrastructureInterfaces.Services.Tutorials;
using Sources.Scripts.UIFramework.Domain.Commands;
using Sources.Scripts.UIFramework.InfrastructureInterfaces.Commands.Buttons;
using Sources.Scripts.UIFramework.PresentationsInterfaces.Buttons;

namespace Sources.Scripts.UIFramework.Infrastructure.Commands.Buttons
{
    public class CompleteTutorialCommand : IButtonCommand
    {
        private readonly ITutorialService _tutorialService;

        public CompleteTutorialCommand(ITutorialService tutorialService)
        {
            _tutorialService = tutorialService ?? throw new ArgumentNullException(nameof(tutorialService));
        }

        public ButtonCommandId Id => ButtonCommandId.CompleteTutorial;
        
        public void Handle(IUIButton uiButton) =>
            _tutorialService.Complete();
    }
}