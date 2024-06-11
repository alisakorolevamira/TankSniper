using UnityEngine;

namespace Sources.Scripts.PresentationsInterfaces.Views.Cameras
{
    public interface ICameraView : IView
    {
        Vector3 CurrentPosition { get; }
        void SetPosition(Vector3 position);
        void SetRotation(Quaternion rotation);
    }
}