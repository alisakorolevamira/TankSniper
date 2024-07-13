using System;
using Doozy.Runtime.Signals;
using Sources.Scripts.Domain.Models.Constants;
using Sources.Scripts.UIFramework.ControllerInterfaces.Shop;
using Sources.Scripts.UIFramework.Domain.Commands;
using Sources.Scripts.UIFramework.Domain.Signals;
using Sources.Scripts.UIFramework.InfrastructureInterfaces.Commands.Shop.Handlers;

namespace Sources.Scripts.UIFramework.Controllers.Shop
{
    public class ShopCommandSignalController : IShopSignalController
    {
        private readonly IShopCommandHandler _shopCommandHandler;

        private SignalReceiver _signalReceiver;
        private SignalStream _signalStream;

        public ShopCommandSignalController(IShopCommandHandler shopCommandHandler)
        {
            _shopCommandHandler = shopCommandHandler ??
                                  throw new ArgumentNullException(nameof(shopCommandHandler));
        }

        public void Initialize()
        {
            _signalReceiver =
                new SignalReceiver()
                    .SetOnSignalCallback(Handle);
            _signalStream = SignalStream
                .Get(StreamConst.ShopCommand, StreamConst.OnClick)
                .ConnectReceiver(_signalReceiver);
        }

        public void Destroy() =>
            _signalStream.DisconnectReceiver(_signalReceiver);

        private void Handle(Signal signal)
        {
            if (signal.TryGetValue(out ShopCommandSignal value) == false)
                throw new InvalidOperationException("Signal valueAsObject is not ShopCommandSignal");

            foreach (ShopCommandId commandId in value.ShopCommandIds)
                _shopCommandHandler.Handle(commandId, value.SkinType, value.StickmanType);
        }
    }
}