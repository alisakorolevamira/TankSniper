using Sources.Scripts.Controllers.Presenters.Weapons;
using Sources.Scripts.InfrastructureInterfaces.Services.Weapons;
using Sources.Scripts.PresentationsInterfaces.Views.Weapons;

namespace Sources.Scripts.Infrastructure.Factories.Controllers.Presenters.Weapons
{
    public class ReloadWeaponPresenterFactory
    {
        public ReloadWeaponPresenter Create(IReloadWeaponView view, IReloadWeaponService reloadWeaponService)
        {
            return new ReloadWeaponPresenter(view, reloadWeaponService);
        }
    }
}