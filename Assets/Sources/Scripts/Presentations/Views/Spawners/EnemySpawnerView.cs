using System.Collections.Generic;
using Sources.Scripts.Controllers.Presenters.Spawners;
using Sources.Scripts.Presentations.Views.Enemies.Base;
using Sources.Scripts.Presentations.Views.Enemies.Boss;
using Sources.Scripts.Presentations.Views.Enemies.Helicopter;
using Sources.Scripts.Presentations.Views.Enemies.Jeep;
using Sources.Scripts.Presentations.Views.Enemies.Standing;
using Sources.Scripts.Presentations.Views.Enemies.Tank;
using Sources.Scripts.Presentations.Views.Players;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Base;
using Sources.Scripts.PresentationsInterfaces.Views.Spawners;
using UnityEngine;

namespace Sources.Scripts.Presentations.Views.Spawners
{
    public class EnemySpawnerView : PresentableView<EnemySpawnerPresenter>, IEnemySpawnerView
    {
        [SerializeField] private List<TankEnemyView> _tanks;
        [SerializeField] private List<HelicopterEnemyView> _helicopters;
        [SerializeField] private List<StandingEnemyView> _standings;
        [SerializeField] private List<JeepEnemyView> _jeeps;
        [SerializeField] private List<BossEnemyView> _bosses;
        
        public IReadOnlyList<TankEnemyView> Tanks => _tanks;
        public IReadOnlyList<HelicopterEnemyView> Helicopters => _helicopters;
        public IReadOnlyList<StandingEnemyView> Standings => _standings;
        public IReadOnlyList<JeepEnemyView> Jeeps => _jeeps;
        public IReadOnlyList<BossEnemyView> Bosses => _bosses;

        public PlayerView PlayerView { get; private set; }

        public void SetPlayerView (PlayerView playerView) => 
            PlayerView = playerView;
    }
}