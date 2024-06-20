using UnityEngine;

namespace Sources.Scripts.PresentationsInterfaces.Views.Common
{
    public interface ICharacterHealthView
    {
        Vector3 Position { get; }
        void TakeDamage(int damage);
    }
}