using Sources.Scripts.PresentationsInterfaces.Views.BossPeaces;
using UnityEngine;

namespace Sources.Scripts.Presentations.Views.BossPeaces
{
    public class HelicopterPeaceView : View, IBossPieceView
    {
        [SerializeField] private Rigidbody _rigidbody;
        
        public bool IsDestroyed { get; private set; }
        
        public void Explode()
        {
            transform.SetParent(null);
            IsDestroyed = true;
            _rigidbody.isKinematic = false;
        }
    }
}