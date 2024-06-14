using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Sources.Scripts.Domain.Models.Constants;
using Sources.Scripts.PresentationsInterfaces.Views.Weapons;
using Sources.Scripts.UIFramework.Presentations.Views.Types;
using Sources.Scripts.UIFramework.ServicesInterfaces.Forms;
using UnityEngine;

namespace Sources.Scripts.Controllers.Presenters.Weapons
{
    public class ReloadWeaponPresenter : PresenterBase
    {
        private readonly IReloadWeaponView _view;
        private readonly IFormService _formService;
        private readonly TimeSpan _delay = TimeSpan.FromMilliseconds(ReloadWeaponConst.Delay);
        
        private CancellationTokenSource _cancellationTokenSource;
        private float _fillingAmount;

        public ReloadWeaponPresenter(IReloadWeaponView view, IFormService formService)
        {
            _view = view ?? throw new ArgumentNullException(nameof(view));
            _formService = formService ?? throw new ArgumentNullException(nameof(formService));
        }

        public override void Enable()
        {
            _cancellationTokenSource = new CancellationTokenSource();
            _fillingAmount = ImageConst.Min;
            
            _view.ImageView.SetFillAmount(_fillingAmount);
            StartTimer(_cancellationTokenSource.Token);
        }

        public override void Disable()
        {
            _cancellationTokenSource.Cancel();
        }

        private async void StartTimer(CancellationToken cancellationToken)
        {
            try
            {
                while(_view.ImageView.FillAmount < ImageConst.Max)
                {
                    _fillingAmount += ReloadWeaponConst.Speed * Time.deltaTime;
                    _view.ImageView.SetFillAmount(_fillingAmount);
                    
                    await UniTask.Delay(_delay, cancellationToken: cancellationToken);
                }
                
                _formService.Show(FormId.Hud);
            }
            catch (OperationCanceledException)
            {
            }
        }
    }
}