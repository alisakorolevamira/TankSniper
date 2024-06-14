using System;
using System.Linq;
using System.Threading;
using Sources.Scripts.Domain.Models.Constants;
using Sources.Scripts.InfrastructureInterfaces.Services.InputServices;
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

        private CancellationTokenSource _cancellationTokenSource;
        private int _amountOfShoots;

        public AttackerUIPresenter(
            IAttackerUIView uiAttackerView,
            IInputService inputService,
            IFormService formService)
        {
            _uiAttackerView = uiAttackerView ?? throw new ArgumentNullException(nameof(uiAttackerView));
            _inputService = inputService ?? throw new ArgumentNullException(nameof(inputService));
            _formService = formService ?? throw new ArgumentNullException(nameof(formService));
        }

        public override void Enable()
        {
            _inputService.AttackInputReceived += OnAttackInputReceived;
            _amountOfShoots = AttackConst.MaxShoots;
        }

        public override void Disable()
        {
            _inputService.AttackInputReceived -= OnAttackInputReceived;
        }

        private void OnAttackInputReceived()
        {
            IBulletUIView bulletUI = _uiAttackerView.BulletViews.First(x => x.IsShowed);
            bulletUI.Hide();
            _amountOfShoots--;

            CheckShoots();
        }

        private void CheckShoots()
        {
            if (_amountOfShoots == 0)
            {
                _amountOfShoots = AttackConst.MaxShoots;
                _formService.Show(FormId.ReloadWeapon);

                foreach (IBulletUIView bulletView in _uiAttackerView.BulletViews) 
                    bulletView.Show();
            }

            else
                _formService.Show(FormId.Hud);
        }
    }
}