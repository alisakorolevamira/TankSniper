using System;
using Doozy.Runtime.Signals;
using Sources.Scripts.Domain.Models.Constants;
using Sources.Scripts.UIFramework.ControllerInterfaces.Buttons;
using Sources.Scripts.UIFramework.Domain.Commands;
using Sources.Scripts.UIFramework.Domain.Signals;
using Sources.Scripts.UIFramework.InfrastructureInterfaces.Commands.Buttons.Handlers;

namespace Sources.Scripts.UIFramework.Controllers.Buttons
{
    public class ButtonCommandSignalController : IButtonSignalController
    {
        private readonly IButtonCommandHandler _buttonCommandHandler;

        private SignalReceiver _signalReceiver;
        private SignalStream _signalStream;

        public ButtonCommandSignalController(IButtonCommandHandler buttonCommandHandler)
        {
            _buttonCommandHandler = buttonCommandHandler ??
                                    throw new ArgumentNullException(nameof(buttonCommandHandler));
        }

        public void Initialize()
        {
            _signalReceiver =
                new SignalReceiver()
                    .SetOnSignalCallback(Handle);
            _signalStream = SignalStream
                .Get(StreamConst.ButtonCommand, StreamConst.OnClick)
                .ConnectReceiver(_signalReceiver);
        }

        public void Destroy() =>
            _signalStream.DisconnectReceiver(_signalReceiver);

        private void Handle(Signal signal)
        {
            if (signal.TryGetValue(out ButtonCommandSignal value) == false)
                throw new InvalidOperationException("Signal valueAsObject is not ButtonCommandSignal");

            foreach (ButtonCommandId commandId in value.ButtonCommandIds)
                _buttonCommandHandler.Handle(commandId);
        }
    }
}