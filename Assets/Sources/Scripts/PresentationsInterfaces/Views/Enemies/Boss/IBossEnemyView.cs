using System.Collections.Generic;
using Sources.Scripts.Presentations.Views.Common;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Base;
using UnityEngine;

namespace Sources.Scripts.PresentationsInterfaces.Views.Enemies.Boss
{
    public interface IBossEnemyView : IMovingEnemyViewBase
    {
        HealthBarUI HealthBar { get; }
        
        void Explode();
    }
}