using System;
using System.Collections.Generic;
using Sources.Scripts.Domain.Models.Constants;
using Sources.Scripts.Domain.Models.Gameplay;
using Sources.Scripts.Domain.Models.Gameplay.Configs;
using Sources.Scripts.PresentationsInterfaces.Views.MainMenu;
using UnityEngine;

namespace Sources.Scripts.Controllers.Presenters.MainMenu
{
    public class MainMenuPresenter : PresenterBase
    {
        private readonly IMainMenuView _view;
        private readonly MainMenuAppearance _mainMenuAppearance;
        private readonly LocationSpritesConfig _spritesConfig;

        public MainMenuPresenter(
            IMainMenuView view,
            MainMenuAppearance mainMenuAppearance,
            LocationSpritesConfig spritesConfig)
        {
            _view = view ?? throw new ArgumentNullException(nameof(view));
            _mainMenuAppearance = mainMenuAppearance ?? throw new ArgumentNullException(nameof(mainMenuAppearance));
            _spritesConfig = spritesConfig ?? throw new ArgumentNullException(nameof(spritesConfig));
        }

        public override void Enable()
        {
            DisableGrid(_view.FirstGrid);
            DisableGrid(_view.SecondGrid);
            DisableGrid(_view.ThirdGrid);
            SetMenuAppearance();
        }

        private void SetMenuAppearance()
        {
            switch (_mainMenuAppearance.Index)
            {
                case MainMenuConst.FirstView:
                {
                    _view.CurrentLocation.SetSprite(_spritesConfig.FirstLocation);
                    _view.NextLocation.SetSprite(_spritesConfig.SecondLocation);
                    EnableGrid(_view.FirstGrid);
                    break;
                }

                case MainMenuConst.SecondView:
                {
                    _view.CurrentLocation.SetSprite(_spritesConfig.SecondLocation);
                    _view.NextLocation.SetSprite(_spritesConfig.ThirdLocation);
                    EnableGrid(_view.SecondGrid);
                    break;
                }

                case MainMenuConst.ThirdView:
                {
                    _view.CurrentLocation.SetSprite(_spritesConfig.ThirdLocation);
                    _view.NextLocation.SetSprite(_spritesConfig.FirstLocation);
                    EnableGrid(_view.ThirdGrid);
                    break;
                }

                default:
                {
                    _view.CurrentLocation.SetSprite(_spritesConfig.FirstLocation);
                    _view.NextLocation.SetSprite(_spritesConfig.SecondLocation);
                    EnableGrid(_view.FirstGrid);
                    break;
                }
            }
        }

        private void EnableGrid(IReadOnlyList<GameObject> grid)
        {
            foreach (GameObject piece in grid) 
                piece.SetActive(true);
        }

        private void DisableGrid(IReadOnlyList<GameObject> grid)
        {
            foreach (GameObject piece in grid) 
                piece.SetActive(false);
        }
    }
}