using System.Collections.Generic;
using Sources.Scripts.Controllers.Presenters.Spawners;
using Sources.Scripts.Presentations.Views.Enemies.Base;
using Sources.Scripts.Presentations.Views.Players;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Base;
using Sources.Scripts.PresentationsInterfaces.Views.Spawners;
using UnityEngine;

namespace Sources.Scripts.Presentations.Views.Spawners
{
    public class EnemySpawnerView : PresentableView<EnemySpawnerPresenter>, IEnemySpawnerView
    {
        [SerializeField] private List<EnemyViewBase> _enemyViews;
        
        public IReadOnlyList<EnemyViewBase> EnemyViews => _enemyViews;

        public PlayerView PlayerView { get; private set; }

        public void SetPlayerView (PlayerView playerView) => 
            PlayerView = playerView;
    }
}