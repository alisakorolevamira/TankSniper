using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Base;

namespace Sources.Scripts.PresentationsInterfaces.Views.Enemies.Boss
{
    public interface IBossEnemyView : IEnemyViewBase
    {
        void PlayAttackParticle();

        void SetAgentSpeed(float speed);
    }
}