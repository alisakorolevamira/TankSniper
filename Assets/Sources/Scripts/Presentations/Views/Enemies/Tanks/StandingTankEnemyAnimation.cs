using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Tanks;
using UnityEngine;

namespace Sources.Scripts.Presentations.Views.Enemies.Tanks
{
    public class StandingTankEnemyAnimation : View, IStandingTankEnemyAnimation
    {
        [SerializeField] private ParticleSystem _gunShoot;

        public void PlayIdle()
        {
        }

        public void PlayAttack()
        {
            _gunShoot.Play();
        }

        public void PlayDying() => 
            Hide();
    }
}