using System;
using Sources.Scripts.Domain.Models.Constants;
using Sources.Scripts.Domain.Models.Data.Ids;
using Sources.Scripts.Domain.Models.Gameplay;
using Sources.Scripts.Domain.Models.Payloads;
using Sources.Scripts.InfrastructureInterfaces.Services.LoadServices;
using Sources.Scripts.InfrastructureInterfaces.Services.Repositories;
using Sources.Scripts.InfrastructureInterfaces.Services.SceneServices;
using Sources.Scripts.UIFramework.Domain.Commands;
using Sources.Scripts.UIFramework.InfrastructureInterfaces.Commands.Buttons;

namespace Sources.Scripts.UIFramework.Infrastructure.Commands.Buttons
{
    public class LoadGameCommand : IButtonCommand
    {
        private readonly ILoadService _loadService;
        private readonly IEntityRepository _entityRepository;
        private readonly ISceneService _sceneService;

        private Level _newLevel;

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
        
        public void Handle()
        {
            SavedLevel savedLevel = _entityRepository.Get<SavedLevel>(ModelId.SavedLevel);
            
            _loadService.SaveAll();
            
            if (savedLevel == null)
            {
                _sceneService.ChangeSceneAsync(LevelConst.FirstLevel, new ScenePayload(LevelConst.FirstLevel, true, false));
                return;
            }

            string newLevel = FindNewLevel(savedLevel.CurrentLevelId);

            _sceneService.ChangeSceneAsync(newLevel, new ScenePayload(newLevel, true, false));
        }

        private string FindNewLevel(string savedLevelId)
        {
            GameLevels gameLevels = _entityRepository.Get<GameLevels>(ModelId.GameLevels);
            Level savedLevel = gameLevels.Levels.Find(level => level.Id == savedLevelId);
            int savedLevelIndex = gameLevels.Levels.IndexOf(savedLevel);

            _newLevel = savedLevel.IsCompleted ? gameLevels.Levels[savedLevelIndex + 1] : savedLevel;

            if (_newLevel == null)
                return LevelConst.FirstLevel;

            return _newLevel.Id;
        }
    }
}