using Sources.Scripts.PresentationsInterfaces.Views.Common;

namespace Sources.Scripts.PresentationsInterfaces.Views.Enemies.Base
{
    public interface IEnemyViewBase
    {
        ICharacterHealthView PlayerHealthView { get; }

        void SetPlayerHealthView(ICharacterHealthView playerHealthView);
        
        void SetLookAtPlayer();
    }
}