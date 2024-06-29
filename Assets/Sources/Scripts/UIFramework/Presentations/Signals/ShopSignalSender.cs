using System.Collections.Generic;
using Doozy.Runtime.Signals;
using Doozy.Runtime.UIManager.Components;
using Sources.Scripts.Domain.Models.Constants;
using Sources.Scripts.Presentations.Views;
using Sources.Scripts.Presentations.Views.Players.Skins.MaterialTypes;
using Sources.Scripts.Presentations.Views.Players.Skins.SkinTypes;
using Sources.Scripts.UIFramework.Domain.Commands;
using Sources.Scripts.UIFramework.Domain.Signals;
using UnityEngine;

namespace Sources.Scripts.UIFramework.Presentations.Signals
{
    public class ShopSignalSender : View
    {
        [SerializeField] private UIButton _button;
        [SerializeField] private SkinType _skinType;
        [SerializeField] private List<ShopCommandId> _onClickCommandId;
        
        private SignalStream _stream;

        private void Awake() =>
            _stream = SignalStream.Get(StreamConst.ShopCommand, StreamConst.OnClick);

        private void OnEnable() =>
            _button.onClickEvent.AddListener(SendSignal);

        private void OnDisable() =>
            _button.onClickEvent.RemoveListener(SendSignal);

        private void SendSignal() => 
            _stream.SendSignal(new ShopCommandSignal(_onClickCommandId, _skinType));
    }
}