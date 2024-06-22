using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Sources.Scripts.Domain.Models.Constants;
using Sources.Scripts.UIFramework.Presentations.Animations;
using Sources.Scripts.UIFramework.Presentations.Animations.Types;
using Sources.Scripts.UIFramework.ServicesInterfaces.Animations;
using UnityEngine;

namespace Sources.Scripts.UIFramework.Services.Animations
{
    public class AnimationService : IAnimationService
    {
         private UIAnimator _uiAnimator;
        private CancellationTokenSource _cancellationTokenSource;
        
        public void Enable()
        {
            _cancellationTokenSource = new CancellationTokenSource();
            
            PlayAnimation();
        }

        public void Disable()
        {
            _cancellationTokenSource.Cancel();
        }

        public void Construct(UIAnimator uiAnimator) =>
            _uiAnimator = uiAnimator;

        public void Destroy() =>
            _cancellationTokenSource.Cancel();

        private async void PlayAnimation()
        {
            _cancellationTokenSource.Cancel();
            _cancellationTokenSource = new CancellationTokenSource();

            if (_uiAnimator.AnimationType != AnimationType.Move) return;
            
            if (_uiAnimator.MoveAnimationType == MoveAnimationType.PopUp)
                await PlayMoveAnimationAsync(_uiAnimator.transform, _cancellationTokenSource.Token);
                
            if (_uiAnimator.MoveAnimationType == MoveAnimationType.Infinitely)
            {
                while (_cancellationTokenSource.Token.IsCancellationRequested == false)
                {
                    await PlayMoveAnimationAsync(_uiAnimator.transform, _cancellationTokenSource.Token);
                }
            }
        }

        private async UniTask PlayMoveAnimationAsync(Transform transform, CancellationToken token)
        {
            try
            {
                while (transform != null && Vector3.Distance(
                           transform.position, _uiAnimator.TargetPosition) > MathConst.Epsilon)
                {
                    transform.position = Vector3.MoveTowards(
                        transform.position,
                        _uiAnimator.TargetPosition,
                        _uiAnimator.AnimationDuration);

                    await UniTask.Yield(token);
                }

                while (transform != null && Vector3.Distance(
                           transform.position, _uiAnimator.FromPosition) > MathConst.Epsilon)
                {
                    transform.position = Vector3.MoveTowards(
                        transform.position,
                        _uiAnimator.FromPosition,
                        _uiAnimator.AnimationDuration);

                    await UniTask.Yield(token);
                }
            }
            catch (OperationCanceledException)
            {
                if (transform == null)
                    return;

                transform.position = _uiAnimator.FromPosition;
            }
        }
    }
}