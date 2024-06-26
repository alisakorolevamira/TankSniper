using System;
using Agava.WebUtility;
using Sources.Scripts.InfrastructureInterfaces.Services.PauseServices;
using Sources.Scripts.UIFramework.ServicesInterfaces.Focus;
using UnityEngine;

namespace Sources.Scripts.UIFramework.Services.Focus
{
    public class FocusService : IFocusService
    {
        private readonly IPauseService _pauseService;

        public FocusService(IPauseService pauseService)
        {
            _pauseService = pauseService ?? throw new ArgumentNullException(nameof(pauseService));
        }

        public void Enable()
        {
            //OnInBackgroundChangeWeb(WebApplication.InBackground);
            //OnInBackgroundChangeApp(Application.isFocused);
            //
            //Application.focusChanged += OnInBackgroundChangeApp;
            //WebApplication.InBackgroundChangeEvent += OnInBackgroundChangeWeb;
        }

        public void Disable()
        {
            //Application.focusChanged -= OnInBackgroundChangeApp;
            //WebApplication.InBackgroundChangeEvent -= OnInBackgroundChangeWeb;
        }

        private void OnInBackgroundChangeApp(bool inApp)
        {
            if (inApp == false)
            {
                _pauseService.Pause();
                _pauseService.PauseSound();

                return;
            }

            if (_pauseService.IsPaused)
                _pauseService.Continue();

            if (_pauseService.IsSoundPaused)
                _pauseService.ContinueSound();
        }

        private void OnInBackgroundChangeWeb(bool isBackground)
        {
            if (isBackground)
            {
                _pauseService.Pause();
                _pauseService.PauseSound();

                return;
            }

            if (_pauseService.IsPaused)
                _pauseService.Continue();

            if (_pauseService.IsSoundPaused)
                _pauseService.ContinueSound();
        }
    }
}