using System;
using Sources.Scripts.Controllers.Presenters.MainMenu;
using Sources.Scripts.Domain.Models.Gameplay;
using Sources.Scripts.Domain.Models.Gameplay.Configs;
using Sources.Scripts.PresentationsInterfaces.Views.MainMenu;

namespace Sources.Scripts.Infrastructure.Factories.Controllers.Presenters.MainMenu
{
    public class MainMenuPresenterFactory
    {
        private readonly LocationSpritesConfig _config;

        public MainMenuPresenterFactory(LocationSpritesConfig config)
        {
            _config = config ?? throw new ArgumentNullException(nameof(config));
        }
        
        public MainMenuPresenter Create(IMainMenuView view, MainMenuAppearance mainMenuAppearance) => 
            new(view, mainMenuAppearance, _config);
    }
}