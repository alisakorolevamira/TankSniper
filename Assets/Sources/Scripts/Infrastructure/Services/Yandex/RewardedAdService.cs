using System;
using Agava.WebUtility;
using Agava.YandexGames;
using Sources.Scripts.Domain.Models.Constants;
using Sources.Scripts.InfrastructureInterfaces.Services.PauseServices;
using Sources.Scripts.InfrastructureInterfaces.Services.Spawners;
using Sources.Scripts.InfrastructureInterfaces.Services.Yandex;

namespace Sources.Scripts.Infrastructure.Services.Yandex
{
    public class RewardedAdService : IRewardedAdService
    {
        private readonly IInventoryTankSpawnerService _spawnerService;
        private readonly IPauseService _pauseService;

        private bool _isContinue = false;
        private bool _isContinueSound = false;

        public RewardedAdService(
            IInventoryTankSpawnerService spawnerService,
            IPauseService pauseService)
        {
            _spawnerService = spawnerService ?? throw new ArgumentNullException(nameof(spawnerService));
            _pauseService = pauseService ?? throw new ArgumentNullException(nameof(pauseService));
        }
        
        public void ShowRewardedAd()
        {
            if (AdBlock.Enabled)
                return;
            
            if (WebApplication.IsRunningOnWebGL == false)
                return;
            
            VideoAd.Show(OnOpenCallBack, OnRewardCallBack, OnCloseCallBack);
        }
        
        private void OnRewardCallBack() => 
            _spawnerService.Spawn(InventoryTankConst.DefaultTankLevel);

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

        private void OnCloseCallBack()
        {
            if (_isContinue)
                _pauseService.Continue();

            if (_isContinueSound)
                _pauseService.ContinueSound();
        }
    }
}