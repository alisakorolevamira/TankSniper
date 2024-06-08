using System;
using Sources.Scripts.Domain.Models.Data.Ids;
using Sources.Scripts.InfrastructureInterfaces.Services.LoadServices;
using Sources.Scripts.UIFramework.Domain.Commands;
using Sources.Scripts.UIFramework.InfrastructureInterfaces.Commands.Views;

namespace Sources.Scripts.UIFramework.Infrastructure.Commands.Forms
{
    public class SaveVolumeCommand : IViewCommand
    {
        private readonly ILoadService _loadService;

        public SaveVolumeCommand(ILoadService loadService)
        {
            _loadService = loadService ?? throw new ArgumentNullException(nameof(loadService));
        }

        public FormCommandId Id => FormCommandId.SaveVolume;
        
        public void Handle() =>
            _loadService.Save(ModelId.Volume);
    }
}