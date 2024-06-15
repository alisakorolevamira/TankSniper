using System;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using Sources.Scripts.Domain.Models.Gameplay;
using Sources.Scripts.Infrastructure.StateMachines.FiniteStateMachines.States;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Base;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Tank;

namespace Sources.Scripts.Controllers.Presenters.Enemies.Tank.States
{
    public class TankDieState : FiniteState
    {
        private readonly KilledEnemiesCounter _killedEnemiesCounter;
        private readonly ITankEnemyView _tankEnemyView;
        private readonly List<IEnemyViewBase> _enemyCollection;
        private readonly ITankEnemyAnimation _enemyAnimation;
        
        private CancellationTokenSource _cancellationTokenSource;
        private TimeSpan _animationDelay = TimeSpan.FromSeconds(6);

        public TankDieState(
            KilledEnemiesCounter killedEnemiesCounter,
            ITankEnemyView tankEnemyView,
            List<IEnemyViewBase> enemyCollection,
            ITankEnemyAnimation enemyAnimation)
        {
            _killedEnemiesCounter = killedEnemiesCounter ??
                                    throw new ArgumentNullException(nameof(killedEnemiesCounter));
            _tankEnemyView = tankEnemyView ?? throw new ArgumentNullException(nameof(tankEnemyView));
            _enemyCollection = enemyCollection ?? throw new ArgumentNullException(nameof(enemyCollection));
            _enemyAnimation = enemyAnimation ?? throw new ArgumentNullException(nameof(enemyAnimation));
        }

        public override void Enter()
        {
            _cancellationTokenSource = new CancellationTokenSource();
            
            if (_tankEnemyView == null)
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
                    _enemyCollection.Remove(_tankEnemyView);
                    _enemyAnimation.PlayDying();
                    
                    await UniTask.Delay(_animationDelay, cancellationToken: cancellationToken);

                    _tankEnemyView.Destroy();
                }
            }
            catch (OperationCanceledException)
            {
            }
        }
    }
}