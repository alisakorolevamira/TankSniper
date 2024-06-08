using System;
using Sources.Scripts.Domain.Models.Data.Ids;
using Sources.Scripts.Domain.Models.Gameplay;
using Sources.Scripts.Domain.Models.Payloads;
using Sources.Scripts.InfrastructureInterfaces.Services.LoadServices;
using Sources.Scripts.InfrastructureInterfaces.Services.Repositories;
using Sources.Scripts.InfrastructureInterfaces.Services.SceneServices;
using Sources.Scripts.UIFramework.Domain.Commands;
using Sources.Scripts.UIFramework.InfrastructureInterfaces.Commands.Buttons;
using Sources.Scripts.UIFramework.PresentationsInterfaces.Buttons;

namespace Sources.Scripts.UIFramework.Infrastructure.Commands.Buttons
{
    public class LoadGameCommand : IButtonCommand
    {
        private readonly ILoadService _loadService;
        private readonly IEntityRepository _entityRepository;
        private readonly ISceneService _sceneService;

        public LoadGameCommand(
            ILoadService loadService, 
            IEntityRepository entityRepository, 
            ISceneService sceneService)
        {
            _loadService = loadService ?? throw new ArgumentNullException(nameof(loadService));
            _entityRepository = entityRepository ?? throw new ArgumentNullException(nameof(entityRepository));
            _sceneService = sceneService ?? throw new ArgumentNullException(nameof(sceneService));
        }

        public ButtonCommandId Id => ButtonCommandId.LoadGame;
        
        public void Handle(IUIButton uiButton)
        {
            if (_loadService.HasKey(ModelId.PlayerWallet) == false)
                return;

            CurrentLevel currentLevel = _entityRepository.Get<CurrentLevel>(ModelId.CurrentLevel);

            _sceneService.ChangeSceneAsync(
                currentLevel.CurrentLevelId,
                new ScenePayload(currentLevel.CurrentLevelId, true, false));
        }
    }
}