﻿using System;
using System.Linq;
using System.Threading;
using Cysharp.Threading.Tasks;
using Doozy.Runtime.Signals;
using Sources.Scripts.Domain.Models.Constants;
using Sources.Scripts.InfrastructureInterfaces.Services.InputServices;
using Sources.Scripts.InfrastructureInterfaces.Services.LevelCompleted;
using Sources.Scripts.InfrastructureInterfaces.Services.Players;
using Sources.Scripts.PresentationsInterfaces.Views.Bullets;
using Sources.Scripts.PresentationsInterfaces.Views.Lightnings;
using Sources.Scripts.PresentationsInterfaces.Views.Players;

namespace Sources.Scripts.Controllers.Presenters.Players
{
    public class AttackerUIPresenter : PresenterBase
    {
        private readonly IAttackerUIView _uiAttackerView;
        private readonly IInputService _inputService;
        private readonly ILevelCompletedService _levelCompletedService;
        private readonly IPlayerAttackService _playerAttackService;
        private readonly TimeSpan _delay = TimeSpan.FromSeconds(2);
        private readonly TimeSpan _lightningsDelay = TimeSpan.FromSeconds(1);

        private CancellationTokenSource _cancellationTokenSource;
        private int _amountOfShoots = AttackConst.DefaultShoots;

        public AttackerUIPresenter(
            IAttackerUIView uiAttackerView,
            IInputService inputService,
            ILevelCompletedService levelCompletedService,
            IPlayerAttackService playerAttackService)
        {
            _uiAttackerView = uiAttackerView ?? throw new ArgumentNullException(nameof(uiAttackerView));
            _inputService = inputService ?? throw new ArgumentNullException(nameof(inputService));
            _levelCompletedService = levelCompletedService ??
                                     throw new ArgumentNullException(nameof(levelCompletedService));
            _playerAttackService = playerAttackService ?? throw new ArgumentNullException(nameof(playerAttackService));
        }

        public override void Enable()
        {
            _inputService.AttackInputReceived += OnAttackInputReceived;
            _cancellationTokenSource = new CancellationTokenSource();
        }

        public override void Disable() => 
            _inputService.AttackInputReceived -= OnAttackInputReceived;

        private void OnAttackInputReceived()
        {
            IBulletUIView bulletUI = _uiAttackerView.BulletViews.First(x => x.IsShowed);
            bulletUI.Hide();

            ILightningView lightningView = _uiAttackerView.LightningViews.FirstOrDefault(x => x.IsShowed == false);
            lightningView?.Show();

            _amountOfShoots++;

            CheckShoots();
        }

        private async void CheckShoots()
        {
            if (_levelCompletedService.AllEnemiesKilled)
                return;
            
            _cancellationTokenSource.Cancel();
            _cancellationTokenSource = new CancellationTokenSource();

            try
            {
                if (_amountOfShoots == AttackConst.MaxShoots)
                {
                    await UniTask.Delay(_lightningsDelay, cancellationToken: _cancellationTokenSource.Token, ignoreTimeScale: true);
                    
                    _playerAttackService.EnableDoubleAttack();

                    foreach (ILightningView lightningView in _uiAttackerView.LightningViews)
                        lightningView.Hide();
                    
                    await UniTask.Delay(_delay, cancellationToken: _cancellationTokenSource.Token, ignoreTimeScale: true);

                    _amountOfShoots = AttackConst.DefaultShoots;

                    Signal.Send(StreamId.Gameplay.ReloadWeapon);

                    foreach (IBulletUIView bulletView in _uiAttackerView.BulletViews)
                        bulletView.Show();
                }

                else
                    Signal.Send(StreamId.Gameplay.ReturnToHud);
            }
            catch (OperationCanceledException)
            {
            }
        }
    }
}