using System.Collections.Generic;
using Sources.Scripts.Presentations.Views.Players;

namespace Sources.Scripts.PresentationsInterfaces.Views.Spawners
{
    public interface IEnemySpawnerView
    {
        IReadOnlyList<IEnemySpawnPoint> SpawnPoints { get; }

        PlayerView PlayerView { get; }

        void SetPlayerView (PlayerView playerView);
    }
}