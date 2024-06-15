using Sources.Scripts.PresentationsInterfaces.Views.Constructions;
using Sources.Scripts.PresentationsInterfaces.Views.Weapons;
using UnityEngine;

namespace Sources.Scripts.PresentationsInterfaces.Views.Bullets
{
    public interface IBulletView : IConstruct<IWeaponView>, IView
    {
        void Move(Vector3 direction);
    }
}