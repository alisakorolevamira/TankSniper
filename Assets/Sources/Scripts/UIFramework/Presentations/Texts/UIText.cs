using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Sources.Scripts.Presentations.Views;
using Sources.Scripts.PresentationsInterfaces.UI.Texts;
using TMPro;
using UnityEngine;

namespace Sources.Scripts.UIFramework.Presentations.Texts
{
    public class UIText: View, IUIText
    {
        [SerializeField] private TextMeshProUGUI _tmpText;
        
        public bool IsHide { get; private set; }

        private void Awake()
        {
            if (_tmpText == null)
                throw new NullReferenceException(nameof(gameObject.name));
        }

        public void SetText(string text) =>
            _tmpText.text = text;

        public void SetTextColor(Color color) =>
            _tmpText.color = color;

        public void SetIsHide(bool isHide) =>
            IsHide = isHide;

        public async void SetClearColorAsync(CancellationToken cancellationToken)
        {
            try
            {
                while (_tmpText.color.a > 0)
                {
                    _tmpText.color = Vector4.MoveTowards(
                        _tmpText.color, Vector4.zero, 0.01f);

                    await UniTask.Yield(cancellationToken);
                }

                IsHide = true;
            }
            catch (OperationCanceledException)
            {
                IsHide = true;
            }
        }

        public void Enable() =>
            _tmpText.enabled = true;

        public void Disable() =>
            _tmpText.enabled = false;
    }
}