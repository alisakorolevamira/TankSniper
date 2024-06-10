﻿using System;
using Sources.Scripts.Domain.Models.Data.Ids;
using Sources.Scripts.Domain.Models.Gameplay;
using Sources.Scripts.Domain.Models.Payloads;
using Sources.Scripts.InfrastructureInterfaces.Services.Repositories;
using Sources.Scripts.InfrastructureInterfaces.Services.SceneServices;
using Sources.Scripts.UIFramework.Domain.Commands;
using Sources.Scripts.UIFramework.InfrastructureInterfaces.Commands.Buttons;
using Sources.Scripts.UIFramework.PresentationsInterfaces.Buttons;

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
        
        public void Handle(IUIButton uiButton)
        {
            CurrentLevel currentLevel = _entityRepository.Get<CurrentLevel>(ModelId.CurrentLevel);
            _sceneService.ChangeSceneAsync(
                ModelId.MainMenu, new ScenePayload(currentLevel.CurrentLevelId, false, true));
        }
    }
}