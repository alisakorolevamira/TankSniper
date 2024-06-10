using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Base;

namespace Sources.Scripts.PresentationsInterfaces.Views.Enemies.Boss
{
    public interface IBossEnemyView : IEnemyView
    {
        void PlayAttackParticle();

        void SetAgentSpeed(float speed);
    }
}