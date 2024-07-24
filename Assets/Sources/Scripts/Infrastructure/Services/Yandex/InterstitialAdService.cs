using System;
using Agava.WebUtility;
using Agava.YandexGames;
using Sources.Scripts.InfrastructureInterfaces.Services.PauseServices;
using Sources.Scripts.InfrastructureInterfaces.Services.Yandex;

namespace Sources.Scripts.Infrastructure.Services.Yandex
{
    public class InterstitialAdService : IInterstitialAdService
    {
        private readonly IPauseService _pauseService;

        private bool _isContinue;
        private bool _isContinueSound;

        public InterstitialAdService(IPauseService pauseService)
        {
            _pauseService = pauseService ?? throw new ArgumentNullException(nameof(pauseService));
        }
        
        public void ShowInterstitialAd()
        {
            if (WebApplication.IsRunningOnWebGL == false)
                return;
            
            if (AdBlock.Enabled)
                return;

            InterstitialAd.Show(OnOpenCallBack, OnCloseCallBack);
        }
        
        private void OnOpenCallBack()
        {
            if (_pauseService.IsPaused == false)
            {
                _isContinue = true;
                _pauseService.Pause();
            }

            if (_pauseService.IsSoundPaused == false)
            {
                _isContinueSound = true;
                _pauseService.PauseSound();
            }
        }

        private void OnCloseCallBack(bool closed)
        {
            if (_isContinue)
                _pauseService.Continue();

            if (_isContinueSound)
                _pauseService.ContinueSound();
        }
    }
}