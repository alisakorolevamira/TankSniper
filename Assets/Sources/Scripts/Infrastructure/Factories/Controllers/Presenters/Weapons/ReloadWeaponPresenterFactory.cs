using System;
using JetBrains.Annotations;
using Sources.Scripts.Controllers.Presenters.Weapons;
using Sources.Scripts.PresentationsInterfaces.Views.Weapons;
using Sources.Scripts.UIFramework.ServicesInterfaces.Forms;

namespace Sources.Scripts.Infrastructure.Factories.Controllers.Presenters.Weapons
{
    public class ReloadWeaponPresenterFactory
    {
        private readonly IFormService _formService;

        public ReloadWeaponPresenterFactory([NotNull] IFormService formService)
        {
            _formService = formService ?? throw new ArgumentNullException(nameof(formService));
        }
        
        public ReloadWeaponPresenter Create(IReloadWeaponView view)
        {
            return new ReloadWeaponPresenter(view, _formService);
        }
    }
}