using System.Collections.Generic;
using Sources.Scripts.Presentations.Views.Enemies.Base;
using Sources.Scripts.Presentations.Views.Enemies.Boss;
using Sources.Scripts.Presentations.Views.Enemies.Dron;
using Sources.Scripts.Presentations.Views.Enemies.Helicopter;
using Sources.Scripts.Presentations.Views.Enemies.Jeep;
using Sources.Scripts.Presentations.Views.Enemies.Standing;
using Sources.Scripts.Presentations.Views.Enemies.Tank;
using Sources.Scripts.Presentations.Views.Players;

namespace Sources.Scripts.PresentationsInterfaces.Views.Spawners
{
    public interface IEnemySpawnerView
    {
        IReadOnlyList<TankEnemyView> Tanks { get; }
        IReadOnlyList<StandingEnemyView> Standings { get; }
        IReadOnlyList<HelicopterEnemyView> Helicopters { get; }
        IReadOnlyList<JeepEnemyView> Jeeps { get; }
        IReadOnlyList<BossEnemyView> Bosses { get; }
        IReadOnlyList<DronEnemyView> Drons { get; }

        PlayerView PlayerView { get; }

        void SetPlayerView (PlayerView playerView);
    }
}