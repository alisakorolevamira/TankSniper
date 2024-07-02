using System.Collections.Generic;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Base;
using Sources.Scripts.PresentationsInterfaces.Views.NawMeshAgents;
using UnityEngine;

namespace Sources.Scripts.PresentationsInterfaces.Views.Enemies.Tank
{
    public interface ITankEnemyView : IEnemyViewBase
    {
        IReadOnlyList<Transform> MovementPoints { get; }
    }
}