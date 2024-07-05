using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Doozy.Runtime.Signals;
using Sources.Scripts.Domain.Models.Constants;
using Sources.Scripts.InfrastructureInterfaces.Services.Weapons;
using Sources.Scripts.PresentationsInterfaces.Views.Weapons;
using UnityEngine;

namespace Sources.Scripts.Controllers.Presenters.Weapons
{
    public class ReloadWeaponPresenter : PresenterBase
    {
        private readonly IReloadWeaponView _view;
        private readonly IReloadWeaponService _reloadWeaponService;
        private readonly TimeSpan _delay = TimeSpan.FromMilliseconds(ReloadWeaponConst.Delay);
        
        private CancellationTokenSource _cancellationTokenSource;
        private float _fillingAmount;

        public ReloadWeaponPresenter(IReloadWeaponView view, IReloadWeaponService reloadWeaponService)
        {
            _view = view ?? throw new ArgumentNullException(nameof(view));
            _reloadWeaponService = reloadWeaponService ?? throw new ArgumentNullException(nameof(reloadWeaponService));
        }

        public override void Enable()
        {
            _cancellationTokenSource = new CancellationTokenSource();
            //_fillingAmount = ImageConst.Min;
            
            //_view.ImageView.SetFillAmount(_fillingAmount);
            //StartTimer(_cancellationTokenSource.Token);
            _reloadWeaponService.StartTimer += OnStartTimer;
        }

        public override void Disable()
        {
            _cancellationTokenSource.Cancel();
            _reloadWeaponService.StartTimer -= OnStartTimer;
        }

        private async void OnStartTimer()
        {
            CancellationToken cancellationToken = _cancellationTokenSource.Token;
            _fillingAmount = ImageConst.Min;
            
            _view.ImageView.SetFillAmount(_fillingAmount);
            
            try
            {
                while(_view.ImageView.FillAmount < ImageConst.Max)
                {
                    _fillingAmount += ReloadWeaponConst.Speed * Time.deltaTime;
                    _view.ImageView.SetFillAmount(_fillingAmount);
                    
                    await UniTask.Delay(_delay, cancellationToken: cancellationToken);
                }

                Signal.Send(StreamId.Gameplay.ReturnToHud);
            }
            catch (OperationCanceledException)
            {
            }
        }
    }
}