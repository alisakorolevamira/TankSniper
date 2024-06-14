using System;
using Sources.Scripts.Controllers.Presenters.Weapons;
using Sources.Scripts.Infrastructure.Factories.Controllers.Presenters.Weapons;
using Sources.Scripts.Presentations.Views.Weapons;
using Sources.Scripts.PresentationsInterfaces.Views.Weapons;

namespace Sources.Scripts.Infrastructure.Factories.Views.Weapons
{
    public class ReloadWeaponViewFactory
    {
        private readonly ReloadWeaponPresenterFactory _factory;

        public ReloadWeaponViewFactory(ReloadWeaponPresenterFactory factory)
        {
            _factory = factory ?? throw new ArgumentNullException(nameof(factory));
        }

        public IReloadWeaponView Create(ReloadWeaponView view)
        {
            ReloadWeaponPresenter presenter = _factory.Create(view);
            
            view.Construct(presenter);

            return view;
        }
    }
}