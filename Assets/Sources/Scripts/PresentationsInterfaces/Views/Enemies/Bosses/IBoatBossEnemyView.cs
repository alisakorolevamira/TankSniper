﻿using Sources.Scripts.Presentations.Views.Common;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Base;

namespace Sources.Scripts.PresentationsInterfaces.Views.Enemies.Bosses
{
    public interface IBoatBossEnemyView : IEnemyViewBase
    {
        IEnemyAnimation EnemyAnimation { get; }
        HealthBarUI HealthBar { get; }
    }
}