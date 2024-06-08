using System.Collections.Generic;
using Sources.Scripts.UIFramework.Domain.Commands;
using Sources.Scripts.UIFramework.InfrastructureInterfaces.Commands.Views;
using Sources.Scripts.UIFramework.InfrastructureInterfaces.Commands.Views.Handlers;

namespace Sources.Scripts.UIFramework.Infrastructure.Commands.Forms.Handlers
{
    public class MainMenuUIViewCommandHandler : IUIViewCommandHandler
    {
        private readonly Dictionary<FormCommandId, IViewCommand> _commands = new ();
        
        public MainMenuUIViewCommandHandler(
            PauseCommand pauseCommand,
            UnPauseCommand unPauseCommand,
            SaveVolumeCommand saveVolumeCommand)
        {
            _commands[pauseCommand.Id] = pauseCommand;
            _commands[unPauseCommand.Id] = unPauseCommand;
            _commands[saveVolumeCommand.Id] = saveVolumeCommand;
        }
        
        public void Handle(FormCommandId formCommandId)
        {
            if(_commands.ContainsKey(formCommandId) == false)
                throw new KeyNotFoundException(nameof(formCommandId));
            
            _commands[formCommandId].Handle();
        }
    }
}