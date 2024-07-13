using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Sources.Scripts.Domain.Models.Constants;
using Sources.Scripts.Domain.Models.Players;
using Sources.Scripts.Domain.Models.Stickman;
using Sources.Scripts.Presentations.Views.Stickman;
using Sources.Scripts.PresentationsInterfaces.Views.Stickman;
using UnityEngine;

namespace Sources.Scripts.Controllers.Presenters.Stickman
{
    public class StickmanChangerPresenter : PresenterBase
    {
        private readonly StickmanChanger _stickmanChanger;
        private readonly IStickmanChangerView _stickmanChangerView;

        private CancellationTokenSource _cancellationTokenSource;

        public StickmanChangerPresenter(StickmanChanger stickmanChanger, IStickmanChangerView stickmanChangerView)
        {
            _stickmanChanger = stickmanChanger ?? throw new ArgumentNullException(nameof(stickmanChanger));
            _stickmanChangerView = stickmanChangerView ?? throw new ArgumentNullException(nameof(stickmanChangerView));
        }
        
        public override void Enable()
        {
            _cancellationTokenSource = new CancellationTokenSource();
            
            OnStickmanChanged();
            
            _stickmanChanger.CurrentStickmanChanged += OnStickmanChanged;
        }

        public override void Disable()
        {
            _stickmanChanger.CurrentStickmanChanged -= OnStickmanChanged;
            
            _cancellationTokenSource.Cancel();
        }

        private void OnStickmanChanged()
        {
            HideAllSkins();

            if (_stickmanChanger.CurrentStickman == StickmanType.Default)
                return;
            
            _stickmanChangerView.Stickmen[_stickmanChanger.CurrentStickman].Show();
            _stickmanChangerView.SetCurrentStickman(_stickmanChanger.CurrentStickman);
            
            PlayScaleAnimation();
        }
        
        private void HideAllSkins()
        {
            foreach (StickmanView stickmanView in _stickmanChangerView.Stickmen.Values) 
                stickmanView.Hide();
        }

        private async void PlayScaleAnimation()
        {
            _cancellationTokenSource.Cancel();
            _cancellationTokenSource = new CancellationTokenSource();

            Vector3 currentScale = _stickmanChangerView.CurrentStickmanView.CurrentScale;
            
            try
            {
                await ChangeScale(currentScale * ShopConst.ScaleIndex, _cancellationTokenSource.Token);
                await ChangeScale(currentScale, _cancellationTokenSource.Token);
            }
            catch (OperationCanceledException)
            {
            }
        }
        
        private async UniTask ChangeScale(Vector3 to, CancellationToken token)
        {
            while (Vector3.Distance(_stickmanChangerView.CurrentStickmanView.CurrentScale, to) > ShopConst.DefaultDistance)
            {
                _stickmanChangerView.CurrentStickmanView.SetScale(to);

                await UniTask.Yield(token);
            }
        }
    }
}