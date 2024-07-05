using System;
using JetBrains.Annotations;
using Sources.Scripts.Controllers.Presenters.MainMenu;
using Sources.Scripts.Domain.Models.Gameplay;
using Sources.Scripts.Infrastructure.Factories.Controllers.Presenters.MainMenu;
using Sources.Scripts.Presentations.Views.MainMenu;
using Sources.Scripts.PresentationsInterfaces.Views.MainMenu;

namespace Sources.Scripts.Infrastructure.Factories.Views.MainMenu
{
    public class MainMenuViewFactory
    {
        private readonly MainMenuPresenterFactory _presenterFactory;

        public MainMenuViewFactory(MainMenuPresenterFactory presenterFactory)
        {
            _presenterFactory = presenterFactory ?? throw new ArgumentNullException(nameof(presenterFactory));
        }

        public IMainMenuView Create(MainMenuView view, MainMenuAppearance appearance)
        {
            MainMenuPresenter presenter = _presenterFactory.Create(view, appearance);
            
            view.Construct(presenter);

            return view;
        }
    }
}