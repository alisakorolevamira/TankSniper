using DestroyIt;
using Sources.Scripts.PresentationsInterfaces.Views.DestroyableObjects;
using UnityEngine;

namespace Sources.Scripts.Presentations.Views.DestroyableObjects
{
    public class DestroyableObjectView : View, IDestroyableObjectView
    {
        [SerializeField] private Destructible _destructible;

        private void OnCollisionEnter(Collision collision) => 
            _destructible.Destroy();
    }
}