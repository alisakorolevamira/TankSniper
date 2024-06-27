using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Sources.Scripts.Domain.Models.Constants;
using Sources.Scripts.Domain.Models.Players;
using Sources.Scripts.Presentations.Views.Players;
using Sources.Scripts.PresentationsInterfaces.Views.Players;
using UnityEngine;

namespace Sources.Scripts.Controllers.Presenters.Players
{
    public class SkinChangerPresenter : PresenterBase
    {
        private readonly SkinChanger _skinChanger;
        private readonly ISkinChangerView _skinChangerView;

        private CancellationTokenSource _cancellationTokenSource;

        public SkinChangerPresenter(SkinChanger skinChanger, ISkinChangerView skinChangerView)
        {
            _skinChanger = skinChanger ?? throw new ArgumentNullException(nameof(skinChanger));
            _skinChangerView = skinChangerView ?? throw new ArgumentNullException(nameof(skinChangerView));
        }


        public override void Enable()
        {
            _cancellationTokenSource = new CancellationTokenSource();
            OnSkinChanged();
            _skinChanger.CurrentSkinChanged += OnSkinChanged;
        }

        public override void Disable()
        {
            _skinChanger.CurrentSkinChanged -= OnSkinChanged;
            _cancellationTokenSource.Cancel();
        }

        private void OnSkinChanged()
        {
            HideAllSkins();
            _skinChangerView.Skins[_skinChanger.CurrentSkin].Show();
            _skinChangerView.SetCurrentSkin(_skinChanger.CurrentSkin);
            
            PlayScaleAnimation();
        }

        private void HideAllSkins()
        {
            foreach (SkinView skinView in _skinChangerView.Skins.Values) 
                skinView.Hide();
        }

        private async void PlayScaleAnimation()
        {
            _cancellationTokenSource.Cancel();
            _cancellationTokenSource = new CancellationTokenSource();

            Vector3 currentScale = _skinChangerView.CurrentSkinView.CurrentScale;
            
            try
            {
                await ChangeScale(currentScale * InventoryTankConst.ScaleIndex, _cancellationTokenSource.Token);
                await ChangeScale(currentScale, _cancellationTokenSource.Token);
            }
            catch (OperationCanceledException)
            {
            }
        }

        private async UniTask ChangeScale(Vector3 to, CancellationToken token)
        {
            while (Vector3.Distance(_skinChangerView.CurrentSkinView.CurrentScale, to) > InventoryTankConst.DefaultDistance)
            {
                _skinChangerView.CurrentSkinView.SetScale(to);

                await UniTask.Yield(token);
            }
        }
    }
}