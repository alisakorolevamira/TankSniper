using Sources.Scripts.PresentationsInterfaces.Views.Common;
using Sources.Scripts.PresentationsInterfaces.Views.NawMeshAgents;
using Sources.Scripts.PresentationsInterfaces.Views.Players;

namespace Sources.Scripts.PresentationsInterfaces.Views.Enemies.Base
{
    public interface IEnemyViewBase : INavMeshAgent
    {
        ICharacterHealthView CharacterHealthView { get; }

        void SetCharacterHealth(ICharacterHealthView characterHealthView);

        void EnableNavmeshAgent();

        void DisableNavmeshAgent();
    }
}