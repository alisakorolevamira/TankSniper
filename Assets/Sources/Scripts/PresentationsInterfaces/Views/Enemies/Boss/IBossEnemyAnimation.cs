using System;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Base;

namespace Sources.Scripts.PresentationsInterfaces.Views.Enemies.Boss
{
    public interface IBossEnemyAnimation : IEnemyAnimation
    {
        event Action ScreamAnimationEnded;

        void PlayRun();
    }
}