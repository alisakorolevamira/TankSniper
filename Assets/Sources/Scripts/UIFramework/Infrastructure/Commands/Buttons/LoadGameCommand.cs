using System;
using System.Collections.Generic;
using System.Linq;
using Doozy.Runtime.UIManager.Components;
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

        private Dictionary<int, string> _levels = new()
        {
            { 1, ModelId.FirstLevel },
            { 2, ModelId.SecondLevel },
            { 3, ModelId.ThirdLevel },
            { 4, ModelId.FourthLevel },
            { 5, ModelId.FifthLevel },
            { 6, ModelId.SixthLevel }
        };

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
            //if (_loadService.HasKey(ModelId.PlayerWallet) == false)
                //return;

            SavedLevel savedLevel = _entityRepository.Get<SavedLevel>(ModelId.SavedLevel);
            
            _loadService.SaveAll();
            
            if (savedLevel == null)
            {
                _sceneService.ChangeSceneAsync(ModelId.FirstLevel, new ScenePayload(ModelId.FirstLevel, true, false));
                return;
            }

            string newLevel = FindNewLevel(savedLevel.CurrentLevelId);

            _sceneService.ChangeSceneAsync(newLevel, new ScenePayload(newLevel, true, false));
        }

        private string FindNewLevel(string savedLevel)
        {
            int savedLevelId = _levels.First(x => x.Value == savedLevel).Key;

            string newLevel = _levels.First(x => x.Key == savedLevelId + 1).Value;

            if (newLevel == null)
                return ModelId.FirstLevel;

            return newLevel;
        }
    }
}