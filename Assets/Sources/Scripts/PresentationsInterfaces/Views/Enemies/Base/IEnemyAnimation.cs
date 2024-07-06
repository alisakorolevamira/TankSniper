using System;

namespace Sources.Scripts.PresentationsInterfaces.Views.Enemies.Base
{
    public interface IEnemyAnimation
    {
        void PlayIdle();

        void PlayAttack();

        void PlayDying();
    }
}