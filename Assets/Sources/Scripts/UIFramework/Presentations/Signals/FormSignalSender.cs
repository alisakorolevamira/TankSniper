using System.Collections.Generic;
using Doozy.Runtime.Signals;
using Doozy.Runtime.UIManager.Containers;
using Sources.Scripts.Domain.Models.Constants;
using Sources.Scripts.UIFramework.Domain.Commands;
using Sources.Scripts.UIFramework.Domain.Signals;
using UnityEngine;

namespace Sources.Scripts.UIFramework.Presentations.Signals
{
    public class FormSignalSender : MonoBehaviour
    {
        [SerializeField] private UIView _view;
        [SerializeField] private List<FormCommandId> _onOpenCommandId;
        [SerializeField] private List<FormCommandId> _onCloseCommandId;
        
        private SignalStream _stream;

        private void Awake() =>
            _stream = SignalStream.Get(StreamConst.FormCommand, StreamConst.OnView);

        private void OnEnable()
        {
            _view.OnShowCallback.Event.AddListener(OnOpenCallback);
            _view.OnHideCallback.Event.AddListener(OnCloseCallback);
        }

        private void OnDisable()
        {
            _view.OnShowCallback.Event.RemoveListener(OnOpenCallback);
            _view.OnHideCallback.Event.RemoveListener(OnCloseCallback);
        }

        private void OnOpenCallback() =>
            _stream.SendSignal(new FormCommandSignal(_onOpenCommandId));

        private void OnCloseCallback() => 
            _stream.SendSignal(new FormCommandSignal(_onCloseCommandId));
    }
}