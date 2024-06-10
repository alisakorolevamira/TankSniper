using System;

namespace Sources.Scripts.PresentationsInterfaces.Views.Enemies.Base
{
    public interface IEnemyAnimation
    {
        event Action Attacking;

        void PlayWalk();

        void PlayIdle();

        void PlayAttack();
    }
}