using System;
using JetBrains.Annotations;
using Sources.Scripts.Domain.Models.Data.Ids;
using Sources.Scripts.InfrastructureInterfaces.Services.Audio;
using Sources.Scripts.InfrastructureInterfaces.Services.LoadServices;
using Sources.Scripts.UIFramework.Domain.Commands;
using Sources.Scripts.UIFramework.InfrastructureInterfaces.Commands.Buttons;

namespace Sources.Scripts.UIFramework.Infrastructure.Commands.Buttons
{
    public class ChangeVolumeCommand : IButtonCommand
    {
        private readonly IVolumeService _volumeService;
        private readonly ILoadService _loadService;

        public ChangeVolumeCommand(IVolumeService volumeService, ILoadService loadService)
        {
            _volumeService = volumeService ?? throw new ArgumentNullException(nameof(volumeService));
            _loadService = loadService ?? throw new ArgumentNullException(nameof(loadService));
        }
        
        public ButtonCommandId Id => ButtonCommandId.ChangeVolume;

        public void Handle()
        {
            _volumeService.SetVolume();
            _loadService.Save(ModelId.Volume);
        }
    }
}