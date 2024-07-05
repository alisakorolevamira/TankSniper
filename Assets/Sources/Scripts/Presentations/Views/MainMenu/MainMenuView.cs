using System.Collections.Generic;
using Sources.Scripts.Controllers.Presenters.MainMenu;
using Sources.Scripts.PresentationsInterfaces.Views.MainMenu;
using Sources.Scripts.UIFramework.Presentations.Images;
using Sources.Scripts.UIFramework.PresentationsInterfaces.Images;
using UnityEngine;

namespace Sources.Scripts.Presentations.Views.MainMenu
{
    public class MainMenuView : PresentableView<MainMenuPresenter>, IMainMenuView
    {
        [SerializeField] private ImageView _currentLocation;
        [SerializeField] private ImageView _nextLocation;
        [SerializeField] private List<GameObject> _firstGrid;
        [SerializeField] private List<GameObject> _secondGrid;
        [SerializeField] private List<GameObject> _thirdGrid;

        public IImageView CurrentLocation => _currentLocation;
        public IImageView NextLocation => _nextLocation;
        public IReadOnlyList<GameObject> FirstGrid => _firstGrid;
        public IReadOnlyList<GameObject> SecondGrid => _secondGrid;
        public IReadOnlyList<GameObject> ThirdGrid => _thirdGrid;
    }
}