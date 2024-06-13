using System;
using JetBrains.Annotations;
using Sources.Scripts.Controllers.Presenters.Weapons;
using Sources.Scripts.Domain.Models.Weapons;
using Sources.Scripts.Infrastructure.Factories.Controllers.Presenters.Weapons;
using Sources.Scripts.Presentations.Views.Weapons;
using Sources.Scripts.PresentationsInterfaces.Views.Weapons;

namespace Sources.Scripts.Infrastructure.Factories.Views.Weapons
{
    public class WeaponViewFactory
    {
        private readonly WeaponPresenterFactory _presenterFactory;

        public WeaponViewFactory(WeaponPresenterFactory presenterFactory)
        {
            _presenterFactory = presenterFactory ?? throw new ArgumentNullException(nameof(presenterFactory));
        }
        
        public IWeaponView Create(Weapon weapon, WeaponView weaponView)
        {
            WeaponPresenter weaponPresenter = _presenterFactory.Create(weapon, weaponView);
            
            weaponView.Construct(weaponPresenter); 
            
            return weaponView;
        }
    }
}