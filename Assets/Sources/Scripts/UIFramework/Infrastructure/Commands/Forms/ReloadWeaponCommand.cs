using System;
using Sources.Scripts.InfrastructureInterfaces.Services.Weapons;
using Sources.Scripts.UIFramework.Domain.Commands;
using Sources.Scripts.UIFramework.InfrastructureInterfaces.Commands.Views;

namespace Sources.Scripts.UIFramework.Infrastructure.Commands.Forms
{
    public class ReloadWeaponCommand : IViewCommand
    {
        private readonly IReloadWeaponService _reloadWeaponService;

        public ReloadWeaponCommand(IReloadWeaponService reloadWeaponService)
        {
            _reloadWeaponService = reloadWeaponService ?? throw new ArgumentNullException(nameof(reloadWeaponService));
        }

        public FormCommandId Id => FormCommandId.ReloadWeapon;

        public void Handle() =>
            _reloadWeaponService.ReloadWeapon();
    }
}