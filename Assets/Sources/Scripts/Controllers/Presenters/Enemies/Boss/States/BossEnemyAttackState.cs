using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Sources.Scripts.Controllers.Presenters.Enemies.Base.States;
using Sources.Scripts.Domain.Models.Constants;
using Sources.Scripts.Domain.Models.Enemies.Boss;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Boss;

namespace Sources.Scripts.Controllers.Presenters.Enemies.Boss.States
{
    public class BossEnemyAttackState : EnemyAttackState
    {
        private readonly BossEnemy _enemy;
        private readonly IBossEnemyView enemyView;

        private CancellationTokenSource _cancellationTokenSource;
        private TimeSpan _massAttackDelay;

        public BossEnemyAttackState(
            BossEnemy enemy,
            IBossEnemyView enemyView,
            IBossEnemyAnimation enemyAnimation)
            : base(
                enemy,
                enemyView,
                enemyAnimation)
        {
            _enemy = enemy ?? throw new ArgumentNullException(nameof(enemy));
            this.enemyView = enemyView ?? throw new ArgumentNullException(nameof(enemyView));
        }

        public override void Enter()
        {
            base.Enter();

            _cancellationTokenSource = new CancellationTokenSource();
            _massAttackDelay = TimeSpan.FromSeconds(EnemyConst.MassAttackAbilityDelay);

            StartAttackTimer(_cancellationTokenSource.Token);
        }

        public override void Exit()
        {
            base.Exit();
            _cancellationTokenSource.Cancel();
        }

        private async void StartAttackTimer(CancellationToken cancellationToken)
        {
            try
            {
                while (cancellationToken.IsCancellationRequested == false)
                {
                    await UniTask.Delay(_massAttackDelay, cancellationToken: cancellationToken);

                    ApplyAttack();
                }
            }
            catch (OperationCanceledException)
            {
            }
        }

        private void ApplyAttack()
        {
            enemyView.PlayAttackParticle();
        }

        private void CheckIsRun()
        {
            if (_enemy.IsRun == false)
                return;

            ApplyAttack();
            _enemy.IsRun = false;
        }
    }
}