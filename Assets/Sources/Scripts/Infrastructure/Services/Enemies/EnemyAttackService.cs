using System.Collections.Generic;
using System.Linq;
using Sources.Scripts.Domain.Models.Constants;
using Sources.Scripts.InfrastructureInterfaces.Services.Enemies;
using Sources.Scripts.Presentations.Views.Common;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace Sources.Scripts.Infrastructure.Services.Enemies
{
    public class EnemyAttackService : IEnemyAttackService
    {
        public void TryAttack(Vector3 position, int damage)
        {
            //IReadOnlyList<CharacterHealthView> characterHealthViews =
            //        position,
            //        EnemyConst.MassAttackRadius,
            //        GraphView.Layer.Character,
            //        GraphView.Layer.Default);
//
            //if (characterHealthViews.Count == 0)
            //    return;
//
            //characterHealthViews.First().TakeDamage(damage);
        }
    }
}