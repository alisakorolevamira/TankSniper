using Sources.Scripts.PresentationsInterfaces.Views.Constructions;
using Sources.Scripts.PresentationsInterfaces.Views.Weapons;

namespace Sources.Scripts.PresentationsInterfaces.Views.Bullets
{
    public interface IBulletView : IConstruct<IWeaponView>, IView
    {
    }
}