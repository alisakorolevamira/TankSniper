using System;
using JetBrains.Annotations;
using Sources.Scripts.Controllers.Presenters.Weapons;
using Sources.Scripts.Infrastructure.Factories.Controllers.Presenters.Weapons;
using Sources.Scripts.InfrastructureInterfaces.Services.Weapons;
using Sources.Scripts.Presentations.Views.Weapons;
using Sources.Scripts.PresentationsInterfaces.Views.Weapons;

namespace Sources.Scripts.Infrastructure.Factories.Views.Weapons
{
    public class ReloadWeaponViewFactory
    {
        private readonly ReloadWeaponPresenterFactory _presenterFactory;
        private readonly IReloadWeaponService _reloadWeaponService;

        public ReloadWeaponViewFactory(ReloadWeaponPresenterFactory presenterFactory, [NotNull] IReloadWeaponService reloadWeaponService)
        {
            _presenterFactory = presenterFactory ?? throw new ArgumentNullException(nameof(presenterFactory));
            _reloadWeaponService = reloadWeaponService ?? throw new ArgumentNullException(nameof(reloadWeaponService));
        }

        public IReloadWeaponView Create(ReloadWeaponView view)
        {
            ReloadWeaponPresenter presenter = _presenterFactory.Create(view, _reloadWeaponService);
            
            view.Construct(presenter);

            return view;
        }
    }
}