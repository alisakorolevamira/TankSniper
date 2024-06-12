using UnityEngine;

namespace Sources.Scripts.PresentationsInterfaces.Views
{
    public interface IView
    {
        void Show();
        void Hide();
        void SetParent(Transform parent);
        void SetPosition(Vector3 position);
        void SetRotation(Vector3 rotation);
        void Destroy();
    }
}