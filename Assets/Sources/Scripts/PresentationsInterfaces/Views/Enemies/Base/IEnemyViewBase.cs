using Sources.Scripts.PresentationsInterfaces.Views.Common;
using Sources.Scripts.PresentationsInterfaces.Views.NawMeshAgents;

namespace Sources.Scripts.PresentationsInterfaces.Views.Enemies.Base
{
    public interface IEnemyViewBase : INavMeshAgent
    {
        ICharacterHealthView PlayerHealthView { get; }

        void SetPlayerHealthView(ICharacterHealthView playerHealthView);
        
        void SetLookAtPlayer();
    }
}