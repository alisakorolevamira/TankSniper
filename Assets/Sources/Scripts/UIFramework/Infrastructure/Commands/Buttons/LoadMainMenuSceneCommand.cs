using System;
using Doozy.Runtime.UIManager.Components;
using Sources.Scripts.Domain.Models.Data.Ids;
using Sources.Scripts.Domain.Models.Gameplay;
using Sources.Scripts.Domain.Models.Payloads;
using Sources.Scripts.InfrastructureInterfaces.Services.Repositories;
using Sources.Scripts.InfrastructureInterfaces.Services.SceneServices;
using Sources.Scripts.UIFramework.Domain.Commands;
using Sources.Scripts.UIFramework.InfrastructureInterfaces.Commands.Buttons;

namespace Sources.Scripts.UIFramework.Infrastructure.Commands.Buttons
{
    public class LoadMainMenuSceneCommand : IButtonCommand
    {
        private readonly ISceneService _sceneService;
        private readonly IEntityRepository _entityRepository;

        public LoadMainMenuSceneCommand(
            ISceneService sceneService,
            IEntityRepository entityRepository)
        {
            _sceneService = sceneService ?? throw new ArgumentNullException(nameof(sceneService));
            _entityRepository = entityRepository ?? throw new ArgumentNullException(nameof(entityRepository));
        }

        public ButtonCommandId Id => ButtonCommandId.LoadMainMenuScene;
        
        public void Handle()
        {
            SavedLevel savedLevel = _entityRepository.Get<SavedLevel>(ModelId.SavedLevel);
            //_sceneService.ChangeSceneAsync(
            //    ModelId.MainMenu, new ScenePayload(savedLevel.CurrentLevelId, false, true));
            
            _sceneService.ChangeSceneAsync(
                ModelId.MainMenu, new ScenePayload(ModelId.MainMenu, true, true));
        }
    }
}