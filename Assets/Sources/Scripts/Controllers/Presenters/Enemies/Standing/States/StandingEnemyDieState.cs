using System;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using Sources.Scripts.Domain.Models.Gameplay;
using Sources.Scripts.Infrastructure.StateMachines.FiniteStateMachines.States;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Base;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Standing;

namespace Sources.Scripts.Controllers.Presenters.Enemies.Standing.States
{
    public class StandingEnemyDieState : FiniteState
    {
        private readonly KilledEnemiesCounter _killedEnemiesCounter;
        private readonly IStandingEnemyView _enemyView;
        private readonly List<IEnemyViewBase> _enemyCollection;
        private readonly IStandingEnemyAnimation _enemyAnimation;
        
        private CancellationTokenSource _cancellationTokenSource;
        private TimeSpan _animationDelay = TimeSpan.FromSeconds(6);

        public StandingEnemyDieState(
            KilledEnemiesCounter killedEnemiesCounter,
            IStandingEnemyView enemyView,
            List<IEnemyViewBase> enemyCollection,
            IStandingEnemyAnimation enemyAnimation)
        {
            _killedEnemiesCounter = killedEnemiesCounter ??
                                    throw new ArgumentNullException(nameof(killedEnemiesCounter));
            _enemyView = enemyView ?? throw new ArgumentNullException(nameof(enemyView));
            _enemyCollection = enemyCollection ?? throw new ArgumentNullException(nameof(enemyCollection));
            _enemyAnimation = enemyAnimation ?? throw new ArgumentNullException(nameof(enemyAnimation));
        }

        public override void Enter()
        {
            _cancellationTokenSource = new CancellationTokenSource();
            
            if (_enemyView == null)
                return;

            Die(_cancellationTokenSource.Token);
        }

        private async void Die(CancellationToken cancellationToken)
        {
            try
            {
                while (cancellationToken.IsCancellationRequested == false)
                {
                    _killedEnemiesCounter.IncreaseKilledEnemiesCount();
                    _enemyCollection.Remove(_enemyView);
                    _enemyAnimation.PlayDying();
                    
                    await UniTask.Delay(_animationDelay, cancellationToken: cancellationToken);

                    _enemyView.Destroy();
                }
            }
            catch (OperationCanceledException)
            {
            }
        }
    }
}