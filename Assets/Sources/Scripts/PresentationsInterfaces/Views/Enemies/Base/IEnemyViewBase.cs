using Sources.Scripts.Domain.Models.Spawners.Types;
using Sources.Scripts.PresentationsInterfaces.Views.Common;
using Sources.Scripts.PresentationsInterfaces.Views.NawMeshAgents;

namespace Sources.Scripts.PresentationsInterfaces.Views.Enemies.Base
{
    public interface IEnemyViewBase : INavMeshAgent
    {
        EnemyType EnemyType { get; }
        ICharacterHealthView PlayerHealthView { get; }

        void SetPlayerHealthView(ICharacterHealthView playerHealthView);
        
        void SetLookAtPlayer();
    }
}