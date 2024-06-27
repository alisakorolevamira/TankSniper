using System.Collections.Generic;
using Doozy.Runtime.Signals;
using Doozy.Runtime.UIManager.Components;
using Sources.Scripts.Domain.Models.Constants;
using Sources.Scripts.Presentations.Views;
using Sources.Scripts.UIFramework.Domain.Commands;
using Sources.Scripts.UIFramework.Domain.Signals;
using Sources.Scripts.UIFramework.PresentationsInterfaces.Signals;
using UnityEngine;

namespace Sources.Scripts.UIFramework.Presentations.Signals
{
    public class ButtonSignalSender : View, IButtonSignalSender
    {
        [SerializeField] private UIButton _button;
        [SerializeField] private List<ButtonCommandId> _onClickCommandId;
        
        private SignalStream _stream;

        private void Awake() =>
            _stream = SignalStream.Get(StreamConst.ButtonCommand, StreamConst.OnClick);

        private void OnEnable() =>
            _button.onClickEvent.AddListener(SendSignal);

        private void OnDisable() =>
            _button.onClickEvent.RemoveListener(SendSignal);

        private void SendSignal() =>
            _stream.SendSignal(new ButtonCommandSignal(_onClickCommandId));
    }
}