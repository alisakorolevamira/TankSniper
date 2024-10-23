using System;
using Doozy.Runtime.Signals;
using Sources.Scripts.Domain.Models.Constants;
using Sources.Scripts.UIFramework.ControllerInterfaces.Forms;
using Sources.Scripts.UIFramework.Domain.Commands;
using Sources.Scripts.UIFramework.Domain.Signals;
using Sources.Scripts.UIFramework.InfrastructureInterfaces.Commands.Views.Handlers;

namespace Sources.Scripts.UIFramework.Controllers.Forms
{
    public class FormCommandSignalController : IFormSignalController
    {
        private readonly IUIViewCommandHandler _uiViewCommandHandler;

        private SignalReceiver _signalReceiver;
        private SignalStream _signalStream;

        public FormCommandSignalController(IUIViewCommandHandler uiViewCommandHandler)
        {
            _uiViewCommandHandler = uiViewCommandHandler ??
                                    throw new ArgumentNullException(nameof(uiViewCommandHandler));
        }

        public void Initialize()
        {
            _signalReceiver =
                new SignalReceiver()
                    .SetOnSignalCallback(Handle);
            _signalStream = SignalStream
                .Get(StreamConst.FormCommand, StreamConst.OnView)
                .ConnectReceiver(_signalReceiver);
        }

        public void Destroy() =>
            _signalStream.DisconnectReceiver(_signalReceiver);

        private void Handle(Signal signal)
        {
            if (signal.TryGetValue(out FormCommandSignal value) == false)
                throw new InvalidOperationException("Signal valueAsObject is not FormCommandSignal");

            foreach (FormCommandId commandId in value.FormCommandIds)
                _uiViewCommandHandler.Handle(commandId);
        }
    }
}