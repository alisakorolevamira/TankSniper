using System.Collections.Generic;
using Sources.Scripts.Presentations.Views.Enemies.Base;
using Sources.Scripts.Presentations.Views.Enemies.Boat;
using Sources.Scripts.Presentations.Views.Enemies.Bosses;
using Sources.Scripts.Presentations.Views.Enemies.Dron;
using Sources.Scripts.Presentations.Views.Enemies.Helicopter;
using Sources.Scripts.Presentations.Views.Enemies.Jeep;
using Sources.Scripts.Presentations.Views.Enemies.Standing;
using Sources.Scripts.Presentations.Views.Enemies.Tanks;
using Sources.Scripts.Presentations.Views.Enemies.WalkingEnemy;
using Sources.Scripts.Presentations.Views.Players;

namespace Sources.Scripts.PresentationsInterfaces.Views.Spawners
{
    public interface IEnemySpawnerView
    {
        IReadOnlyList<TankEnemyView> Tanks { get; }
        IReadOnlyList<StandingEnemyView> Standings { get; }
        IReadOnlyList<HelicopterEnemyView> Helicopters { get; }
        IReadOnlyList<JeepEnemyView> Jeeps { get; }
        IReadOnlyList<DronEnemyView> Drons { get; }
        IReadOnlyList<WalkingEnemyView> Walkings { get; }
        IReadOnlyList<StandingTankEnemyView> StandingTanks { get; }
        IReadOnlyList<BoatEnemyView> Boats { get; }
        IReadOnlyList<RobotBossEnemyView> RobotBosses { get; }
        IReadOnlyList<BoatBossEnemyView> BoatBosses { get; }

        PlayerView PlayerView { get; }

        void SetPlayerView (PlayerView playerView);
    }
}