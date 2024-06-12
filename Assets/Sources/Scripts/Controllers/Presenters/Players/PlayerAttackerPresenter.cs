using System;
using System.Linq;
using System.Threading;
using JetBrains.Annotations;
using Sources.Scripts.Domain.Models.Players;
using Sources.Scripts.InfrastructureInterfaces.Services.InputServices;
using Sources.Scripts.InfrastructureInterfaces.Services.Players;
using Sources.Scripts.PresentationsInterfaces.Views.Bullets;
using Sources.Scripts.PresentationsInterfaces.Views.Players;
using Sources.Scripts.UIFramework.Presentations.Views.Types;
using Sources.Scripts.UIFramework.ServicesInterfaces.Forms;

namespace Sources.Scripts.Controllers.Presenters.Players
{
    public class PlayerAttackerPresenter : PresenterBase
    {
        private readonly PlayerAttacker _playerAttacker;
        private readonly IPlayerAttackerView _playerAttackerView;
        private readonly IPlayerAttackService _attackService;
        private readonly IInputService _inputService;
        private readonly IFormService _formService;

        private CancellationTokenSource _cancellationTokenSource;
        private int _amountOfShoots = 4;

        public PlayerAttackerPresenter(
            PlayerAttacker playerAttacker,
            IPlayerAttackerView playerAttackerView,
            IPlayerAttackService attackService,
            IInputService inputService,
            IFormService formService)
        {
            _playerAttacker = playerAttacker ?? throw new ArgumentNullException(nameof(playerAttacker));
            _playerAttackerView = playerAttackerView ?? throw new ArgumentNullException(nameof(playerAttackerView));
            _attackService = attackService ?? throw new ArgumentNullException(nameof(attackService));
            _inputService = inputService ?? throw new ArgumentNullException(nameof(inputService));
            _formService = formService ?? throw new ArgumentNullException(nameof(formService));
        }

        public override void Enable()
        {
            _inputService.AttackInputReceived += OnAttackInputReceived;
        }

        public override void Disable()
        {
            _inputService.AttackInputReceived -= OnAttackInputReceived;
        }

        private void OnAttackInputReceived()
        {
            IBulletView bullet = _playerAttackerView.BulletViews.First(x => x.IsShowed == true);
            bullet.Hide();
            _amountOfShoots--;
            
            _playerAttacker.Attack();
            _attackService.Attack();
            _playerAttackerView.ShootEffect.Play();

            CheckShoots();
        }

        private void CheckShoots()
        {
            if (_amountOfShoots == 0)
            {
                _amountOfShoots = 4;
                _formService.Show(FormId.ReloadWeapon);

                foreach (IBulletView bulletView in _playerAttackerView.BulletViews)
                {
                    bulletView.Show();
                }
            }

            else
            {
                _formService.Show(FormId.Hud);
            }
        }
    }
}