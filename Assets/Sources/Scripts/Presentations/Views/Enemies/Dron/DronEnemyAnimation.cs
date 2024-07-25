using System.Collections.Generic;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Base;
using UnityEngine;

namespace Sources.Scripts.Presentations.Views.Enemies.Dron
{
    public class DronEnemyAnimation : View, IEnemyAnimation
    {
        [SerializeField] private ParticleSystem _attackParticle;
        [SerializeField] private List<GameObject> _pieces;

        public void PlayIdle()
        {
            foreach (GameObject piece in _pieces) 
                piece.SetActive(false);
        }

        public void PlayAttack() => 
            _attackParticle.Play();

        public void PlayDying()
        {
            _attackParticle.Stop();

           foreach (GameObject piece in _pieces)
           {
               piece.transform.SetParent(null);
               piece.SetActive(true);
           }

            Hide();
        }
    }
}