﻿using System;
using System.Collections.Generic;
using Sources.Scripts.Controllers.Presenters.Spawners;
using Sources.Scripts.Presentations.Views.Players;
using Sources.Scripts.PresentationsInterfaces.Views.Spawners;
using UnityEngine;

namespace Sources.Scripts.Presentations.Views.Spawners
{
    public class EnemySpawnerView : PresentableView<EnemySpawnerPresenter>, IEnemySpawnerView
    {
        [SerializeField] private List<EnemySpawnPoint> _spawnPoints;

        public IReadOnlyList<IEnemySpawnPoint> SpawnPoints => _spawnPoints;

        public PlayerView PlayerView { get; private set; }

        public void SetPlayerView (PlayerView playerView)
        {
            PlayerView = playerView ? playerView :
                throw new ArgumentNullException(nameof(playerView));
        }
    }
}