using System.Threading;
using Sources.Scripts.ControllersInterfaces.ControllerLifetimes;
using UnityEngine;

namespace Sources.Scripts.PresentationsInterfaces.UI.Texts
{
    public interface IUIText : IEnable, IDisable
    {
        bool IsHide { get; }
        
        void SetText(string text);
        void SetIsHide(bool isHide);
        void SetTextColor(Color color);
        void SetClearColorAsync(CancellationToken cancellationToken);
    }
}