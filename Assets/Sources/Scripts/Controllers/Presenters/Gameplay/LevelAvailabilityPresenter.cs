using System;
using System.Linq;
using JetBrains.Annotations;
using Sources.Scripts.Domain.Models.Data.Ids;
using Sources.Scripts.Domain.Models.Gameplay;
using Sources.Scripts.Domain.Models.Payloads;
using Sources.Scripts.InfrastructureInterfaces.Services.SceneServices;
using Sources.Scripts.Presentations.Views.Gameplay;
using Sources.Scripts.PresentationsInterfaces.Views.Gameplay;
using UnityEngine;
using UnityEngine.Events;

namespace Sources.Scripts.Controllers.Presenters.Gameplay
{
    public class LevelAvailabilityPresenter : PresenterBase
    {
        private readonly LevelAvailability _levelAvailability;
        private readonly MainMenuAppearance _mainMenuAppearance;
        private readonly ILevelAvailabilityView _levelAvailabilityView;
        
        public LevelAvailabilityPresenter(
            LevelAvailability levelAvailability,
            ILevelAvailabilityView levelAvailabilityView)
        {
            _levelAvailability = levelAvailability ?? 
                                 throw new ArgumentNullException(nameof(levelAvailability));
            _levelAvailabilityView = levelAvailabilityView ?? 
                                     throw new ArgumentNullException(nameof(levelAvailabilityView));

            if (_levelAvailabilityView.Levels.Count != _levelAvailability.Levels.Count)
                throw new IndexOutOfRangeException(nameof(_levelAvailability.Levels));
        }
        
        public override void Enable()
        {
            HideAllLevels();
            ShowAvailableLevels();
        }

        private void ShowAvailableLevels()
        {
            int completedLevels = _levelAvailability.Levels.Count(x => x.IsCompleted);

            switch (_levelAvailability.Index)
            {
                case 2:
                    completedLevels -= 6;
                    break;
                
                case 3:
                    completedLevels -= 12;
                    break;
            }

            for (int i = 0; i < completedLevels; i++)
            {
                ILevelView levelView = _levelAvailabilityView.Levels[i];
                levelView.ImageView.SetColor(Color.green);
            }

            ILevelView availableLevelView = _levelAvailabilityView.Levels[completedLevels];
            availableLevelView.ImageView.SetColor(Color.yellow);
        }

        private void HideAllLevels()
        {
            foreach (ILevelView levelView in _levelAvailabilityView.Levels)
            {
                levelView.ImageView.SetColor(Color.blue);
            }
        }
    }
}