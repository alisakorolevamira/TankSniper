using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Base;
using UnityEngine;

namespace Sources.Scripts.Presentations.Views.Enemies.Bosses
{
    public class BoatBossEnemyAnimation : View, IEnemyAnimation
    {
        [SerializeField] private ParticleSystem _attackParticle;
        
        public void PlayIdle()
        {
            _attackParticle.Stop();
        }

        public void PlayAttack()
        {
            _attackParticle.Play();
        }

        public void PlayDying()
        {
            Hide();
        }
    }
}