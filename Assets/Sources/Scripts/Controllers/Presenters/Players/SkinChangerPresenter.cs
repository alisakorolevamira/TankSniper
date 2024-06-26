﻿using System;
using System.Threading;
using Cysharp.Threading.Tasks;
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
            OnSkinChanged();
            _skinChanger.CurrentSkinChanged += OnSkinChanged;

            _cancellationTokenSource = new CancellationTokenSource();
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
            
            try
            {
                await ChangeScale(new Vector3(0.8f, 0.8f, 0.8f), _cancellationTokenSource.Token);
                await ChangeScale(new Vector3(1, 1, 1), _cancellationTokenSource.Token);
            }
            catch (OperationCanceledException)
            {
            }
        }

        private async UniTask ChangeScale(Vector3 to, CancellationToken token)
        {
            while (Vector3.Distance(_skinChangerView.CurrentSkinView.CurrentScale, to) > 0.01f)
            {
                _skinChangerView.CurrentSkinView.SetScale(to);

                await UniTask.Yield(token);
            }
        }
    }
}