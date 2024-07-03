using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Base;
using Sources.Scripts.PresentationsInterfaces.Views.NawMeshAgents;

namespace Sources.Scripts.PresentationsInterfaces.Views.Enemies.Boss
{
    public interface IBossEnemyView : IEnemyViewBase, INavMeshAgent
    {
        void PlayAttackParticle();
    }
}