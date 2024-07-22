using System;
using System.Linq;
using Sources.Scripts.Domain.Models.Constants;
using Sources.Scripts.Domain.Models.Gameplay;
using Sources.Scripts.PresentationsInterfaces.Views.Gameplay;
using UnityEngine;

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
                case MainMenuConst.SecondView:
                    completedLevels -= MainMenuConst.SecondViewIndex;
                    break;
                
                case MainMenuConst.ThirdView:
                    completedLevels -= MainMenuConst.ThirdViewIndex;
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
                levelView.ImageView.SetColor(Color.blue);
        }
    }
}