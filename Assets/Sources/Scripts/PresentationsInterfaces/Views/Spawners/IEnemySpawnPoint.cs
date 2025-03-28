﻿using System.Collections.Generic;
using Sources.Scripts.Domain.Models.Spawners.Types;
using UnityEngine;

namespace Sources.Scripts.PresentationsInterfaces.Views.Spawners
{
    public interface IEnemySpawnPoint
    {
        EnemyType EnemyType { get; }

        Vector3 Position { get; }
        
        IReadOnlyList<Transform> Points { get; }
    }
}