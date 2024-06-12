using Sources.Scripts.Presentations.Views.Players;
using Sources.Scripts.PresentationsInterfaces.Views.Common;
using Sources.Scripts.PresentationsInterfaces.Views.NawMeshAgents;
using Sources.Scripts.PresentationsInterfaces.Views.Players;

namespace Sources.Scripts.PresentationsInterfaces.Views.Enemies.Base
{
    public interface IEnemyViewBase : INavMeshAgent
    {
        PlayerView PlayerView { get; }

        void SetPlayerView(PlayerView playerView);

        void EnableNavmeshAgent();

        void DisableNavmeshAgent();
    }
}