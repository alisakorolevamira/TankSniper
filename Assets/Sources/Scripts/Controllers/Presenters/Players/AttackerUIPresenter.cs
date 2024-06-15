using System;
using System.Linq;
using System.Threading;
using Cysharp.Threading.Tasks;
using Sources.Scripts.Domain.Models.Constants;
using Sources.Scripts.Domain.Models.Gameplay;
using Sources.Scripts.DomainInterfaces.Models.Gameplay;
using Sources.Scripts.InfrastructureInterfaces.Services.InputServices;
using Sources.Scripts.InfrastructureInterfaces.Services.LevelCompleted;
using Sources.Scripts.PresentationsInterfaces.Views.Bullets;
using Sources.Scripts.PresentationsInterfaces.Views.Players;
using Sources.Scripts.UIFramework.Presentations.Views.Types;
using Sources.Scripts.UIFramework.ServicesInterfaces.Forms;
using UnityEngine;

namespace Sources.Scripts.Controllers.Presenters.Players
{
    public class AttackerUIPresenter : PresenterBase
    {
        private readonly IAttackerUIView _uiAttackerView;
        private readonly IInputService _inputService;
        private readonly IFormService _formService;
        private readonly ILevelCompletedService _levelCompletedService;

        private CancellationTokenSource _cancellationTokenSource;
        private int _amountOfShoots = AttackConst.DefaultShoots;
        private readonly TimeSpan _delay = TimeSpan.FromSeconds(2);

        public AttackerUIPresenter(
            IAttackerUIView uiAttackerView,
            IInputService inputService,
            ILevelCompletedService levelCompletedService,
            IFormService formService)
        {
            _uiAttackerView = uiAttackerView ?? throw new ArgumentNullException(nameof(uiAttackerView));
            _inputService = inputService ?? throw new ArgumentNullException(nameof(inputService));
            _formService = formService ?? throw new ArgumentNullException(nameof(formService));
            _levelCompletedService = levelCompletedService ?? throw new ArgumentNullException(nameof(levelCompletedService));
        }

        public override void Enable()
        {
            _inputService.AttackInputReceived += OnAttackInputReceived;
            _cancellationTokenSource = new CancellationTokenSource();
        }

        public override void Disable()
        {
            _inputService.AttackInputReceived -= OnAttackInputReceived;
        }

        private void OnAttackInputReceived()
        {
            IBulletUIView bulletUI = _uiAttackerView.BulletViews.First(x => x.IsShowed);
            bulletUI.Hide();
            _amountOfShoots++;

            StartTimer();
        }

        private async void StartTimer()
        {
            _cancellationTokenSource.Cancel();
            _cancellationTokenSource = new CancellationTokenSource();
            
            try
            {
                await UniTask.Delay(_delay, cancellationToken: _cancellationTokenSource.Token, ignoreTimeScale: true);
                
                CheckShoots();
            }
            catch (OperationCanceledException)
            {
            }
        }
        
        private void CheckShoots()
        {
            if (_levelCompletedService.AllEnemiesKilled)
            {
                _formService.Show(FormId.Hud);
                return;
            }
            
            if (_amountOfShoots == AttackConst.MaxShoots)
            {
                _amountOfShoots = AttackConst.DefaultShoots;
                _formService.Show(FormId.ReloadWeapon);

                foreach (IBulletUIView bulletView in _uiAttackerView.BulletViews) 
                    bulletView.Show();
            }

            else
                _formService.Show(FormId.Hud);
        }
    }
}