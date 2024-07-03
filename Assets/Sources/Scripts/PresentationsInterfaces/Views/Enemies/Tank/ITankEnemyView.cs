using System.Collections.Generic;
using Sources.Scripts.Presentations.Views.Common;
using Sources.Scripts.Presentations.Views.Enemies;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Base;
using Sources.Scripts.PresentationsInterfaces.Views.NawMeshAgents;
using UnityEngine;

namespace Sources.Scripts.PresentationsInterfaces.Views.Enemies.Tank
{
    public interface ITankEnemyView : IEnemyViewBase //INavMeshAgent
    {
        IReadOnlyList<Transform> MovementPoints { get; }
        Vector3 Position { get; }
        
        void MoveToPoint(Vector3 target);
        void SetRotation(float angle);
        //EnemyHealthView EnemyHealthView { get; }
        //HealthUIText HealthUIText { get; }
    }
}