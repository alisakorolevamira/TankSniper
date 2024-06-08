using System.Collections.Generic;
using Sources.Scripts.UIFramework.Domain.Commands;
using Sources.Scripts.UIFramework.InfrastructureInterfaces.Commands.Views;
using Sources.Scripts.UIFramework.InfrastructureInterfaces.Commands.Views.Handlers;

namespace Sources.Scripts.UIFramework.Infrastructure.Commands.Forms.Handlers
{
    public class GameplayUIViewCommandHandler : IUIViewCommandHandler
    {
        private readonly Dictionary<FormCommandId, IViewCommand> _commands = 
            new Dictionary<FormCommandId, IViewCommand>();
        
        public GameplayUIViewCommandHandler(
            PauseCommand pauseCommand,
            UnPauseCommand unPauseCommand,
            SaveVolumeCommand saveVolumeCommand)
            //ClearSavesCommand clearSavesCommand,
            //SetAllMapCameraFollowViewCommand setAllMapCameraFollowViewCommand,
            //SetCharacterCameraFollowViewCommand setCharacterCameraFollowUiViewCommand)
        {
            _commands[pauseCommand.Id] = pauseCommand;
            _commands[unPauseCommand.Id] = unPauseCommand;
            _commands[saveVolumeCommand.Id] = saveVolumeCommand;
            //_commands[clearSavesCommand.Id] = clearSavesCommand;
            //_commands[setAllMapCameraFollowViewCommand.Id] = setAllMapCameraFollowViewCommand;
            //_commands[setCharacterCameraFollowUiViewCommand.Id] = setCharacterCameraFollowUiViewCommand;
        }

        public void Handle(FormCommandId formCommandId)
        {
            if(_commands.ContainsKey(formCommandId) == false)
                throw new KeyNotFoundException(nameof(formCommandId));
            
            _commands[formCommandId].Handle();
        }
    }
}