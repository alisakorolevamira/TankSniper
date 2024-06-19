using System;
using Sources.Scripts.Controllers.Presenters.Weapons;
using Sources.Scripts.Infrastructure.Factories.Controllers.Presenters.Weapons;
using Sources.Scripts.Presentations.Views.Weapons;
using Sources.Scripts.PresentationsInterfaces.Views.Weapons;

namespace Sources.Scripts.Infrastructure.Factories.Views.Weapons
{
    public class ReloadWeaponViewFactory
    {
        private readonly ReloadWeaponPresenterFactory _presenterFactory;

        public ReloadWeaponViewFactory(ReloadWeaponPresenterFactory presenterFactory)
        {
            _presenterFactory = presenterFactory ?? throw new ArgumentNullException(nameof(presenterFactory));
        }

        public IReloadWeaponView Create(ReloadWeaponView view)
        {
            ReloadWeaponPresenter presenter = _presenterFactory.Create(view);
            
            view.Construct(presenter);

            return view;
        }
    }
}