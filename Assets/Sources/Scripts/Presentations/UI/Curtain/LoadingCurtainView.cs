using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Sources.Scripts.Domain.Models.Constants;
using Sources.Scripts.Presentations.Views;
using UnityEngine;

namespace Sources.Scripts.Presentations.UI.Curtain
{
    public class LoadingCurtainView : View
    {
        [SerializeField] private CanvasGroup _canvasGroup;
        [SerializeField] private float _duration = 3f;

        private TimeSpan _delay = TimeSpan.FromMilliseconds(LoadingCurtainConst.Delay);
        private CancellationTokenSource _cancellationTokenSource;

        public bool IsInProgress { get; private set; }

        private void Awake()
        {
            DontDestroyOnLoad(this);
            _canvasGroup.alpha = 0;
        }

        private void OnEnable() =>
            _cancellationTokenSource = new CancellationTokenSource();

        private void OnDisable() =>
            _cancellationTokenSource.Cancel();

        public async UniTask ShowCurtain()
        {
            IsInProgress = true;
            Show();
            await Fade(0, LoadingCurtainConst.Max, _cancellationTokenSource.Token);
        }

        public async UniTask HideCurtain()
        {
            await Fade(LoadingCurtainConst.Max, 0, _cancellationTokenSource.Token);
            Hide();
            IsInProgress = false;
        }

        private async UniTask Fade(float start, float end, CancellationToken cancellationToken)
        {
            try
            {
                _canvasGroup.alpha = start;

                while (Mathf.Abs(_canvasGroup.alpha - end) > MathConst.Epsilon)
                {
                    _canvasGroup.alpha = Mathf.MoveTowards(
                        _canvasGroup.alpha, end, Time.deltaTime / _duration);

                    await UniTask.Delay(
                        _delay, ignoreTimeScale: true, cancellationToken: cancellationToken);
                }

                _canvasGroup.alpha = end;
            }
            catch (OperationCanceledException)
            {
                if (_canvasGroup == null)
                    return;

                Hide();
            }
            catch (MissingReferenceException)
            {
            }
        }
    }
}