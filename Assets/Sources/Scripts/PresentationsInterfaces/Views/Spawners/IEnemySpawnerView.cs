using System.Collections.Generic;
using Sources.Scripts.Presentations.Views.Common;
using Sources.Scripts.Presentations.Views.Players;
using Sources.Scripts.PresentationsInterfaces.Views.Common;

namespace Sources.Scripts.PresentationsInterfaces.Views.Spawners
{
    public interface IEnemySpawnerView
    {
        IReadOnlyList<IEnemySpawnPoint> SpawnPoints { get; }

        PlayerView PlayerView { get; }

        void SetPlayerView (PlayerView playerView);
    }
}