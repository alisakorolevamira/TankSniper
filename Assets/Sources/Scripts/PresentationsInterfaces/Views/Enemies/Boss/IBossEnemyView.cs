using System.Collections.Generic;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Base;
using UnityEngine;

namespace Sources.Scripts.PresentationsInterfaces.Views.Enemies.Boss
{
    public interface IBossEnemyView : IEnemyViewBase
    {
        IReadOnlyList<Transform> MovementPoints { get; }
        Vector3 Position { get; }

        void MoveToPoint(Vector3 target);
        void SetRotation(float angle);
    }
}