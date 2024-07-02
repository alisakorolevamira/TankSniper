using System.Collections.Generic;
using Sources.Scripts.Presentations.Views.Enemies.Base;
using Sources.Scripts.Presentations.Views.Players;

namespace Sources.Scripts.PresentationsInterfaces.Views.Spawners
{
    public interface IEnemySpawnerView
    {
        IReadOnlyList<EnemyViewBase> EnemyViews { get; }

        PlayerView PlayerView { get; }

        void SetPlayerView (PlayerView playerView);
    }
}