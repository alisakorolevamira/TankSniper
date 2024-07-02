using System;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using Sources.Scripts.Domain.Models.Constants;
using Sources.Scripts.Presentations.Views.Enemies.Base;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Helicopter;
using UnityEngine;

namespace Sources.Scripts.Presentations.Views.Enemies.Helicopter
{
    public class HelicopterEnemyView : EnemyViewBase, IHelicopterEnemyView
    {
        [SerializeField] private HelicopterEnemyAnimation _enemyAnimation;

        public HelicopterEnemyAnimation EnemyAnimation => _enemyAnimation;
        private CancellationTokenSource _cancellationTokenSource;
        private readonly TimeSpan _delay = TimeSpan.FromMilliseconds(3f);

        public void Move(Vector3 direction)
        {
            _cancellationTokenSource = new CancellationTokenSource();
            
            ChangePosition(direction);
            
            _cancellationTokenSource.Cancel();
        }
        
        private async void ChangePosition(Vector3 endPoint)
        {
            float step =  50 * Time.deltaTime;
            
            try
            {
                while (Vector3.Distance(transform.position, endPoint) > BulletConst.MinDistance)
                {
                    transform.position = Vector3.MoveTowards(transform.position, endPoint, step);

                    await UniTask.Delay(_delay);
                }
            }
            catch (OperationCanceledException)
            {
            }
        }
    }
}