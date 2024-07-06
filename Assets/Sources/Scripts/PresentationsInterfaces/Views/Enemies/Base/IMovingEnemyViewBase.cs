using System.Collections.Generic;
using UnityEngine;

namespace Sources.Scripts.PresentationsInterfaces.Views.Enemies.Base
{
    public interface IMovingEnemyViewBase : IEnemyViewBase
    {
        IReadOnlyList<Transform> MovementPoints { get; }
        Vector3 Position { get; }

        void MoveToPoint(Vector3 direction);
        void SetRotation(float angle);
    }
}