using System;
using Sources.Scripts.Domain.Models.Data.Ids;
using Sources.Scripts.InfrastructureInterfaces.Services.LoadServices;
using Sources.Scripts.InfrastructureInterfaces.Services.Shop;
using Sources.Scripts.UIFramework.Domain.Commands;
using Sources.Scripts.UIFramework.InfrastructureInterfaces.Commands.Views;

namespace Sources.Scripts.UIFramework.Infrastructure.Commands.Forms
{
    public class OpenNewStickmanCommand : IViewCommand
    {
        private readonly IStickmanChangerService _changerService;
        private readonly ILoadService _loadService;

        public OpenNewStickmanCommand(IStickmanChangerService changerService, ILoadService loadService)
        {
            _changerService = changerService ?? throw new ArgumentNullException(nameof(changerService));
            _loadService = loadService ?? throw new ArgumentNullException(nameof(loadService));
        }

        public FormCommandId Id => FormCommandId.OpenNewStickman;

        public void Handle()
        {
            _changerService.OpenNewStickman();
            _loadService.Save(ModelId.StickmanChanger);
        }
    }
}