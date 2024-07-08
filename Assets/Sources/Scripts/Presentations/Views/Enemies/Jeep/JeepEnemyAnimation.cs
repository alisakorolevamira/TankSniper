﻿using System.Collections.Generic;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Jeep;
using UnityEngine;

namespace Sources.Scripts.Presentations.Views.Enemies.Jeep
{
    public class JeepEnemyAnimation : View, IJeepEnemyAnimation
    {
        [SerializeField] private Collider _collider;
        [SerializeField] private List<GameObject> _enemies;
        
        public void PlayIdle()
        {
        }

        public void PlayAttack()
        {
        }

        public void PlayDying()
        {
            _collider.SendMessage("Shatter", transform.position, SendMessageOptions.DontRequireReceiver);
            
            foreach (GameObject enemy in _enemies) 
                Destroy(enemy);
        }
    }
}