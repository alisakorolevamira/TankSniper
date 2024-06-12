﻿using System.Collections.Generic;
using Sources.Scripts.Domain.Models.Spawners.Types;
using Sources.Scripts.Presentations.Views.Enemies.Base;
using UnityEngine;

namespace Sources.Scripts.PresentationsInterfaces.Views.Spawners
{
    public interface IEnemySpawnPoint
    {
        EnemyType EnemyType { get; }
        EnemyView EnemyView { get; }

        Vector3 Position { get; }
        
        IReadOnlyList<Transform> Points { get; }
    }
}