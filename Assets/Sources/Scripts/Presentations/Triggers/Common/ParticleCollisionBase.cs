using System;
using Sources.Scripts.Presentations.Views;
using Sources.Scripts.PresentationsInterfaces.Triggers;
using UnityEngine;

namespace Sources.Scripts.Presentations.Triggers.Common
{
    public class ParticleCollisionBase<T> : View, IEnteredTrigger<T>
    {
        public event Action<T> Entered;
        
        private void OnParticleCollision(GameObject other)
        {
            if (other.TryGetComponent(out T component))
                Entered?.Invoke(component);
        }
    }
}