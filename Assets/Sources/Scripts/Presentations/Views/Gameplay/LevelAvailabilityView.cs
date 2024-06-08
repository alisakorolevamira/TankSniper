using System.Collections.Generic;
using Sources.Scripts.Controllers.Presenters.Gameplay;
using Sources.Scripts.PresentationsInterfaces.Views.Gameplay;
using UnityEngine;

namespace Sources.Scripts.Presentations.Views.Gameplay
{
    public class LevelAvailabilityView : PresentableView<LevelAvailabilityPresenter>, ILevelAvailabilityView
    {
        [SerializeField] private List<LevelView> _levelViews;
        
        public IReadOnlyList<ILevelView> Levels { get; }
    }
}