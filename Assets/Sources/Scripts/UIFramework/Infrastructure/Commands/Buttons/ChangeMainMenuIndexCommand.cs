using System;
using Sources.Scripts.Domain.Models.Data.Ids;
using Sources.Scripts.Domain.Models.Gameplay;
using Sources.Scripts.InfrastructureInterfaces.Services.LoadServices;
using Sources.Scripts.InfrastructureInterfaces.Services.Repositories;
using Sources.Scripts.UIFramework.Domain.Commands;
using Sources.Scripts.UIFramework.InfrastructureInterfaces.Commands.Buttons;

namespace Sources.Scripts.UIFramework.Infrastructure.Commands.Buttons
{
    public class ChangeMainMenuIndexCommand : IButtonCommand
    {
        private readonly IEntityRepository _entityRepository;
        private readonly ILoadService _loadService;

        public ChangeMainMenuIndexCommand(IEntityRepository entityRepository, ILoadService loadService)
        {
            _entityRepository = entityRepository ?? throw new ArgumentNullException(nameof(entityRepository));
            _loadService = loadService ?? throw new ArgumentNullException(nameof(loadService));
        }
        
        public ButtonCommandId Id => ButtonCommandId.ChangeMainMenuIndex;

        public void Handle()
        {
            MainMenuAppearance mainMenu = _entityRepository.Get<MainMenuAppearance>(ModelId.MainMenuAppearance);
            mainMenu.Index++;
            
            _loadService.Save(ModelId.MainMenuAppearance);
        }
    }
}