using System;
using System.Collections.Generic;
using Sources.Scripts.Presentations.Views.Animations;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Jeep;
using UnityEngine;

namespace Sources.Scripts.Presentations.Views.Enemies.Jeep
{
    public class JeepEnemyAnimation : View, IJeepEnemyAnimation
    {
        [SerializeField] private Collider _collider;
        [SerializeField] private List<GameObject> _enemies;
        [SerializeField] private List<Animator> _animators;
        
        public event Action Attacking;
        
        public void PlayIdle()
        {
            foreach (var animator in _animators) 
                animator.Play("Idle");
        }

        public void PlayAttack()
        {
            Attacking?.Invoke();
            
            foreach (var animator in _animators) 
                animator.SetBool("Shoot", true);
        }

        public void PlayDying()
        {
            _collider.SendMessage("Shatter", transform.position, SendMessageOptions.DontRequireReceiver);
            
            foreach (GameObject enemy in _enemies) 
                Destroy(enemy);
        }
    }
}