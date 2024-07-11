using System.Collections.Generic;
using Sources.Scripts.Controllers.Presenters.Spawners;
using Sources.Scripts.Presentations.Views.Enemies.Base;
using Sources.Scripts.Presentations.Views.Enemies.Boat;
using Sources.Scripts.Presentations.Views.Enemies.Bosses;
using Sources.Scripts.Presentations.Views.Enemies.Dron;
using Sources.Scripts.Presentations.Views.Enemies.Helicopters;
using Sources.Scripts.Presentations.Views.Enemies.Jeep;
using Sources.Scripts.Presentations.Views.Enemies.Standing;
using Sources.Scripts.Presentations.Views.Enemies.Tanks;
using Sources.Scripts.Presentations.Views.Enemies.WalkingEnemy;
using Sources.Scripts.Presentations.Views.Players;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Base;
using Sources.Scripts.PresentationsInterfaces.Views.Spawners;
using UnityEngine;
using UnityEngine.Serialization;

namespace Sources.Scripts.Presentations.Views.Spawners
{
    public class EnemySpawnerView : PresentableView<EnemySpawnerPresenter>, IEnemySpawnerView
    {
        [Header("Enemies")]
        [SerializeField] private List<TankEnemyView> _tanks;
        [SerializeField] private List<BazookaHelicopterEnemyView> _bazookaHelicopters;
        [SerializeField] private List<HelicopterEnemyView> _helicopters;
        [SerializeField] private List<StandingEnemyView> _standings;
        [SerializeField] private List<JeepEnemyView> _jeeps;
        [SerializeField] private List<DronEnemyView> _drons;
        [SerializeField] private List<WalkingEnemyView> _walkings;
        [SerializeField] private List<StandingTankEnemyView> _standingTanks;
        [SerializeField] private List<BoatEnemyView> _boats;
        
        [Header("Bosses")]
        [SerializeField] private List<RobotBossEnemyView> _robotBosses;
        [SerializeField] private List<BoatBossEnemyView> _boatBosses;
        [SerializeField] private List<HelicopterBossEnemyView> _helicopterBosses;
        
        public IReadOnlyList<TankEnemyView> Tanks => _tanks;
        public IReadOnlyList<BazookaHelicopterEnemyView> BazookaHelicopters => _bazookaHelicopters;
        public IReadOnlyList<HelicopterEnemyView> Helicopters => _helicopters;
        public IReadOnlyList<StandingEnemyView> Standings => _standings;
        public IReadOnlyList<JeepEnemyView> Jeeps => _jeeps;
        public IReadOnlyList<DronEnemyView> Drons => _drons;
        public IReadOnlyList<WalkingEnemyView> Walkings => _walkings;
        public IReadOnlyList<StandingTankEnemyView> StandingTanks => _standingTanks;
        public IReadOnlyList<BoatEnemyView> Boats => _boats;
        public IReadOnlyList<RobotBossEnemyView> RobotBosses => _robotBosses;
        public IReadOnlyList<BoatBossEnemyView> BoatBosses => _boatBosses;
        public IReadOnlyList<HelicopterBossEnemyView> HelicopterBosses => _helicopterBosses;

        public PlayerView PlayerView { get; private set; }

        public void SetPlayerView (PlayerView playerView) => 
            PlayerView = playerView;
    }
}