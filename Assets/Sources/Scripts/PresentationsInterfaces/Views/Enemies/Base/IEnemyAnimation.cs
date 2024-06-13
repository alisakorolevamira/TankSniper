using System;

namespace Sources.Scripts.PresentationsInterfaces.Views.Enemies.Base
{
    public interface IEnemyAnimation
    {
        event Action Attacking;

        void PlayIdle();

        void PlayAttack();
    }
}