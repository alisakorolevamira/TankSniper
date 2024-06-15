using System;
using System.Collections.Generic;
using Sources.Scripts.Presentations.Views.Animations;
using Sources.Scripts.Presentations.Views.Enemies.Base;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Tank;
using UnityEngine;
using UnityEngine.Serialization;

namespace Sources.Scripts.Presentations.Views.Enemies.Tank
{
    public class TankEnemyAnimation : AnimationViewBase, ITankEnemyAnimation
    {
        [SerializeField] private ParticleSystem _movementParticle;
        [SerializeField] private ParticleSystem _attackParticle;
        [SerializeField] private List<Rigidbody> _peaces;
        
        public event Action Attacking;
        
        public void PlayIdle()
        {
            _movementParticle.Play();
        }

        public void PlayAttack()
        {
            _movementParticle.Stop();
            _attackParticle.Play();
            Attacking?.Invoke();
        }

        public void PlayDying()
        {
            _movementParticle.Stop();
            _attackParticle.Stop();

            foreach (var peace in _peaces)
            {
                Debug.Log("add force");
                //peace.isKinematic = false;
                peace.AddForce(transform.up * 20);
            }
        }
    }
}